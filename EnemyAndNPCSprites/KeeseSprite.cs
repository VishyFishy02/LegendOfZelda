using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace Sprites
{
    public class KeeseSprite : IEnemy
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        private int poofCounter = 0;
        private int maxPoofCounter = 15;
        private List<Rectangle> poofRectangles = new() { new Rectangle(235, 204, 16, 16), new Rectangle(252, 204, 16, 16), new Rectangle(269, 204, 16, 16) };

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;

        private List<Rectangle> sourceRectangles;
        private Rectangle sourceRectangle;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private bool isDead = false, isPoofed = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private int deathFrames = 0;
        private int maxDeathFrames = 20;


        // On screen position
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;


        public KeeseSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            dyingTexture = texture2;
            currDirection = directions[random.Next(0, directions.Count)];
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(183, 15, 16, 8));
            sourceRectangles.Add(new Rectangle(203, 15, 10, 10));
            sourceRectangles.Add(new Rectangle(0, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(16, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(35, 3, 9, 10));
            sourceRectangles.Add(new Rectangle(51, 3, 9, 10));

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
                    if (currFrames == maxFrames)
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
            else
            {
                deathFrames++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDead)
            {
                if (poofCounter >= maxPoofCounter)
                {
                    sourceRectangle = sourceRectangles[(currFrames / 100) % 2];
                }
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (deathFrames > (i * maxDeathFrames) / 4 && deathFrames <= ((i + 1) * maxDeathFrames) / 4)
                    {
                        sourceRectangle = sourceRectangles[i + 2];
                    }
                    else if (deathFrames > maxDeathFrames)
                    {
                        dyingComplete = true;
                    }
                }
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 30);
                if (!dyingComplete)
                {
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                    spriteBatch.Draw(dyingTexture, destinationRectangle, sourceRectangle, Color.White);
                    spriteBatch.End();
                }
            }
        }
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

        public void TurnAround(string side)
        {
            // Have the Keese turn around based on what wall it is running into
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
        public void PoofIn(SpriteBatch spriteBatch)
        {
            int maxPoofFrames = 20;
            var sourceRectangles = new List<Rectangle>();
            sourceRectangles.Add(new(235,204, 16, 16));
            sourceRectangles.Add(new(252,204, 16, 16));
            sourceRectangles.Add(new(269,204, 16, 16));
            var destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 16 * 2, 16* 2);

            for (int poofFrames = 0; poofFrames < maxPoofFrames; poofFrames++)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (poofFrames > (i * maxPoofFrames) / 3 && poofFrames <= ((i + 1) * maxPoofFrames) / 3)
                    {
                        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                        spriteBatch.Draw(texture, destinationRectangle, sourceRectangles[i], Color.White);
                        spriteBatch.End();
                    }
                }
            }
        }
    }
}


