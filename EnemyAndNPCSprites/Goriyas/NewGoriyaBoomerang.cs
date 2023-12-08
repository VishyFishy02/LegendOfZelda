using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using LegendofZelda;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sprites
{
    public class GoriyaBoomerangUpSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 100;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private readonly int originalXPosition;
        private readonly int originalYPosition;
        private int xPosition;
        private int yPosition;

        //to track phase of animation
        private bool returning;
        private bool returned;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        public bool keepThrowing { get; set; }
        public GoriyaBoomerangUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            originalXPosition = (int)xPosition+20;
            originalYPosition = (int)yPosition;
            this.xPosition = (int)xPosition+20;
            this.yPosition = (int)yPosition;
            keepThrowing = true;
            returning = false;
            returned = false;

            //building source rectangle array
            sourceRectangles = new();
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
        }

        public void Update()
        {
            currFrames += 5;
            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }

            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }

            if (yPosition > originalYPosition - 100 && !returning)
            { 
                yPosition -= 2;
            }
            else if (yPosition != originalYPosition)
            {
                returning = true;
                yPosition += 2;
            }
            else
            {
                returned = true;
                keepThrowing = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!returned)
            {
                Rectangle currentFrame = sourceRectangles[currentFrameIndex];
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (currentFrameIndex <= 2)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 2 && currentFrameIndex <= 3)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 3 && currentFrameIndex <= 6)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, origin, SpriteEffects.None, 1);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, origin, SpriteEffects.None, 1);
                }
                spriteBatch.End();
            }
        }
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

        public void collide()
        {
            returning = true;
        }

    }

    public class GoriyaBoomerangDownSprite : IEnemyProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 100;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private readonly int originalXPosition;
        private readonly int originalYPosition;
        private int xPosition;
        private int yPosition;

        //to track phase of animation
        private bool returning;
        private bool returned;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        public bool keepThrowing { get; set; }
        public GoriyaBoomerangDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            originalXPosition = (int)xPosition+20;
            originalYPosition = (int)yPosition+10;
            this.xPosition = (int)xPosition+20;
            this.yPosition = (int)yPosition+10;
            keepThrowing = true;

            returning = false;
            returned = false;

            //building source rectangle array
            sourceRectangles = new();
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
        }
        public void Update()
        {
            currFrames += 5;
            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }

            if (yPosition < originalYPosition + 100 && !returning)
            {
                yPosition += 2;

            }
            else if (yPosition != originalYPosition)
            {
                returning = true;

                yPosition -= 2;

            }
            else
            {
                returned = true;
                keepThrowing = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!returned)
            {
                Rectangle currentFrame = sourceRectangles[currentFrameIndex];
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (currentFrameIndex <= 2)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 2 && currentFrameIndex <= 3)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 3 && currentFrameIndex <= 6)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, origin, SpriteEffects.None, 1);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, origin, SpriteEffects.None, 1);
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
            returning = true;
        }

    }

    public class GoriyaBoomerangRightSprite : IEnemyProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 100;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private readonly int originalXPosition;
        private readonly int originalYPosition;
        private int xPosition;
        private int yPosition;

        //to track phase of animation
        private bool returning;
        private bool returned;
        public bool keepThrowing { get; set; }

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public GoriyaBoomerangRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            originalXPosition = (int)xPosition+20;
            originalYPosition = (int)yPosition+10;
            this.xPosition = (int)xPosition+20;
            this.yPosition = (int)yPosition +10;
            keepThrowing = true;

            returning = false;
            returned = false;

            //building source rectangle array
            sourceRectangles = new();
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
        }

        public void Update()
        {
            currFrames += 5;
            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }

            if (xPosition < originalXPosition + 100 && !returning)
            {
                xPosition += 2;
            }
            else if (xPosition != originalXPosition)
            {
                returning = true;

                xPosition -= 2;

            }
            else
            {
                returned = true;
                keepThrowing = false;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (!returned)
            {
                Rectangle currentFrame = sourceRectangles[currentFrameIndex];
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (currentFrameIndex <= 2)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 2 && currentFrameIndex <= 3)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 3 && currentFrameIndex <= 6)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, origin, SpriteEffects.None, 1);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, origin, SpriteEffects.None, 1);
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
            returning = true;
        }

    }

    public class GoriyaBoomerangLeftSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 100;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private readonly int originalXPosition;
        private readonly int originalYPosition;
        private int xPosition;
        private int yPosition;

        //to track phase of animation
        private bool returning;
        private bool returned;
        public bool keepThrowing { get; set; }
        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        public GoriyaBoomerangLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            originalXPosition = (int)xPosition+20;
            originalYPosition = (int)yPosition + 10;
            this.xPosition = (int)xPosition+20;
            this.yPosition = (int)yPosition + 10;
            keepThrowing = true;

            returning = false;
            returned = false;

            //building source rectangle array
            sourceRectangles = new();
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(291, 15, 5, 8));
            sourceRectangles.Add(new(299, 15, 8, 8));
            sourceRectangles.Add(new(308, 17, 8, 5));
            sourceRectangles.Add(new(299, 15, 8, 8));
        }
        public void Update()
        {
            currFrames += 5;
            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }
            for (int i = 0; i < 8; i++)
            {
                if (currFrames > i * maxFrames / 8 && currFrames <= (i + 1) * maxFrames / 8)
                {
                    currentFrameIndex = i;
                }
            }
            if (xPosition > originalXPosition - 100 && !returning)
            {
                xPosition -= 2;

            }
            else if (xPosition != originalXPosition)
            {
                returning = true;

                xPosition += 2;

            }
            else
            {
                returned = true;
                keepThrowing = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!returned)
            {
                Rectangle currentFrame = sourceRectangles[currentFrameIndex];
                destinationRectangle = new Rectangle(xPosition, yPosition, currentFrame.Width * 2, currentFrame.Height * 2);
                Vector2 origin = new Vector2(currentFrame.Width / 2, currentFrame.Height / 2);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (currentFrameIndex <= 2)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, 0, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 2 && currentFrameIndex <= 3)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -90, origin, SpriteEffects.None, 1);
                }
                else if (currentFrameIndex > 3 && currentFrameIndex <= 6)
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -180, origin, SpriteEffects.None, 1);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, currentFrame, Color.White, -270, origin, SpriteEffects.None, 1);
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
            returning = true;
        }
    }

}


