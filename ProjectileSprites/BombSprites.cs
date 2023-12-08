using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class BombUpSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public List<Rectangle> sourceRectangles;
        public int currentFrameIndex;

        private bool isDone;
        public bool IsDone { get => isDone; }
        public BombUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition-15;
            this.yPosition = (int)yPosition-64;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(138, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(155, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(172, 185, 16, 16));
            isDone = false;
        }

        public void Update()
        {
        
            // Update frames
            if (!(currFrames > maxFrames))
            {
                currFrames += 50;
            }
            else
            {
                isDone = true;
            }

            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }


        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = sourceRectangles[currentFrameIndex]; // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width*3, sourceRectangle.Height*3); // Where to draw on screen

            if (!isDone)
            {
                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 5 * maxFrames / 8;
        }

   
    }


    public class BombDownSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;
        
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public List<Rectangle> sourceRectangles;
        public int currentFrameIndex;
        private bool isDone;
        public bool IsDone { get => isDone; }
        public BombDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition-15;
            this.yPosition = (int)yPosition+32;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(138, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(155, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(172, 185, 16, 16));
            isDone = false;
        }

        public void Update()
        {
            // Update frames
            if (!(currFrames > maxFrames))
            {
                currFrames += 50;
            }
            else
            {
                isDone = true;
            }

            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }



        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            // Create source and destination rectangles
            Rectangle sourceRectangle = sourceRectangles[currentFrameIndex]; // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 3, sourceRectangle.Height * 3); // Where to draw on screen

            if (!isDone)
            {
                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 5 * maxFrames / 8;
        }

  
    }


    public class BombRightSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public List<Rectangle> sourceRectangles;
        public int currentFrameIndex;
        private bool isDone;
        public bool IsDone { get => isDone; }
        public BombRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition+32;
            this.yPosition = (int)yPosition-32;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(138, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(155, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(172, 185, 16, 16));
            isDone = false;
        }

        public void Update()
        {
            // Update frames
            if (!(currFrames > maxFrames))
            {
                currFrames += 50;
            }
            else
            {
                isDone = true;
            }

            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = sourceRectangles[currentFrameIndex]; // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 3, sourceRectangle.Height * 3); // Where to draw on screen

            if (!isDone)
            {
                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 5 * maxFrames / 8;
        }

    
    }


    public class BombLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public List<Rectangle> sourceRectangles;
        public int currentFrameIndex;
        private bool isDone;
        public bool IsDone { get => isDone; }
        public BombLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition-64;
            this.yPosition = (int)yPosition-32;
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(129, 185, 8, 14));
            sourceRectangles.Add(new Rectangle(138, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(155, 185, 16, 16));
            sourceRectangles.Add(new Rectangle(172, 185, 16, 16));
            isDone = false;
        }

        public void Update()
        {
            // Update frames
            if (!(currFrames > maxFrames))
            {
                currFrames += 50;
            }
            else
            {
                isDone = true;
            }

            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = sourceRectangles[currentFrameIndex]; // Store the current location on the spritesheet to get a sprite from
            this.destinationRectangle = new Rectangle(xPosition, yPosition, sourceRectangle.Width * 3, sourceRectangle.Height * 3); // Where to draw on screen

            if (!isDone)
            {
                // Draw the sprite
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 5*maxFrames/8;
        }

    }


}

