using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using LegendofZelda.SpriteFactories;
using System.Collections.Generic;

namespace Sprites
{
    public class WallMasterSprite : IEnemy
    {
        private List<string> droppableItems = new List<string> { "SmallRedHeart", "SmallBlueHeart", "OrangeGemstone", "Fairy" };


        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;
        private int deathFrames = 0;
        
        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private Rectangle destinationRectangle;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        // Handles deciding enemy movement
        Random random;
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
       
        public WallMasterSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            dyingTexture = texture2;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 60, 60);
            random = new Random();
            currDirection = directions[random.Next(0, directions.Count)];
        }
        public void Update()
        {
            if (!isDead)
            {
                if (random.Next(0, maxFrames) <= (maxFrames / 50))
                {
                    currDirection = directions[random.Next(0, directions.Count)];
                }
                if (currFrames == 20)
                {
                    currFrames = 0;
                }
                else
                {
                    currFrames += 1;
                }

                if (currDirection == Directions.UP)
                {
                    yPosition -= 1;
                }
                else if (currDirection == Directions.LEFT)
                {
                    xPosition -= 1;
                }
                else if (currDirection == Directions.RIGHT)
                {
                    xPosition += 1;
                }
                else // Direction is down
                {
                    yPosition += 1;
                }
            } else
            {
                deathFrames++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(393, 11, 16, 16);
            if (!isDead)
            {
                
                destinationRectangle = new((int)xPosition, (int)yPosition, 60, 60);
                if (currFrames <10)
                {
                    sourceRectangle = new Rectangle(410, 12, 14, 15);

                } else
                {
                    sourceRectangle = new Rectangle(393, 11, 16, 16);
                }

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }

            else {
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            if (deathFrames > 5 && deathFrames < 10)
                {
                    sourceRectangle = new Rectangle(16, 0, 15, 16);
                }
                else if (deathFrames >= 10 && deathFrames < 15)
                {
                    sourceRectangle = new Rectangle(35, 3, 9, 10);

                }
                else if (deathFrames >= 15 && deathFrames < 20)
                {
                    sourceRectangle = new Rectangle(51, 3, 9, 10);
                }
                else
                {
                    dyingComplete = true;
                }
                if (!dyingComplete)
                {
                    spriteBatch.Draw(dyingTexture, destinationRectangle, sourceRectangle, Color.White);
                }
                spriteBatch.End();
            }

            
        }
    
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

        public void TurnAround(string side)
        {
            // Have the Keese turn around based on what wall it is running into
                switch (side)
                {
                    case "top":
                        currDirection = Directions.DOWN;
                        break;
                    case "bottom":
                        currDirection = Directions.UP;
                        break;
                    case "left":
                        currDirection = Directions.RIGHT;
                        break;
                    case "right":
                        currDirection = Directions.LEFT;
                        break;
                    default:
                        break;

                }
        }

        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            isDead = true;
        }
        public ISprite DropItem()
        {
            if (dyingComplete)
            {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(xPosition, yPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }

        public void PoofIn(SpriteBatch spriteBatch) { }
    }
}

