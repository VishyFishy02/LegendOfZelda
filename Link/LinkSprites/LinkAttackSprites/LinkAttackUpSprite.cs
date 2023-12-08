using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Sprites
{
    public class LinkAttackUpSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;

        // Texture to take sprites from
        private Texture2D texture;
        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // to know whether or not to dye sprite red.
        private bool isDamaged;

        // Represents if the sprite has done one full attack cycle
        private bool isAttack;

        public string side = "top";

        // Where this will be drawn on screen
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private List<Rectangle> masterSwordSourceRectangles;
        private int currentFrameIndex;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkAttackUpSprite(Texture2D texture, float xPos, float yPos, bool isDamaged)
        {
            this.texture = texture;
            xPosition = (int)xPos;
            yPosition = (int)yPos;
            this.isDamaged = isDamaged;
            isAttack = true;
            sourceRectangles = new List<Rectangle>
            {
                new Rectangle(1, 109, 16, 16),
                new Rectangle(18, 97, 16, 28),
                new Rectangle(37, 98, 12, 27),
                new Rectangle(54, 106, 12, 19)
            };

            masterSwordSourceRectangles = new List<Rectangle> { 
                new Rectangle(94, 109, 16, 16),
                new Rectangle(111, 97, 16, 28),
                new Rectangle(130, 98, 12, 27),
                new Rectangle(147, 106, 12, 19)
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
            if(currFrames >= 0 && currFrames <= maxFrames/4)
            {
                currentFrameIndex = 0;
            } 
            else if (currFrames > currFrames/4 && currFrames <= 2*maxFrames/4)
            {
                currentFrameIndex = 1;
            } 
            else if (currFrames > 2*maxFrames/4 && currFrames <= 3*maxFrames/4)
            {
                currentFrameIndex = 2;
            } 
            else if (currFrames > 3*maxFrames/4 && currFrames <= maxFrames)
            {
                currentFrameIndex = 3;
            }

            Rectangle currentFrame = new();
            if (Link.Instance.masterSwordEquipped) {
                 currentFrame = masterSwordSourceRectangles[currentFrameIndex];
            } else
            {
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

