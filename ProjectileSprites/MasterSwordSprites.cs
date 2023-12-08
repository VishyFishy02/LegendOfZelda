using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprites
{
    public class MasterSwordUpSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 1600;
        private int timingCounter = 0;
        private int maxTime = 120;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public int xPosition;
        public int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private Rectangle sourceRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        private int explosionCreationCount = 1;
        private ISprite masterSwordExplosion;
        private bool throwDone=false;

        public MasterSwordUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition - 8;
            this.yPosition = (int)yPosition - 30;
            isDone = false;
            sourceRectangles = new()
            {
                new Rectangle(1, 154, 7, 16),
                new Rectangle(36, 154, 7, 16),
                new Rectangle(71, 154, 7, 16),
                new Rectangle(106, 154, 7, 16)
            };
            this.destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 14, 32);
        }

        public void Update()
        {
            timingCounter++;

            // Update frames
            if (!throwDone)
            {
                if (timingCounter >= 90)
                {
                    throwDone= true;
                    if (explosionCreationCount > 0)
                    {
                        masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                        explosionCreationCount--;
                    }
                }
                currFrames += 1;
                this.yPosition -= 2;
                this.destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 14, 32);
                if ((currFrames / 10) % 4 == 0)
                {
                    sourceRectangle = sourceRectangles[0];
                } else if ((currFrames / 10) % 4 == 1)
                {
                    sourceRectangle = sourceRectangles[1];
                } else if ((currFrames / 10) % 4 == 2)
                {
                    sourceRectangle = sourceRectangles[2];
                } else if ((currFrames / 10) % 4 == 3)
                {
                    sourceRectangle = sourceRectangles[3];
                } else if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }
            } else
            {
                if (masterSwordExplosion!= null) 
                    masterSwordExplosion.Update();
                if (timingCounter >= maxTime)
                {
                    isDone = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!throwDone)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            } else
            {
                if (masterSwordExplosion!= null)
                    masterSwordExplosion.Draw(spriteBatch);
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.throwDone = true;
            if (explosionCreationCount > 0)
            {
                masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                explosionCreationCount--;
            }
        }


    }

    public class MasterSwordDownSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 1600;
        private int timingCounter = 0;
        private int maxTime = 120;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        Rectangle sourceRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        private int explosionCreationCount = 1;
        private ISprite masterSwordExplosion;
        private bool throwDone = false;
        public MasterSwordDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition - 8;
            this.yPosition = (int)yPosition;
            isDone = false;
            sourceRectangles = new()
            {
                new Rectangle(1, 154, 7, 16),
                new Rectangle(36, 154, 7, 16),
                new Rectangle(71, 154, 7, 16),
                new Rectangle(106, 154, 7, 16)
            };

        }

        public void Update()
        {
            timingCounter++;

            // Update frames
            if (!throwDone)
            {
                if (timingCounter >= 90)
                {
                    throwDone = true;
                    //if (explosionCreationCount > 0)
                    //{
                        masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                        explosionCreationCount--;
                    //}
                }
                currFrames += 1;
                this.yPosition += 2;
                this.destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 14, 32);
                if ((currFrames / 10) % 4 == 0)
                {
                    sourceRectangle = sourceRectangles[0];
                }
                else if ((currFrames / 10) % 4 == 1)
                {
                    sourceRectangle = sourceRectangles[1];
                }
                else if ((currFrames / 10) % 4 == 2)
                {
                    sourceRectangle = sourceRectangles[2];
                }
                else if ((currFrames / 10) % 4 == 3)
                {
                    sourceRectangle = sourceRectangles[3];
                }
                else if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }
            }
            else
            {
                if (masterSwordExplosion != null)
                    masterSwordExplosion.Update();
                if (timingCounter >= maxTime)
                {
                    isDone = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!throwDone)
            {

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipVertically, 1);
                spriteBatch.End();
            }
            else
            {
                if (masterSwordExplosion != null)
                    masterSwordExplosion.Draw(spriteBatch);
            }
        }
        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.throwDone = true;
            if (explosionCreationCount > 0)
            {
                masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                explosionCreationCount--;
            }
        }

    }


    public class MasterSwordRightSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 1600;
        private int timingCounter = 0;
        private int maxTime = 120;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;
        public bool isDamaged;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;

        Rectangle sourceRectangle = new Rectangle();

        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        private int explosionCreationCount = 1;
        private ISprite masterSwordExplosion;
        private bool throwDone = false;
        public MasterSwordRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition - 3;
            isDone = false;
            sourceRectangles = new()
            {
                new Rectangle(10, 159, 16, 7),
                new Rectangle(45, 159, 16, 7),
                new Rectangle(80, 159, 16, 7),
                new Rectangle(115, 159, 16, 7)
            };

        }

        public void Update()
        {
            timingCounter++;

            // Update frames
            if (!throwDone)
            {
                if (timingCounter >= 90)
                {
                    throwDone = true;
                    if (explosionCreationCount > 0)
                    {
                        masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                        explosionCreationCount--;
                    }
                }
                currFrames += 1;
                this.xPosition += 2;
                this.destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 14);
                if ((currFrames / 10) % 4 == 0)
                {
                    sourceRectangle = sourceRectangles[0];
                }
                else if ((currFrames / 10) % 4 == 1)
                {
                    sourceRectangle = sourceRectangles[1];
                }
                else if ((currFrames / 10) % 4 == 2)
                {
                    sourceRectangle = sourceRectangles[2];
                }
                else if ((currFrames / 10) % 4 == 3)
                {
                    sourceRectangle = sourceRectangles[3];
                }
                else if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }
            }
            else
            {
                if (masterSwordExplosion != null)
                    masterSwordExplosion.Update();
                if (timingCounter >= maxTime)
                {
                    isDone = true;
                }
            }
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!throwDone)
            {

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            } else
                {
                    if (masterSwordExplosion != null)
                        masterSwordExplosion.Draw(spriteBatch);
                }
            
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;

        }

        public void collide()
        {
            this.throwDone = true;
            if (explosionCreationCount > 0)
            {
                masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                explosionCreationCount--;
            }
        }


    }


    public class MasterSwordLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 1600;
        private int timingCounter = 0;
        private int maxTime = 120;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        Rectangle sourceRectangle = new Rectangle();

        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        private int explosionCreationCount = 1;
        private ISprite masterSwordExplosion;
        private bool throwDone = false;
        public MasterSwordLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition - 30;
            this.yPosition = (int)yPosition - 3;
            isDone = false;
            sourceRectangles = new()
            {
                new Rectangle(10, 159, 16, 7),
                new Rectangle(45, 159, 16, 7),
                new Rectangle(80, 159, 16, 7),
                new Rectangle(115, 159, 16, 7)
            };
        }

        public void Update()
        {
            timingCounter++;

            // Update frames
            if (!throwDone)
            {
                if (timingCounter >= 90)
                {
                    throwDone = true;
                    if (explosionCreationCount > 0)
                    {
                        masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                        explosionCreationCount--;
                    }
                }
                currFrames += 1;
                this.xPosition -= 2;
                this.destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 14);
                if ((currFrames / 10) % 4 == 0)
                {
                    sourceRectangle = sourceRectangles[0];
                }
                else if ((currFrames / 10) % 4 == 1)
                {
                    sourceRectangle = sourceRectangles[1];
                }
                else if ((currFrames / 10) % 4 == 2)
                {
                    sourceRectangle = sourceRectangles[2];
                }
                else if ((currFrames / 10) % 4 == 3)
                {
                    sourceRectangle = sourceRectangles[3];
                }
                else if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }
            }
            else
            {
                if (masterSwordExplosion != null)
                    masterSwordExplosion.Update();
                if (timingCounter >= maxTime)
                {
                    isDone = true;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (!throwDone)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                spriteBatch.End();
            }
            else
            {
                if (masterSwordExplosion != null)
                    masterSwordExplosion.Draw(spriteBatch);
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
        public void collide()
        {
            this.throwDone = true;
            if (explosionCreationCount > 0)
            {
                masterSwordExplosion = ProjectileSpriteFactory.Instance.CreateMasterSwordExplosion(new Vector2(xPosition, yPosition));
                explosionCreationCount--;
            }
        }

    }
}

