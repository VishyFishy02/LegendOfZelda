using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace LegendofZelda.Items
{
    public class MasterSword : IItem
    {
        // frame count for animating the sword
        private int currFrames = 0;

        private Texture2D texture;
        private Rectangle sourceRectangle1;
        private Rectangle sourceRectangle2;
        private Rectangle destinationRectangle1;
        private Rectangle destinationRectangle2;
        private Rectangle currDestinationRectangle;
        public Rectangle DestinationRectangle { get => currDestinationRectangle; set => currDestinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int width = 7;
        private int height = 16;

        public MasterSword(Texture2D itemTexture, int x, int y)
        {
            texture = itemTexture;
            xPos = x;
            yPos = y;
            sourceRectangle1 = new Rectangle(104, 16, width, height);
            sourceRectangle2 = new Rectangle(114, 16, 1, height);
            destinationRectangle1 = new Rectangle(xPos, yPos, width * 3, height * 3);
            destinationRectangle2 = new Rectangle((xPos + 9), yPos, (1 * 3), height * 3);
            currDestinationRectangle = destinationRectangle1;
        }

        public void Update()
        {
            currFrames += 1;
            if (currFrames >= 100)
            {
                currFrames = 0;
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            if (currFrames <= 50)
            {
                currDestinationRectangle = destinationRectangle1;
                _spriteBatch.Draw(texture, currDestinationRectangle, sourceRectangle1, Color.White);
            }
            else
            {
                currDestinationRectangle = destinationRectangle2;
                _spriteBatch.Draw(texture, currDestinationRectangle, sourceRectangle2, Color.White);
            }


            _spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle1;
        }

        public string toString()
        {
            return "master sword";
        }
    }


}
