using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Sprites
{
    public class MasterSwordExplosionSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private readonly int maxFrames = 1600;
        private int timingCounter = 0;
        private int maxTime = 30;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        public int xPosition;
        public int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangleList = new();
        private List<List<Rectangle>> sourceRectanglesLists = new();
        Rectangle sourceRectangle = new Rectangle();
        List<Rectangle> brown = new(){
                new Rectangle(311, 150, 8, 10),
                new Rectangle(320, 150, 8, 10),
                new Rectangle(311, 161, 8, 10),
                new Rectangle(320, 161, 8, 10)
        };
        List<Rectangle> whiteAndBlue = new(){
                new Rectangle(330, 150, 8, 10),
                new Rectangle(339, 150, 8, 10),
                new Rectangle(330, 161, 8, 10),
                new Rectangle(339, 161, 8, 10)
        };
        List<Rectangle> whiteAndOrange = new(){
                new Rectangle(311, 174, 8, 10),
                new Rectangle(320, 174, 8, 10),
                new Rectangle(311, 185, 8, 10),
                new Rectangle(320, 185, 8, 10)
        };
        List<Rectangle> red = new(){
                new Rectangle(330, 174, 8, 10),
                new Rectangle(339, 174, 8, 10),
                new Rectangle(330, 185, 8, 10),
                new Rectangle(339, 185, 8, 10)
        };
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        private Rectangle topLeftDestination;
        private Rectangle topRightDestination;
        private Rectangle bottomLeftDestination;
        private Rectangle bottomRightDestination;
        private List<Rectangle> destinationRectangles;

        public MasterSwordExplosionSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition - 30;
            this.yPosition = (int)yPosition;
            isDone = false;
            sourceRectanglesLists.Add(brown);
            sourceRectanglesLists.Add(whiteAndBlue);
            sourceRectanglesLists.Add(whiteAndOrange);
            sourceRectanglesLists.Add(red);
            topLeftDestination = new Rectangle((int)xPosition, (int)yPosition, 16, 20);
            topRightDestination = new Rectangle((int)xPosition, (int)yPosition, 16, 20);
            bottomLeftDestination = new Rectangle((int)xPosition, (int)yPosition, 16, 20);
            bottomRightDestination = new Rectangle((int)xPosition, (int)yPosition, 16, 20);
            destinationRectangles = new() { 
                topLeftDestination, 
                topRightDestination, 
                bottomLeftDestination, 
                bottomRightDestination };
            }

        public void Update()
        {
            if (!isDone)
            {
                timingCounter++;
                if (timingCounter >= maxTime)
                {
                    isDone = true;
                }
                currFrames += 50;
                if ((currFrames / 100) % 4 == 0)
                {
                    sourceRectangleList = sourceRectanglesLists[0];
                }
                else if ((currFrames / 100) % 4 == 1)
                {
                    sourceRectangleList = sourceRectanglesLists[1];
                }
                else if ((currFrames / 100) % 4 == 2)
                {
                    sourceRectangleList = sourceRectanglesLists[2];
                }
                else if ((currFrames / 100) % 4 == 3)
                {
                    sourceRectangleList = sourceRectanglesLists[3];
                }
                else if (currFrames >= maxFrames)
                {
                    currFrames = 0;
                }
                updatePositions();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDone)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                for (int i = 0; i <= 3; i++)
                {
                    Debug.WriteLine(sourceRectangleList[0] + "  " + destinationRectangles[0]);

                    spriteBatch.Draw(texture, destinationRectangles[i], sourceRectangleList[i], Color.White);
                }
                spriteBatch.End();
            }

        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
        public void collide()
        {
        }

        private void updatePositions()
        {
            this.topLeftDestination.X -= 1;
            this.topLeftDestination.Y -= 1;

            this.topRightDestination.X += 1;
            this.topRightDestination.Y -= 1;

            this.bottomLeftDestination.X -= 1;
            this.bottomLeftDestination.Y += 1;

            this.bottomRightDestination.X += 1;
            this.bottomRightDestination.Y += 1;

            destinationRectangles = new() {
                topLeftDestination,
                topRightDestination,
                bottomLeftDestination,
                bottomRightDestination 
            };
        }
    }
}

