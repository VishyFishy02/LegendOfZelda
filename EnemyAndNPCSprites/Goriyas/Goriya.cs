using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace Sprites
{
    public class GoriyaSprite : IEnemy
    {
        private enum GoriyaActions
        {
            MovingUp, MovingDown, MovingRight, MovingLeft,
            ThrowingUp, ThrowingRight, ThrowingLeft, ThrowingDown
        };
        public bool IsDead { get => isDead; set => isDead = value; }
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private IGoriya currentGoriya;
        private IEnemyProjectile currentBoomerang;
        private int health, deathFrames, damagedCounter;
        private bool isDamaged, dyingComplete, isDead;
        private float xPos, yPos;
        private Random rand;
        private List<string> droppableItems = new List<string> { "SmallRedHeart", "SmallBlueHeart", "OrangeGemstone", "Bomb" };
        private Texture2D texture, dyingTexture;
        private Rectangle destinationRectangle, sourceRectangle;
        private List<Rectangle> sourceRectangles;
        List<GoriyaActions> goriyaActions = new List<GoriyaActions> {
            GoriyaActions.MovingUp, GoriyaActions.MovingDown,GoriyaActions.MovingRight, GoriyaActions.MovingLeft,
            GoriyaActions.ThrowingUp, GoriyaActions.ThrowingRight, GoriyaActions.ThrowingLeft, GoriyaActions.ThrowingDown};
        
        public GoriyaSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            isDamaged = false;
            dyingComplete = false;
            isDead = false;
            health = 3;
            deathFrames = 0;
            damagedCounter = 0;
            rand = new();
            this.texture = texture;
            xPos = xPosition;
            yPos = yPosition;
            dyingTexture = texture2;
            destinationRectangle = new();
            currentGoriya = new GoriyaMovingRightSprite(texture, xPos, yPos);
            currentBoomerang = null;
            sourceRectangles = new();
            sourceRectangles.Add(new(0, 0, 15, 16));
            sourceRectangles.Add(new(16, 0, 15, 16));
            sourceRectangles.Add(new(35, 3, 9, 10));
            sourceRectangles.Add(new(51, 3, 9, 10));
        }

        public void Update()
        {
            // Decided if the goriya should change its current action
            if (!isDead)
            {

                currentGoriya.Update();

                if (isDamaged)
                {
                    damagedCounter++;
                    if (damagedCounter >= 60)
                    {
                        isDamaged = false;
                        currentGoriya.IsDamaged = false;
                        damagedCounter = 0;
                    }
                }
                if ((rand.Next(0, 1000)) % 100 == 0)
                {
                    if (currentGoriya is GoriyaThrowingRightSprite || currentGoriya is GoriyaThrowingLeftSprite || currentGoriya is GoriyaThrowingDownSprite || currentGoriya is GoriyaThrowingUpSprite)
                    {
                        if (!currentBoomerang.keepThrowing)
                        {
                            switchAction();
                        }

                    }
                    else
                    {
                        switchAction();
                    }

                }
                destinationRectangle = currentGoriya.DestinationRectangle;
            }
            else
            {
                deathFrames++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int maxDeathFrames = 20;
            if (!isDead)
            {
                currentGoriya.Draw(spriteBatch);
                
            }
            else
            {
                spriteBatch.Begin();
                for (int i = 0; i < 4; i++)
                {
                    if (deathFrames > (i * maxDeathFrames) / 4 && deathFrames <= ((i + 1) * maxDeathFrames) / 4)
                    {
                        sourceRectangle = sourceRectangles[i];
                    }
                    else if (deathFrames > maxDeathFrames)
                    {
                        dyingComplete = true;
                    }
                }
                if (!dyingComplete)
                {
                    destinationRectangle = new Rectangle((int)currentGoriya.XPosition, (int)currentGoriya.YPosition, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
                    spriteBatch.Draw(dyingTexture, destinationRectangle, sourceRectangle, Color.White);
                }
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            Rectangle hitbox = currentGoriya.GetHitbox();
            return hitbox;
        }

        private void switchAction()
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentGoriya.GetHitbox();
            xPos = (float)currentLocation.X;
            yPos = (float)currentLocation.Y;

            // Randomly select a goriya state to make
            switch (goriyaActions[rand.Next(0, goriyaActions.Count)])
            {
                case GoriyaActions.MovingUp:
                    currentGoriya = new GoriyaMovingUpSprite(texture, xPos, yPos);
                    break;
                case GoriyaActions.MovingDown:
                    currentGoriya = new GoriyaMovingDownSprite(texture, xPos, yPos);
                    break;
                case GoriyaActions.MovingLeft:
                    currentGoriya = new GoriyaMovingLeftSprite(texture, xPos, yPos);
                    break;
                case GoriyaActions.MovingRight:
                    currentGoriya = new GoriyaMovingRightSprite(texture, xPos, yPos);
                    break;
                case GoriyaActions.ThrowingUp:
                    currentGoriya = new GoriyaThrowingUpSprite(texture, xPos, yPos);
                    currentBoomerang = new GoriyaBoomerangUpSprite(texture, xPos, yPos);
                    break;
                case GoriyaActions.ThrowingDown:
                    currentGoriya = new GoriyaThrowingDownSprite(texture, xPos, yPos);
                    currentBoomerang = new GoriyaBoomerangDownSprite(texture, xPos, yPos);
                    break;
                case GoriyaActions.ThrowingLeft:
                    currentGoriya = new GoriyaThrowingLeftSprite(texture, xPos, yPos);
                    currentBoomerang = new GoriyaBoomerangLeftSprite(texture, xPos, yPos);
                    break;
                case GoriyaActions.ThrowingRight:
                    currentGoriya = new GoriyaThrowingRightSprite(texture, xPos, yPos);
                    currentBoomerang = new GoriyaBoomerangRightSprite(texture, xPos, yPos);
                    break;
                default:
                    break;
            }
        }
        public void TurnAround(string side)
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentGoriya.GetHitbox();
            xPos = (float)currentLocation.X;
            yPos = (float)currentLocation.Y;

            // Have the Goriya turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    currentGoriya = new GoriyaMovingDownSprite(texture, xPos, yPos);
                    break;
                case "bottom":
                    currentGoriya = new GoriyaMovingUpSprite(texture, xPos, yPos);
                    break;
                case "left":
                    currentGoriya = new GoriyaMovingRightSprite(texture, xPos, yPos);
                    break;
                case "right":
                    currentGoriya = new GoriyaMovingLeftSprite(texture, xPos, yPos);
                    break;
                default:
                    break;

            }
        }
        public IEnemyProjectile GetCurrentBoomerang()
        {
            return currentBoomerang;
        }
        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();

            if (!isDamaged)
            {
                health -= 1;
                isDamaged = true;
                currentGoriya.IsDamaged = true;
            }
            if (health <= 0)
            {
                isDead = true;
            }
        }
        public ISprite DropItem()
        {
            if (dyingComplete)
            {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(currentGoriya.XPosition, currentGoriya.YPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }
        public void PoofIn(SpriteBatch spriteBatch) { }
    }
}
