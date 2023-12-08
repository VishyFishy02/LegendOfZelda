using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class TriforceLocation : ISprite
    {
        private readonly Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private readonly int width = 1;
        private readonly int height = 1;
        private Vector2 location;

        public TriforceLocation(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.sourceRectangle = new(306, 105, width, height);
            this.location = new Vector2(x + 150, y + 16);
            this.destinationRectangle = new((int)this.location.X, (int)this.location.Y, width * 6, height * 6);
        }

        public void Update()
        {
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.HotPink);
            _spriteBatch.End();
        }

        public void setPos(int x, int y)
        {
            this.DestinationRectangle = new(x, y, width * 4, height * 4);
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

}