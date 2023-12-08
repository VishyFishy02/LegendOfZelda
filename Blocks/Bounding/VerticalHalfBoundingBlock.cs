using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Blocks
{
    public class VerticalHalfBoundingBlock : IBoundingBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 170;

        public VerticalHalfBoundingBlock(Texture2D blockTexture, int x, int y)
        {
            texture = blockTexture;
            xPos = x;
            yPos = y;
            sourceRectangle = new Rectangle(3, 28, sourceWidth, sourceHeight);
            destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White * 0.00f);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

    }


}


