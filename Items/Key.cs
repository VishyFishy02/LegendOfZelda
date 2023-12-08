using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Items
{

    public class Key : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int width = 8;
        private int height = 16;

        public Key(Texture2D itemTexture, int x, int y)
        {
            texture = itemTexture;
            xPos = x;
            yPos = y;
            sourceRectangle = new Rectangle(240, 0, width, height);
            destinationRectangle = new Rectangle(xPos, yPos, (int)(width * 2.5), (int)(height * 2.5));
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

        public string toString()
        {
            return "key";
        }

    }


}
