using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Backgrounds
{
    public class WinGameScreen : ISprite
    {
        private readonly Texture2D texture;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        private int xPos;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        
        private readonly int width = 800;
        private readonly int height = 480;

        public WinGameScreen(Texture2D backgroundTexture)
        {
            texture = backgroundTexture;
            sourceRectangle = new(0,0, 10, 10);
            xPos = -800;
            destinationRectangle = new(xPos, 150, width, height);
        }

        public void Update()
        {
            if (xPos < 0)
            {
                xPos += 5;
            }
            destinationRectangle = new(xPos, 150, width, height);
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










