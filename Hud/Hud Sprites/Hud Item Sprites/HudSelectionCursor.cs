using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using LegendofZelda.Interfaces;
using System.Diagnostics;

namespace Sprites
{
    public class HudSelectionCursor : ISprite
    {
        private readonly Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private readonly int width = 16;
        private readonly int height = 16;
        private int frameCounter = 0;


        public HudSelectionCursor(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.sourceRectangle = new(519, 137, width, height);
            this.destinationRectangle = new(x, y, width * 3, height * 3);
        }

        public void Update()
        {
            frameCounter += 1;
            if ((frameCounter / 10) % 2 == 0)
            {
                sourceRectangle = new Rectangle(519, 137, width, height);
            } else
            {
                sourceRectangle = new Rectangle(536, 137, width, height);
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }


        public void Offset(int x, int y)
        {
            this.DestinationRectangle = new(x, y, width * 4, height * 4);
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