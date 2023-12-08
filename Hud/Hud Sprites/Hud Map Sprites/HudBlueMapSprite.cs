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
    public class HudBlueMapSprite : ISprite
    {
        private readonly Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private readonly int width = 48;
        private readonly int height = 28;
        private LinkLocationTracker tracker;
        private TriforceLocation triforce;
        
        public HudBlueMapSprite(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.sourceRectangle = new(697, 104, width, height);
            this.destinationRectangle = new(x, y, 168, 98);
            tracker = new LinkLocationTracker(texture, x, y);
            triforce = new TriforceLocation(texture, x, y);
            
        }

        public void Update()
        {
            tracker.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
            tracker.Draw(_spriteBatch);
            if (Link.Instance.inventory.getItemCount("compass") > 0)
            {
                triforce.Draw(_spriteBatch);
            }

        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

}