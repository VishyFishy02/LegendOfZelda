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
    public class LinkLocationTracker : ISprite
    {
        private readonly Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private readonly int width = 1;
        private readonly int height = 1;
        private List<Vector2> linkLocations = new();
        private Vector2 location;

        public LinkLocationTracker(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            this.sourceRectangle = new(340, 80, width, height);
            
            linkLocations.Add(new Vector2(x + 66, y + 72)); //room 0
            linkLocations.Add(new Vector2(x + 38, y + 72)); //room 1
            linkLocations.Add(new Vector2(x + 94, y + 72)); //room 2
            linkLocations.Add(new Vector2(x + 66, y + 58)); //room 3
            linkLocations.Add(new Vector2(x + 66, y + 44)); //room 4
            linkLocations.Add(new Vector2(x + 38, y + 44)); //room 5
            linkLocations.Add(new Vector2(x + 94, y + 44)); //room 6
            linkLocations.Add(new Vector2(x + 66, y + 30)); //room 7
            linkLocations.Add(new Vector2(x + 38, y + 30)); //room 8
            linkLocations.Add(new Vector2(x + 10, y + 30)); //room 9
            linkLocations.Add(new Vector2(x + 94, y + 30)); //room 10
            linkLocations.Add(new Vector2(x + 122, y + 30)); //room 11
            linkLocations.Add(new Vector2(x + 122, y + 16)); //room 12
            linkLocations.Add(new Vector2(x + 150, y + 16)); //room 13
            linkLocations.Add(new Vector2(x + 66, y + 16)); //room 14
            linkLocations.Add(new Vector2(x + 66, y + 2)); //room 15
            linkLocations.Add(new Vector2(x + 38, y + 2)); //room 16
            linkLocations.Add(new Vector2(x + 38, y + 2)); //room 17


            if (Link.Instance.game.currentRoomIndex < 18)
            {
                location = linkLocations[Link.Instance.game.currentRoomIndex];
            }
            this.destinationRectangle = new((int)this.location.X, (int)this.location.Y, width * 6, height * 6);
        }

        public void Update()
        {
            if (Link.Instance.game.currentRoomIndex < 18)
            {
                location = linkLocations[Link.Instance.game.currentRoomIndex];
            }
            this.destinationRectangle = new((int)this.location.X, (int)this.location.Y, width * 6, height * 6);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }

}