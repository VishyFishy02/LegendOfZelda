using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class LinkDyingSprite : INonAttackingSprite
    {
        // Texture to take sprites from
        private readonly Texture2D texture;
        private Texture2D dyingTexture;

        // Keep track of frames
        private int frameCounter = 0;
        private int timingCounter = 0;
        private int maxFrames = 20;
        private int deathFrames = 0;

        public bool isComplete = false;
        private Color color = Color.White;

        // X and Y positions of the sprite
        private readonly int xPosition;
        private readonly int yPosition;

        // Get information about screen dimensions
        private Rectangle sourceRectangle;

        // Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X - (destinationRectangle.Width / 2), destinationRectangle.Y - (destinationRectangle.Height / 2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value; }
        public Vector2 Position { get => new(xPosition, yPosition); }

        public LinkDyingSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            xPosition = (int)xPosition;
            yPosition = (int)yPosition;
            dyingTexture = texture2;

            // Create source and destination rectangles
            sourceRectangle = new Rectangle(1, 11, 15, 16); // Store the current location on the spritesheet to get a sprite from
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, sourceRectangle.Width * 2, sourceRectangle.Height * 2); // Where to draw on screen
        }
        public void Update()
        {
            if (timingCounter < 100)
            {
                timingCounter++;
                frameCounter++;
                if (frameCounter >= 0 && frameCounter < maxFrames / 4)
                {
                    sourceRectangle = new Rectangle(1, 11, 15, 16); 
                } else if (frameCounter >= maxFrames / 4 && frameCounter < maxFrames / 2)
                {
                    sourceRectangle = new Rectangle(35, 11, 15, 16);
                } else if (frameCounter >= maxFrames / 2 && frameCounter < maxFrames * 3 / 4)
                {
                    sourceRectangle = new Rectangle(71, 11, 12, 16); 
                } else if (frameCounter >= maxFrames * 3 / 4 && frameCounter < maxFrames)
                {
                    sourceRectangle = new Rectangle(35, 11, 15, 16); 
                } else
                {
                    frameCounter = 0;
                }
            } else
            {
                deathFrames++;
                if (deathFrames >= 0 && deathFrames <= 5)
                {
                    sourceRectangle = new Rectangle(0, 0, 15, 16);
                }
                else if (deathFrames > 5 && deathFrames < 10)
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

                } else if (deathFrames >= 20)
                {
                    isComplete = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (timingCounter < 100)
            {
                if (frameCounter >= maxFrames / 4 && frameCounter < maxFrames / 2)
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), SpriteEffects.FlipHorizontally, 1);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), SpriteEffects.None, 1);
                }
            } else
            {
                if (!isComplete)
                {
                    spriteBatch.Draw(dyingTexture, destinationRectangle, sourceRectangle, color, 0, new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), SpriteEffects.FlipHorizontally, 1);
                }
            }
            spriteBatch.End();
        }
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }
}