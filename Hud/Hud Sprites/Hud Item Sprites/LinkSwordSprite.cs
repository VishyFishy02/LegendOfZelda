using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprites;
using LegendofZelda.Interfaces;
using LegendofZelda;

namespace Sprites
{
    public class LinkSwordSprite : ISprite
    {
        private readonly Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle masterSwordSourceRectangle;
        private Rectangle destinationRectangle;
        private Rectangle currSourceRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private readonly int width = 8;
        private readonly int height = 16;


        public LinkSwordSprite(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.sourceRectangle = new(555, 137, width, height);
            this.masterSwordSourceRectangle = new(564, 137, width, height);
            this.currSourceRectangle = sourceRectangle;
            this.destinationRectangle = new(x, y, width * 4, height * 4);
        }

        public void Update()
        {

        }
        public void Draw(SpriteBatch _spriteBatch) { 
            if (Link.Instance.masterSwordEquipped)
            {
                this.currSourceRectangle = masterSwordSourceRectangle;
            }
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, currSourceRectangle, Color.White);
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