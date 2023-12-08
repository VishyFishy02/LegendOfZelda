using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class LinkFacingDownSprite : INonAttackingSprite
    {
        // Texture to take sprites from
        private readonly Texture2D texture;

        // X and Y positions of the sprite
        private readonly int xPosition;
        private readonly int yPosition;

        private Color color = Color.White;
        private bool isDamaged;

        // Get information about screen dimensions
        private Rectangle sourceRectangle;

        // Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => new Rectangle(destinationRectangle.X-(destinationRectangle.Width/2), destinationRectangle.Y-(destinationRectangle.Height/2), destinationRectangle.Width, destinationRectangle.Height); set => destinationRectangle = value;}
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkFacingDownSprite(Texture2D texture, float xPosition, float yPosition, bool isDamaged)
        {
            this.texture = texture;
            xPosition = (int)xPosition;
            yPosition = (int)yPosition;
            this.isDamaged = isDamaged;

            // Create source and destination rectangles
            sourceRectangle = new Rectangle(1, 11, 15, 16); // Store the current location on the spritesheet to get a sprite from
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, sourceRectangle.Width*2, sourceRectangle.Height*2); // Where to draw on screen
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (isDamaged)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.3f), 0, new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), SpriteEffects.None, 1);
            } else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(sourceRectangle.Width / 2, sourceRectangle.Height / 2), SpriteEffects.None, 1);
            }
            spriteBatch.End();
        }
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }
}