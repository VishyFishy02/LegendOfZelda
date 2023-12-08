using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using LegendofZelda.SpriteFactories;

namespace Sprites
{
    public class GelSprite : IEnemy
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        private int poofCounter = 0;
        private int maxPoofCounter = 15;
        private List<Rectangle> poofRectangles = new() { new Rectangle(235, 204, 16, 16), new Rectangle(252, 204, 16, 16), new Rectangle(269, 204, 16, 16)};

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private int deathFrames = 0;
        private int maxDeathFrames = 20;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private Rectangle sourceRectangle;
        private int currFrameIndex;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
        public GelSprite(Texture2D texture, float xPosition, float yPosition, Texture2D dyingTexture)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.dyingTexture = dyingTexture;
            currDirection = directions[random.Next(0, directions.Count)];
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(1, 16, 8, 8));
            sourceRectangles.Add(new Rectangle(11, 15, 6, 9));
            sourceRectangles.Add(new Rectangle(0, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(16, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(35, 3, 9, 10));
            sourceRectangles.Add(new Rectangle(51, 3, 9, 10));
            currFrameIndex = 0;
        }
        public void Update()
        {
            if (!isDead)
            {
                if (poofCounter >= maxPoofCounter)
                {
                    if (random.Next(0, maxFrames) <= (maxFrames / 50))
                    {
                        currDirection = directions[random.Next(0, directions.Count)];
                    }
                    if (currFrames > maxFrames)
                    {
                        currFrames = 0;
                    }
                    else
                    {
                        currFrames += 10;
                    }

                    if (currDirection == Directions.UP)
                    {
                        yPosition -= 1;
                    }
                    else if (currDirection == Directions.LEFT)
                    {
                        xPosition -= 1;
                    }
                    else if (currDirection == Directions.RIGHT)
                    {
                        xPosition += 1;
                    }
                    else // Direction is down
                    {
                        yPosition += 1;
                    }
                } else
                {
                    poofCounter++; 
                    for(int i= 0; i < poofRectangles.Count; i++)
                    {
                        if (poofCounter > i*maxPoofCounter/poofRectangles.Count && poofCounter <= (i+1) * maxPoofCounter / poofRectangles.Count)
                        {
                            sourceRectangle = poofRectangles[i];
                        }
                    }
                }
            }
            else
            {
                deathFrames++;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDead)
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if ((currFrames / 100) % 2 != 0)
                {
                    currFrameIndex = 0;
                }
                else
                {
                    currFrameIndex = 1;
                }
                if (poofCounter >= maxPoofCounter)
                {
                    sourceRectangle = sourceRectangles[currFrameIndex];
                }
                destinationRectangle = new((int)xPosition, (int)yPosition, sourceRectangle.Width * 3, sourceRectangle.Height * 3);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                for (int i = 0; i < 4; i++)
                {
                    if (deathFrames >= i * maxDeathFrames / 4 && deathFrames < (i + 1) * maxDeathFrames / 4)
                    {
                        currFrameIndex = i + 2;
                    }
                    else if (deathFrames >= maxDeathFrames)
                    {
                        dyingComplete = true;
                    }
                }
                sourceRectangle = sourceRectangles[currFrameIndex];
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
                if (!dyingComplete)
                {
                    spriteBatch.Draw(dyingTexture, destinationRectangle, sourceRectangle, Color.White);
                }
                spriteBatch.End();
            }
        }
        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
        public void TurnAround(string side)
        {
            // Have the Gel turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    currDirection = Directions.DOWN;
                    break;
                case "bottom":
                    currDirection = Directions.UP;
                    break;
                case "left":
                    currDirection = Directions.RIGHT;
                    break;
                case "right":
                    currDirection = Directions.LEFT;
                    break;
                default:
                    break;

            }
        }
        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            isDead = true;
        }
        public ISprite DropItem()
        {
            return null;
        }

        
    }
}