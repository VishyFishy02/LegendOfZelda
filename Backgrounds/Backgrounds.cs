using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using GameStates;
using System.Diagnostics;
using CommonReferences;

namespace LegendofZelda
{

    public class Background : IBackground
    {
        private readonly Texture2D texture;

        private Rectangle sourceRectangle;
        private List<Rectangle> sourceRectangles;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        private readonly int width = 256;
        private readonly int height = 176;

        private readonly Vector2 backgroundLocation;
        private string direction;
        private bool transitioning;
        private bool spelunking;
        private int spelunkingFrames;
        private int maxSpelunkingFrames;
        private float tint;
        private List<float> tintList;
        private int roomNumber;
        public bool IsTransitioning { get => transitioning; }
        public Background(Texture2D backgroundTexture, int roomNumber)
        {
            texture = backgroundTexture;

            sourceRectangles = new();
            sourceRectangles.Add(new(515, 886, width, height));
            sourceRectangles.Add(new(258, 886, width, height));
            sourceRectangles.Add(new(772, 886, width, height));
            sourceRectangles.Add(new(515, 709, width, height));
            sourceRectangles.Add(new(515, 532, width, height));
            sourceRectangles.Add(new(258, 532, width, height));
            sourceRectangles.Add(new(772, 532, width, height));
            sourceRectangles.Add(new(515, 355, width, height));
            sourceRectangles.Add(new(258, 355, width, height));
            sourceRectangles.Add(new(1, 355, width, height));
            sourceRectangles.Add(new(772, 355, width, height));
            sourceRectangles.Add(new(1029, 355, width, height));
            sourceRectangles.Add(new(1029, 178, width, height));
            sourceRectangles.Add(new(1286, 178, width, height));
            sourceRectangles.Add(new(515, 178, width, height));
            sourceRectangles.Add(new(515, 1, width, height));
            sourceRectangles.Add(new(258, 1, width, height));
            sourceRectangles.Add(new(1, 1, width, height - 16));
            sourceRectangles.Add(new(258, 886, width, height));
            sourceRectangles.Add(new(772, 709, width, height)); //19
            for(int i = 0; i < Common.Instance.numOfRushRooms - 1; i++)
            {
                sourceRectangles.Add(new(772, 532, width, height)); //middle
            }
            sourceRectangles.Add(new(772,178, width, height)); //bullet hell room 21
            sourceRectangles.Add(new(772,1, width, height)); //master sword room 22

            sourceRectangle = sourceRectangles[roomNumber];
            backgroundLocation = new(sourceRectangle.X, sourceRectangle.Y);
            destinationRectangle = new(0, Common.Instance.heightOfInventory, 800, 480);
            direction = "";
            maxSpelunkingFrames = 100;
            tintList = new()
            {
                0.2f, 0.4f, 0.6f,  1, 0.6f, 0.3f, 0
            };
            this.roomNumber = roomNumber;

        }

        public void SetTransitionDirection(String direction)
        {
            this.direction = direction;
            transitioning = true;
            switch (direction)
            {
                case "right":
                    sourceRectangle.Offset(-width, 0);
                    break;
                case "left":
                    sourceRectangle.Offset(width, 0);
                    break;
                case "up":
                    sourceRectangle.Offset(0, height);
                    break;
                case "down":
                    sourceRectangle.Offset(0, -height);
                    break;
                case "cave":
                    spelunking = true;
                    break;
            }
        }

        public void Update()
        {
            if (spelunking)
            {
                Spelunk();
            }
            else
            {
                NormalRoomTransition();
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (spelunking)
            {
                _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.Lerp(Color.White, Color.Black, tint));
            }
            else
            {
                _spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
            }
            _spriteBatch.End();
        }

        //helper mehthods
        private void Spelunk()
        {
            spelunkingFrames++;
            for (int i = 0; i < 6; i++)
            {
                if (spelunkingFrames > i * maxSpelunkingFrames / 6 && spelunkingFrames <= (i + 1) * maxSpelunkingFrames / 6)
                {
                    tint = tintList[i];
                 
                    if (i < 4)
                    {
                        if (roomNumber == 16)
                        {
                            sourceRectangle = sourceRectangles[17];
                        }
                        else if (roomNumber == 9)
                        {
                            sourceRectangle = new Rectangle(sourceRectangles[9].X, sourceRectangles[9].Y- sourceRectangles[9].Height, sourceRectangles[9].Width, sourceRectangles[9].Height);
                        }
                        else
                        {
                            sourceRectangle = sourceRectangles[roomNumber - 1];
                        }
                    }
                    else
                    {
                        sourceRectangle = sourceRectangles[roomNumber];
                    }
                }
                else if (spelunkingFrames > maxSpelunkingFrames)
                {
                    tint = 0;
                    spelunking = false;
                    transitioning = false;
                    spelunkingFrames = 0;
                }
            }
        }

        private void NormalRoomTransition()
        {
            if (!(sourceRectangle.X == backgroundLocation.X && sourceRectangle.Y == backgroundLocation.Y))
            {
                switch (direction)
                {
                    case "left":
                        sourceRectangle.Offset(-1, 0);
                        break;
                    case "right":
                        sourceRectangle.Offset(1, 0);
                        break;
                    case "up":
                        sourceRectangle.Offset(0, -1);
                        break;
                    case "down":
                        sourceRectangle.Offset(0, 1);
                        break;
                }
            }
            else
            {
                transitioning = false;
            }
        }
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }
    }
}










