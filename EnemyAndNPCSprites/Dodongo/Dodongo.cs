using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace Sprites
{
    public class DodongoSprite : IEnemy
    {
        private IDodongo currentDodongo;
        public IDodongo CurrentDodongo { get => currentDodongo; }
        private int health = 2;
        private int deathFrames = 0;
        private bool isDamaged = false;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private int switchCounter = 0;
        private enum DodongoActions
        {
            MovingUp, MovingDown, MovingRight, MovingLeft
        };
        List<DodongoActions> dodongoActions = new List<DodongoActions> {DodongoActions.MovingUp, DodongoActions.MovingDown, DodongoActions.MovingRight, DodongoActions.MovingLeft};
        private Random rand = new Random();

        private List<string> droppableItems = new List<string> { "BigHeart" };


        private Texture2D texture;
        private Texture2D dyingTexture;

        private float xPos;
        private float yPos;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        
        public DodongoSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPos = xPosition;
            this.yPos = yPosition;
            this.dyingTexture = texture2;
            this.destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 39, 48);
            this.currentDodongo = new DodongoMovingRightSprite(texture, this.xPos, this.yPos);
        }
        public void Update()
        {
            if (!isDead)
            {
                
                    switchCounter += rand.Next(0, 10);
                    if (!isDamaged && switchCounter >= 400)
                    {
                        this.switchAction();
                        switchCounter = 0;
                    }
                    if (isDamaged && !currentDodongo.IsDamaged)
                    {
                        isDamaged = false;
                    }
                    currentDodongo.Update();
                    this.destinationRectangle = currentDodongo.DestinationRectangle;
                
            
            
            }
            else
            {
                deathFrames++;
                if (deathFrames >= 0 && deathFrames < 60)
                {
                    currentDodongo.Update();
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sourceRectangle = new Rectangle(0, 0, 15, 16);
            
                if (!isDead)
            {
                currentDodongo.Draw(spriteBatch);
            }
            else
            {
                this.destinationRectangle = new Rectangle((int)this.currentDodongo.XPosition, (int)this.currentDodongo.YPosition, 30, 30);
                if (deathFrames >= 0 && deathFrames < 60)
                {
                    currentDodongo.Draw(spriteBatch);
                } else {
                    spriteBatch.Begin();
                    if (deathFrames >= 60 && deathFrames <= 65)
                    {
                        sourceRectangle = new Rectangle(0, 0, 15, 16);

                    }
                    else if (deathFrames > 65 && deathFrames < 70)
                    {
                        sourceRectangle = new Rectangle(16, 0, 15, 16);
                    }
                    else if (deathFrames >= 75 && deathFrames < 80)
                    {
                        sourceRectangle = new Rectangle(35, 3, 9, 10);

                    }
                    else if (deathFrames >= 85 && deathFrames < 90)
                    {
                        sourceRectangle = new Rectangle(51, 3, 9, 10);
                    }
                    else if (deathFrames >= 90)
                    {
                        this.dyingComplete = true;
                    }
                    if (!dyingComplete)
                    {
                        spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangle, Microsoft.Xna.Framework.Color.White);
                    }
                    spriteBatch.End();
                }
            }
        }
        public Rectangle GetHitbox()
        {
            return currentDodongo.GetHitbox();
        }
        private void switchAction()
        {
            // Get the hitbox of the current dodongo
            Rectangle currentLocation = currentDodongo.GetHitbox();
            this.xPos = (float)currentLocation.X;
            this.yPos = (float)currentLocation.Y;

            // Randomly select a dodongo state to make
            switch (dodongoActions[rand.Next(0, dodongoActions.Count)])
            {
                case DodongoActions.MovingUp:
                    this.currentDodongo = new DodongoMovingUpSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DodongoActions.MovingDown:
                    this.currentDodongo = new DodongoMovingDownSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DodongoActions.MovingLeft:
                    this.currentDodongo = new DodongoMovingLeftSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DodongoActions.MovingRight:
                    this.currentDodongo = new DodongoMovingRightSprite(this.texture, this.xPos, this.yPos);
                    break;
                default:
                    break;
            }
        }
        public void TurnAround(string side)
        {
            // Get the hitbox of the current dodongo
            Rectangle currentLocation = currentDodongo.GetHitbox();
            
            // Have the Dodongo turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    this.currentDodongo = new DodongoMovingDownSprite(this.texture, currentLocation.X, currentLocation.Y);
                    break;
                case "bottom":
                    this.currentDodongo = new DodongoMovingUpSprite(this.texture, currentLocation.X, currentLocation.Y);
                    break;
                case "left":
                    this.currentDodongo = new DodongoMovingRightSprite(this.texture, currentLocation.X, currentLocation.Y);
                    break;
                case "right":
                    this.currentDodongo = new DodongoMovingLeftSprite(this.texture, currentLocation.X, currentLocation.Y);
                    break;
                default:
                    break;
            }
        }
        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            if (!isDamaged)
            {
                this.health -= 1;
                this.isDamaged = true;
                this.currentDodongo.IsDamaged = true;
            }
            if (this.health <= 0)
            {
                this.isDead = true;
            }
        }
        public ISprite DropItem()
        {
            if (dyingComplete)
            {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(this.currentDodongo.XPosition, this.currentDodongo.YPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }
        public void PoofIn(SpriteBatch spriteBatch) { }
    }
}
