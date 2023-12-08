using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class LinkThrowingUpSprite : IAttackingSprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 500;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        private bool isDamaged;

        // Is current sprite done with one attack cycle
        private bool isAttack;

        public string side = "top";

        // Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X - (destinationRectangle.Width / 2), destinationRectangle.Y - (destinationRectangle.Height / 2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value; }
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkThrowingUpSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.isDamaged = isDamaged;
            this.isAttack = true;
        }

        public void Update()
        {
            // Update frames
            currFrames += 50;

            // If frames are past max, no longer attacking
            if (currFrames > maxFrames)
            {
                isAttack = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle currentFrame = new();

            // Draw the first step of link walking up

            currentFrame = new Rectangle(141, 11, 16, 16);

            destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2); // Where to draw on screen
            // Draw the sprite
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
            return this.destinationRectangle;
        }

        public bool isAttacking()
        {
            return isAttack;
        }

        public string getSide()
        {
            return this.side;
        }
    }
}



