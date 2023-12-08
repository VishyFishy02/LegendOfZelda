using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class HudFireSprite : ISprite
    {
        private readonly Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private readonly int width = 16;
        private readonly int height = 16;


        public HudFireSprite(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.sourceRectangle = new(191, 185, 16, 16);
            this.destinationRectangle = new(x, y, width * 2, height * 2);
        }

        public void Update()
        {

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
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