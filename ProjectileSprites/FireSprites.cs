using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;

namespace Sprites
{
    public class FireUpSprite : ILinkProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // On screen position 
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public FireUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition-15;
            this.yPosition = (int)yPosition - 20;
            isDone = false;
        }


        public void Update()
        {
           
        
            if (!isDone) { currFrames += 30; }

            if (currFrames <= 1500) { this.yPosition -= 2; }

            if (currFrames >= maxFrames) { isDone = true; }

            
        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new (191, 185, 16, 16);
            destinationRectangle = new(xPosition, yPosition, sourceRectangle.Width*2, sourceRectangle.Height*2);

            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if(currFrames < maxFrames)
            {

                if ((currFrames/100) % 2 == 0) {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }
                    
            }
          
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 2400;
        }

   
    }

    public class FireRightSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition; 

        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public FireRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition-20;
            isDone = false;
        }

        public void Update()
        {
      
            if (!isDone)
            {
                currFrames +=30;
            }
            if (currFrames <= 1500)
            {
                this.xPosition += 2;
            }
            if (currFrames >= maxFrames) 
            { 
                isDone = true; 
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, 16, 16); // fire
            destinationRectangle = new(xPosition, yPosition, sourceRectangle.Width*2, sourceRectangle.Height*2);

            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            if (currFrames < maxFrames)
            {

                if ((currFrames / 100) % 2 == 0)
                {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                } else
                {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 2400;
        }

        
    }

    public class FireDownSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;
        
        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public FireDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition - 15;
            this.yPosition = (int)yPosition;
            isDone = false;
        }

        public void Update()
        {
         ;

            if (!isDone)
            {
                currFrames +=30;
            }
            if (currFrames <= 1500)
            {
                this.yPosition += 2;
            }
            if (currFrames >= maxFrames)
            {
                isDone = true;
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, 16, 16); // fire
            destinationRectangle = new(xPosition, yPosition, sourceRectangle.Width*2, sourceRectangle.Height*2);

            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (currFrames < maxFrames)
            {
                if ((currFrames / 100) % 2 == 0)
                {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 2400;
        }

      
    }

    public class FireLeftSprite : ILinkProjectile
    {

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        public Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;
     
        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        private bool isDone;
        public bool IsDone { get => isDone; }
        public FireLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition-20;
            this.yPosition = (int)yPosition-20;
        }

        public void Update()
        {
          
            if (!isDone)
            {
                currFrames +=30;
            }
            if (currFrames <= 1500)
            {
                this.xPosition -= 2;
            }
            if (currFrames >= maxFrames)
            {
                isDone = true;
            }

        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, 16, 16); // fire
            destinationRectangle = new(xPosition, yPosition, sourceRectangle.Width*2, sourceRectangle.Height*2);

            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (currFrames < maxFrames)
            {
                if (currFrames < maxFrames)
                {
                    if ((currFrames / 100) % 2 == 0)
                    {
                        spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                    }
                }
            }
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void collide()
        {
            this.currFrames = 2400;
        }

      
    }
}
