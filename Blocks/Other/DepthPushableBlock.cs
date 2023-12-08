using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using System;
using System.Diagnostics;

namespace LegendofZelda.Blocks
{
    public class DepthPushableBlock : IPushableBlock
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private int xPos;
        private int yPos;
        private int sourceWidth = 16;
        private int sourceHeight = 16;
        private int destinationWidth = 50;
        private int destinationHeight = 44;
        private int triggerPosition;
        public Boolean isPushed;

        public DepthPushableBlock(Texture2D blockTexture, int x, int y)
        {
            texture = blockTexture;
            xPos = x;
            yPos = y;
            sourceRectangle = new Rectangle(20, 11, sourceWidth, sourceHeight);
            destinationRectangle = new Rectangle(xPos, yPos, destinationWidth, destinationHeight);
            this.isPushed = false;
            triggerPosition = y-44;
        }

        public void Update()
        {
            if (yPos == triggerPosition) // 50 is the height of one block
            {
                this.isPushed = true;
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

        public void Move(string side)
        {
            switch (side)
            {
                case "top":
                    yPos += 2;
                    destinationRectangle = new(xPos, yPos, destinationWidth, destinationHeight);
                    break;
                case "bottom":
                    yPos -= 2;
                    destinationRectangle = new(xPos, yPos, destinationWidth, destinationHeight);
                    break;
                case "left":
                    xPos += 2;
                    destinationRectangle = new(xPos, yPos, destinationWidth, destinationHeight);
                    break;
                case "right":
                    xPos -= 2;
                    destinationRectangle = new(xPos, yPos, destinationWidth, destinationHeight);
                    break;
                default:
                    break;
            }
        }
    }


}


