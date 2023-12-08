using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Sprites
{
    public class LinkAttackDownSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        public Texture2D texture;
        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Is this sprite currently in its attacking cycle
        private bool isAttack;

        public string side = "bottom";

        // Location on screen
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private List<Rectangle> masterSwordSourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkAttackDownSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            xPosition = (int)xPos;
            yPosition = (int)yPos;
            this.isDamaged = isDamaged;
            isAttack = true;
            sourceRectangles = new List<Rectangle>
            {
                new Rectangle(1, 47, 16, 15),
                new Rectangle(18, 47, 16, 27),
                new Rectangle(35, 47, 15, 23),
                new Rectangle(53, 47, 13, 19)
            };
            masterSwordSourceRectangles = new List<Rectangle> { 
                new Rectangle(94, 47, 16, 16),
                new Rectangle(111, 47, 16, 27),
                new Rectangle(128, 47, 15, 23),
                new Rectangle(146, 47, 13, 19)
            };
            currentFrameIndex = 0;
        }
        public void Update()
        {
            // Update frames
            currFrames += 35;

            // If frames are past max,no longer attacking
            if (currFrames >= maxFrames)
            {
                isAttack = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Frame logic
            if (currFrames >= 0 && currFrames <= maxFrames / 4)
            {
                currentFrameIndex = 0;
            }
            else if (currFrames > currFrames / 4 && currFrames <= 2 * maxFrames / 4)
            {
                currentFrameIndex = 1;
            }
            else if (currFrames > 2 * maxFrames / 4 && currFrames <= 3 * maxFrames / 4)
            {
                currentFrameIndex = 2;
            }
            else if (currFrames > 3 * maxFrames / 4 && currFrames <= maxFrames)
            {
                currentFrameIndex = 3;
            }

            Rectangle currentFrame = new();
            if (Link.Instance.masterSwordEquipped)
            {
                currentFrame = masterSwordSourceRectangles[currentFrameIndex];
            } else {
                currentFrame = sourceRectangles[currentFrameIndex];
            }
            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, new Vector2(currentFrame.Width / 2, currentFrame.Height / 2), SpriteEffects.None, 1);
            }
            spriteBatch.End();
        }
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
        public bool isAttacking()
        {
            return isAttack;
        }
        public string getSide()
        {
            return side;
        }
    }
}

