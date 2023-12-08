using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Blocks
{
    public class PlainDarkBlueBlock : INonBoundingBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 15;
        private int sourceHeight = 15;
        private int destinationWidth = 50;
        private int destinationHeight = 44;

        public PlainDarkBlueBlock(Texture2D blockTexture, int x, int y)
        {
            texture = blockTexture;
            xPos = x;
            yPos = y;
            sourceRectangle = new Rectangle(38, 29, sourceWidth, sourceHeight);
            destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }


}


