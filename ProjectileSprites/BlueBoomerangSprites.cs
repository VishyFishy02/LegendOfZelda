using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using LegendofZelda;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sprites
{
    public class BlueBoomerangUpSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private readonly int originalYPosition;
        private int xPosition;
        private int yPosition;

        //to track phase of animation
        private bool returning;
        private bool returned;

        //for position
        private Link link;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
   
        public bool IsDone { get => returned; }
        public BlueBoomerangUpSprite(Texture2D texture, float xPosition, float yPosition, Link link)
        {
            this.texture = texture;
            originalYPosition = (int)yPosition;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.link = link;

            returning = false;
            returned = false;

            //building source rectangle array
            sourceRectangles = new();

            sourceRectangles.Add(new(92, 189, 5, 8));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(109, 191, 8, 5));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(92, 189, 5, 8));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(109, 191, 8, 5));
            sourceRectangles.Add(new(100, 189, 8, 8));
        }

        public void Update()
        {
            currFrames += 25;
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

            if (yPosition > originalYPosition - 200 && !returning)
            {
                yPosition -= 1;
            }
            else
            {
                returning = true;

                Vector2 vectorToTarget = link.currentPosition - new Vector2(xPosition, yPosition);
                if (vectorToTarget.Length() <= 3)
                {
                    returned = true;
                }
                else
                {
                    vectorToTarget.Normalize();
                    xPosition += (int)(vectorToTarget.X * 2.5);
                    yPosition += (int)(vectorToTarget.Y * 2.5);
                }
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

        public bool isReturned()
        {
            return returned;
        }

      
    }



    public class BlueBoomerangDownSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private readonly int originalYPosition;
        private int xPosition;
        private int yPosition;

        //to track phase of animation
        private bool returning;
        private bool returned;

        //for position
        private Link link;


        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public bool IsDone { get => returned; }
        public BlueBoomerangDownSprite(Texture2D texture, float xPosition, float yPosition, Link link)
        {
            this.texture = texture;
            originalYPosition = (int)yPosition;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.link = link;

            returning = false;
            returned = false;

            //building source rectangle array
            sourceRectangles = new();
            sourceRectangles.Add(new(92, 189, 5, 8));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(109, 191, 8, 5));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(92, 189, 5, 8));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(109, 191, 8, 5));
            sourceRectangles.Add(new(100, 189, 8, 8));
        }
        public void Update()
        {
            currFrames += 25;
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

            if (yPosition < originalYPosition + 200 && !returning)
            {
                yPosition += 1;
            }
            else
            {
                returning = true;

                Vector2 vectorToTarget = link.currentPosition - new Vector2(xPosition, yPosition);
                if (vectorToTarget.Length() <= 3)
                {
                    returned = true;
                }
                else
                {
                    vectorToTarget.Normalize();
                    xPosition += (int)(vectorToTarget.X * 2.5);
                    yPosition += (int)(vectorToTarget.Y * 2.5);
                }
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

    public class BlueBoomerangRightSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 1000;
        private List<Rectangle> sourceRectangles;
        private int currentFrameIndex;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private readonly int originalXPosition;
        private int xPosition;
        private int yPosition;

        //to track phase of animation
        private bool returning;
        private bool returned;

        //for position
        private Link link;

        // On screen location
        private Rectangle destinationRectangle = new Rectangle();
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

       
        public bool IsDone { get => returned; }
        public BlueBoomerangRightSprite(Texture2D texture, float xPosition, float yPosition, Link link)
        {
            this.texture = texture;
            originalXPosition = (int)xPosition;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.link = link;

            returning = false;
            returned = false;

            //building source rectangle array
            sourceRectangles = new();
            sourceRectangles.Add(new(92, 189, 5, 8));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(109, 191, 8, 5));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(92, 189, 5, 8));
            sourceRectangles.Add(new(100, 189, 8, 8));
            sourceRectangles.Add(new(109, 191, 8, 5));
            sourceRectangles.Add(new(100, 189, 8, 8));

        }

        public void Update()
        {
            currFrames += 25;
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

            if (xPosition < originalXPosition + 200 && !returning)
            {
                xPosition += 1;
            }
            else
            {
                returning = true;

                Vector2 vectorToTarget = link.currentPosition - new Vector2(xPosition, yPosition);
                if (vectorToTarget.Length() <= 3)
                {
                    returned = true;
                }
                else
                {
                    vectorToTarget.Normalize();
                    xPosition += (int)(vectorToTarget.X * 2.5);
                    yPosition += (int)(vectorToTarget.Y * 2.5);
                }
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


public class BlueBoomerangLeftSprite : ILinkProjectile
{ 
    // Keep track of frames
    private int currFrames = 0;
    private int maxFrames = 1000;
    private List<Rectangle> sourceRectangles;
    private int currentFrameIndex;

    // Texture to take sprites from
    public Texture2D texture;

    // X and Y positions of the sprite
    private readonly int originalXPosition;
    private int xPosition;
    private int yPosition;

    //to track phase of animation
    private bool returning;
    private bool returned;

    //for position
    private Link link;

    // On screen location
    private Rectangle destinationRectangle = new Rectangle();
    public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

    public bool IsDone { get => returned; }
    public BlueBoomerangLeftSprite(Texture2D texture, float xPosition, float yPosition, Link link)
    {
        this.texture = texture;
        originalXPosition = (int)xPosition;
        this.xPosition = (int)xPosition;
        this.yPosition = (int)yPosition;
        this.link = link;

        returning = false;
        returned = false;
        
        //building source rectangle array
        sourceRectangles = new();
        sourceRectangles.Add(new(92, 189, 5, 8));
        sourceRectangles.Add(new(100, 189, 8, 8));
        sourceRectangles.Add(new(109, 191, 8, 5));
        sourceRectangles.Add(new(100, 189, 8, 8));
        sourceRectangles.Add(new(92, 189, 5, 8));
        sourceRectangles.Add(new(100, 189, 8, 8));
        sourceRectangles.Add(new(109, 191, 8, 5));
        sourceRectangles.Add(new(100, 189, 8, 8));
    }
    public void Update()
    {
        currFrames += 25;
        if (currFrames >= maxFrames)
        {
            currFrames = 0;
        }
        for (int i = 0; i<8; i++)
        {
            if(currFrames>i*maxFrames/8 && currFrames <= (i + 1) * maxFrames / 8)
            {
                currentFrameIndex = i;
            }
        }
        if (xPosition > originalXPosition - 200 && !returning)
        {
            xPosition -= 1;
        }
        else
        {
            returning = true;
            Vector2 vectorToTarget = link.currentPosition - new Vector2(xPosition, yPosition);
            if (vectorToTarget.Length() <= 3)
            {
                returned = true;
            }
            else
            {
                vectorToTarget.Normalize();
                xPosition += (int)(vectorToTarget.X * 2.5);
                yPosition += (int)(vectorToTarget.Y * 2.5);
            }
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



