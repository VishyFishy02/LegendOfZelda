using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Blocks
{
    public class LockedWhiteDoorBlock : IBlock
    {
        private Texture2D texture;
        
        private static int sourceWidth = 32;
        private static int sourceHeight = 22;
        private int destinationWidth = sourceWidth * 3;
        private int destinationHeight = sourceHeight * 3;

        private Rectangle[] sourceRectangles = { 
            new Rectangle(103, 21, sourceWidth, sourceHeight), 
            new Rectangle(115, 44, sourceHeight, sourceWidth), 
            new Rectangle(103, 77, sourceHeight, sourceWidth), 
            new Rectangle(103, 110, sourceWidth, sourceHeight) };
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        
        private int direction;

        public LockedWhiteDoorBlock(Texture2D doorTexture, int x, int y, int direction)
        {
            texture = doorTexture;
  
            this.direction = direction;
            // for source rectangles 0 = top, 1 = left, 2 = right, 3 = bottom
            sourceRectangle = sourceRectangles[direction];

            if (direction == 0 || direction == 3)
                destinationRectangle = new Rectangle(x, y, destinationWidth, destinationHeight);
            else
                destinationRectangle = new Rectangle(x, y, destinationHeight, destinationWidth);
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
        public string getSide()
        {
            switch (direction)
            {
                case 0:
                    return "top";
                case 1:
                    return "left";
                case 2:
                    return "right";
                case 3:
                    return "bottom";
                default:
                    return "INVALID DIRECTION NUM PASSED";
            }
        }
    }
}


