using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;
using LegendofZelda;
using System.Diagnostics;
using System.ComponentModel.Design.Serialization;
using System.Collections.Generic;

namespace Sprites
{
    public class TrapSprite : IEnemy
    {

        // Texture to take sprites from
        private Texture2D texture;

        private int poofCounter = 0;
        private int maxPoofCounter = 15;
        private List<Rectangle> poofRectangles = new() { new Rectangle(235, 204, 16, 16), new Rectangle(252, 204, 16, 16), new Rectangle(269, 204, 16, 16) };


        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        // Determine what the trap should do depending on if link is within its vicinity
        private enum TrapStates {Sitting, MoveUp, MoveDown, MoveRight, MoveLeft};
        private TrapStates trapState;

        private Rectangle initialLocation;
        private Rectangle lastLocation;
        // Location on screen
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public TrapSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 32);
            this.trapState = TrapStates.Sitting;
            this.initialLocation = destinationRectangle;
           
        }

        public void Update()
        {
            if (poofCounter >= maxPoofCounter)
            {
                Vector2 linkLocation = Link.Instance.currentPosition;

                // Compare to link's position if its just sitting
                if (trapState == TrapStates.Sitting)
                {

                    // Change to a new state by comparing link's position to the trap
                    swapState(linkLocation);

                    // If no longer sitting, change the final location
                    if (trapState != TrapStates.Sitting)
                    {
                        this.lastLocation = new Rectangle((int)linkLocation.X, (int)linkLocation.Y, 12, 16);
                    }
                }
                else
                {
                    // Change location based on the current state and last location
                    TrapStates currState = trapState;

                    if (currState == TrapStates.MoveUp)
                    {
                        yPosition -= 2;

                    }
                    else if (currState == TrapStates.MoveDown)
                    {
                        yPosition += 2;


                    }
                    else if (currState == TrapStates.MoveLeft)
                    {
                        xPosition -= 2;


                    }
                    else if (currState == TrapStates.MoveRight)
                    {
                        xPosition += 2;
                    }
                }
            }
            else
            {
                poofCounter++;
                for (int i = 0; i < poofRectangles.Count; i++)
                {
                    if (poofCounter > i * maxPoofCounter / poofRectangles.Count && poofCounter <= (i + 1) * maxPoofCounter / poofRectangles.Count)
                    {
                        sourceRectangle = poofRectangles[i];
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (poofCounter >= maxPoofCounter)
            {
                sourceRectangle = new Rectangle(164, 59, 16, 16);
            }
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 32);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

            
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

        public void TurnAround(string side)
        {
            trapState = TrapStates.Sitting;
        }

        public void TakeDamage(string side)
        {

        }

        public ISprite DropItem()
        {
            return null;
        }

        private void swapState(Vector2 linkLocation)
        {
           int xRange = (int)Math.Abs(linkLocation.X - xPosition);
           int yRange = (int)Math.Abs(linkLocation.Y - YPosition);
           if(xRange <= 20 && linkLocation.Y < YPosition)
            {                
                trapState = TrapStates.MoveUp;
            } else if(xRange <= 20 && linkLocation.Y > YPosition)
            {
                trapState = TrapStates.MoveDown;
            } else if(linkLocation.X < xPosition && yRange <= 20)
            {
                trapState = TrapStates.MoveLeft;
            }  else if(linkLocation.X > xPosition && yRange <= 20)
            {
                trapState = TrapStates.MoveRight;
            } else
            {
                trapState = TrapStates.Sitting;
            }
           
        }
        
    }
}

