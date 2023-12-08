using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Backgrounds
{
    public class GameOverScreen : ISprite
    {
        private readonly Texture2D texture;

        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        
        private readonly int width = 800;
        private readonly int height = 480;

        public GameOverScreen(Texture2D backgroundTexture)
        {
            texture = backgroundTexture;
            sourceRectangle = new(0,0, width, height);
            destinationRectangle = new(0, 150, width, height);
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










