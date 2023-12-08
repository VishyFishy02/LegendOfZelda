using LegendofZelda.Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace Sprites
{
    public class Digdogger : IEnemy
    {
        private IDigdogger currentDigdogger;
        private bool isDead = false, isDamaged = false, dyingComplete = false;
        private int health = 3, damagedCounter = 0, deathFrames = 0, currFrames = 0;
        public bool IsDead { get => isDead; set => isDead = value; }
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        public enum DigdoggerActions
        {
            BigMovingUp, BigMovingDown, BigMovingLeft, BigMovingRight, SmallStunned
        };

        List<DigdoggerActions> digDoggerActions = new List<DigdoggerActions> {DigdoggerActions.BigMovingUp, DigdoggerActions.BigMovingDown,
        DigdoggerActions.BigMovingRight, DigdoggerActions.BigMovingLeft, DigdoggerActions.SmallStunned};
        DigdoggerActions currAction;

        private List<string> droppableItems = new List<string> { "BigHeart" };
        private Texture2D texture, dyingTexture;
        private float xPos, yPos;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public Digdogger(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPos = xPosition;
            this.yPos = yPosition;
            dyingTexture = texture2;
            destinationRectangle = new Rectangle((int)xPos, (int)yPos, 39, 48);
            currAction = DigdoggerActions.BigMovingDown;
            currentDigdogger = new DigdoggerGoingDownSprite(texture, xPos, yPos);

        }

        public void Update()
        {
            // Decided if the digdogger should change its current action
            if (!isDead)
            {
                ++currFrames;
                if (isDamaged)
                {
                    damagedCounter++;
                    if (damagedCounter >= 60)
                    {
                        isDamaged = false;
                        currentDigdogger.IsDamaged = false;
                        damagedCounter = 0;
                    }
                }

                currentDigdogger.Update();
                destinationRectangle = currentDigdogger.DestinationRectangle;
                // Pick an action to take based on where link is
                Vector2 linkLocation = Link.Instance.currentPosition;

                if (!(currentDigdogger is DigdoggerSmallStunnedSprite))
                {
                    if (linkLocation.Y > currentDigdogger.YPosition)
                    {
                        currAction = DigdoggerActions.BigMovingDown;
                    }
                    else if (linkLocation.X > currentDigdogger.XPosition)
                    {
                        currAction = DigdoggerActions.BigMovingRight;
                    }
                    else if (linkLocation.Y < currentDigdogger.YPosition)
                    {
                        currAction = DigdoggerActions.BigMovingUp;
                    }
                    else
                    {
                        currAction = DigdoggerActions.BigMovingLeft;
                    }
                }
                else
                {
                    if ((currFrames % 180) == 0)
                    {
                        currAction = DigdoggerActions.BigMovingDown;
                    }
                }
                switchAction(currAction);
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 15, 16);
            if (!isDead)
            {
                currentDigdogger.Draw(spriteBatch);
            }
            else
            {
                deathFrames++;
                int maxDeathFrames = 20;
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                var sourceRectangles = new List<Rectangle>();
                sourceRectangles.Add(new Rectangle(0, 0, 15, 16));
                sourceRectangles.Add(new Rectangle(16, 0, 15, 16));
                sourceRectangles.Add(new Rectangle(35, 3, 9, 10));
                sourceRectangles.Add(new Rectangle(51, 3, 9, 10));
                destinationRectangle = new Rectangle((int)currentDigdogger.XPosition, (int)currentDigdogger.YPosition, 30, 30);
                for(int i= 0; i < sourceRectangles.Count; i++){
                    if(deathFrames>i * maxDeathFrames / sourceRectangles.Count && deathFrames<= (i +1)* maxDeathFrames / sourceRectangles.Count)
                    {
                        if (!dyingComplete)
                        {
                            spriteBatch.Draw(dyingTexture, destinationRectangle, sourceRectangles[i], Color.White);
                        }
                      
                    }  else if(deathFrames>maxDeathFrames)
                        {
                            dyingComplete = true;
                        }
                }
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            Rectangle hitbox = currentDigdogger.GetHitbox();
            return hitbox;
        }

        public void switchAction(DigdoggerActions actionToTake)
        {
            // Get the hitbox of the current digdogger
            Rectangle currentLocation = currentDigdogger.GetHitbox();
            xPos = (float)currentLocation.X;
            yPos = (float)currentLocation.Y;

            // Randomly select a digdogger state to make
            switch (actionToTake)
            {
                case DigdoggerActions.BigMovingUp:
                    currentDigdogger = new DigdoggerGoingUpSprite(texture, xPos, yPos);
                    break;
                case DigdoggerActions.BigMovingDown:
                    currentDigdogger = new DigdoggerGoingDownSprite(texture, xPos, yPos);
                    break;
                case DigdoggerActions.BigMovingLeft:
                    currentDigdogger = new DigdoggerGoingLeftSprite(texture, xPos, yPos);
                    break;
                case DigdoggerActions.BigMovingRight:
                    currentDigdogger = new DigdoggerGoingRightSprite(texture, xPos, yPos);
                    break;
                case DigdoggerActions.SmallStunned:
                    currentDigdogger = new DigdoggerSmallStunnedSprite(texture, xPos, yPos);
                    break;
                default:
                    break;
            }
        }

        public void TurnAround(string side)
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentDigdogger.GetHitbox();
            xPos = (float)currentLocation.X;
            yPos = (float)currentLocation.Y;

            // Have the Digdogger turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    currentDigdogger = new DigdoggerGoingDownSprite(texture, xPos, yPos);
                    currAction = DigdoggerActions.BigMovingDown;
                    break;
                case "bottom":
                    currentDigdogger = new DigdoggerGoingUpSprite(texture, xPos, yPos);
                    currAction = DigdoggerActions.BigMovingUp;
                    break;
                case "left":
                    currentDigdogger = new DigdoggerGoingRightSprite(texture, xPos, yPos);
                    currAction = DigdoggerActions.BigMovingRight;
                    break;
                case "right":
                    currentDigdogger = new DigdoggerGoingLeftSprite(texture, xPos, yPos);
                    currAction = DigdoggerActions.BigMovingLeft;
                    break;
                case "stunned":
                    currentDigdogger = new DigdoggerSmallStunnedSprite(texture, xPos, yPos);
                    currAction = DigdoggerActions.SmallStunned;
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
                health -= 1;
                isDamaged = true;
                currentDigdogger.IsDamaged = true;
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
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(currentDigdogger.XPosition, currentDigdogger.YPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }

        public void PoofIn(SpriteBatch spriteBatch)
        {
        }
    }
}
