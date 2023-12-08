using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using LegendofZelda;

namespace Sprites
{
    public class LinkWinningSprite : INonAttackingSprite
    {
        // Texture to take sprites from
        private readonly Texture2D texture;

        // X and Y positions of the sprite
        private readonly int xPosition;
        private readonly int yPosition;

        private Color color = Color.White;

        private Rectangle linkSourceRectangle;
        
        private Rectangle linkDestinationRectangle;
        private ISprite triforce; 

        public Rectangle DestinationRectangle { get => new Rectangle(linkDestinationRectangle.X - (linkDestinationRectangle.Width / 2), linkDestinationRectangle.Y - (linkDestinationRectangle.Height / 2), linkDestinationRectangle.Width, linkDestinationRectangle.Height); set => linkDestinationRectangle = value; }
        public Vector2 Position { get => new(xPosition, yPosition); }
        public LinkWinningSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            
            triforce = ItemSpriteFactory.Instance.CreateItem(new Vector2(Link.Instance.currentPosition.X - Link.Instance.currentLinkSprite.DestinationRectangle.Width/2, Link.Instance.currentPosition.Y - 150 - Link.Instance.currentLinkSprite.DestinationRectangle.Height - 15), "Triforce");
            // Create source and destination rectangles
            linkSourceRectangle = new Rectangle(231, 11, 14, 16); // Store the current location on the spritesheet to get a sprite from
            linkDestinationRectangle = new Rectangle(this.xPosition, this.yPosition, linkSourceRectangle.Width * 2, linkSourceRectangle.Height * 2); // Where to draw on screen

    }
        public void Update()
        {
            triforce.Update();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, linkDestinationRectangle, linkSourceRectangle, color, 0, new Vector2(linkSourceRectangle.Width / 2, linkSourceRectangle.Height / 2), SpriteEffects.None, 1);
            
            spriteBatch.End();
            triforce.Draw(spriteBatch);
        }

        public Rectangle GetHitbox()
        {
            return linkDestinationRectangle;
        }
    }
}