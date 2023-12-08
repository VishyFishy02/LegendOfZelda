using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Items
{
    public class Triforce : IItem
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int width = 10;
        private int height = 10;
        private int currFrames = 0;
        
        public Triforce(Texture2D itemTexture, int x, int y)
        {
            texture = itemTexture;
            xPos = x;
            yPos = y;
            sourceRectangle = new Rectangle(275, 19, width, height);
            destinationRectangle = new Rectangle(xPos, yPos, width * 3, height * 3);
        }

        public void Update()
        {
            currFrames++;
            if ((currFrames / 10) % 2 == 0)
            {
                sourceRectangle = new Rectangle(275, 19, width, height);
            } else
            {
                sourceRectangle = new Rectangle(275, 3, width, height);
            }
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
            return "triforce";
        }
    }


}
