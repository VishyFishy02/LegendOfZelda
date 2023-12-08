
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Sprites
{
    public class GoriyaMovingUpSprite : IGoriya
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }

        private int currentFrame = 0;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        public GoriyaMovingUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
        }

        public void Update()
        {
            yPosition -= 1;
            sourceRectangle = new Rectangle(241, 11, 13, 16);
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            currentFrame++;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            if ((currentFrame / 10) % 2 == 0)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }

            spriteBatch.End();
            
        }
        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TurnAround(string side)
        {

        }
        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }
    }

    public class GoriyaMovingDownSprite : IGoriya
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        private int currentFrame;

        public GoriyaMovingDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
        }
        public void Update()
        {
            yPosition += 1;
            sourceRectangle = new Rectangle(224, 11, 13, 16);
            destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            currentFrame++;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if ((currentFrame / 10) % 2 == 0)
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
            }
            else
            {
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            }
            spriteBatch.End();

        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }
        public void TurnAround(string side)
        {

        }
        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }

        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }
    }

    public class GoriyaMovingRightSprite : IGoriya
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        int currentFrame = 0;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        public GoriyaMovingRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
        }
        public void Update()
        {
            xPosition += 1;
            currentFrame++;
            if ((currentFrame / 10) % 2 == 0)
            {
                sourceRectangle = new Rectangle(257, 11, 13, 16);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            }
            else
            {
                sourceRectangle = new Rectangle(275, 12, 14, 15);
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, color);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TurnAround(string side)
        {

        }
        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }

        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }

    }

    public class GoriyaMovingLeftSprite : IGoriya
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        int currentFrame = 0;


        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        public GoriyaMovingLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
        }

        public void Update()
        {

            xPosition -= 1;

            currentFrame++;
            if ((currentFrame / 10) % 2 == 0)
            {
                sourceRectangle = new Rectangle(257, 11, 13, 16);
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 32);
            }
            else
            {
                sourceRectangle = new Rectangle(275, 12, 14, 15);
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 32);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TurnAround(string side)
        {

        }
        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }
    }

    /* ------- THROWING SPRITES -------*/

    public class GoriyaThrowingRightSprite : IGoriya
    {

        private int goriyaFrames = 0;

        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value; }

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }

        // Texture to take sprites from
        private Texture2D texture;
        public GoriyaThrowingRightSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
           
        }
        public void Update()
        {
            goriyaFrames++;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if ((goriyaFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(257, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(275, 12, 14, 15);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            }

            spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, color);
            
            spriteBatch.End();
            


        }
        public Rectangle GetHitbox()
        {
            return this.goriyaDestinationRectangle;
        }

        public void TurnAround(string side)
        {

        }
        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }

    }

    public class GoriyaThrowingLeftSprite : IGoriya
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value; }

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }

        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        // Texture to take sprites from
        private Texture2D texture;

        public GoriyaThrowingLeftSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
        }

        public void Update()
        {
            currFrames += 101;

            if (currFrames >= maxFrames)
            {
                currFrames = 0;
            }

            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if ((currFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(257, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(275, 12, 14, 15);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            }
            spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
            spriteBatch.End();

        }

        public Rectangle GetHitbox()
        {
            return this.goriyaDestinationRectangle;
        }

        public void TurnAround(string side)
        {

        }

        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }
    }

    public class GoriyaThrowingDownSprite : IGoriya
    {
        // Keep track of frames
        private int goriyaFrames = 0;

        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value; }

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        // Texture to take sprites from
        private Texture2D texture;
 
        public GoriyaThrowingDownSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
            
        }

        public void Update()
        {
            goriyaFrames++; 
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if ((goriyaFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(224, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, color);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(224, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);

            }

            spriteBatch.End();


        }

        public Rectangle GetHitbox()
        {
            return this.goriyaDestinationRectangle;
        }

        public void TurnAround(string side)
        {

        }

        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }

    }

    public class GoriyaThrowingUpSprite : IGoriya
    {
        private int goriyaFrames = 0;

        private Rectangle goriyaSourceRectangle;
        private Rectangle goriyaDestinationRectangle;
        public Rectangle DestinationRectangle { get => goriyaDestinationRectangle; set => goriyaDestinationRectangle = value; }

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        public bool DyingComplete { get => isDead; set => isDead = value; }
        private bool isDamaged = false;
        public bool IsDamaged { get => isDamaged; set => isDamaged = value; }
        // Texture to take sprites from
        private Texture2D texture;
        public GoriyaThrowingUpSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
           
        }

        public void Update()
        {
            goriyaFrames++;
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color = Color.White;
            if (isDamaged)
            {
                color = Color.Lerp(Color.White, Color.Red, 0.3f);
            }
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if ((goriyaFrames / 10) % 2 == 0)
            {
                goriyaSourceRectangle = new Rectangle(241, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, color);
            }
            else
            {
                goriyaSourceRectangle = new Rectangle(241, 11, 13, 16);
                goriyaDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 32);
                spriteBatch.Draw(texture, goriyaDestinationRectangle, goriyaSourceRectangle, color, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);

            }

            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return goriyaDestinationRectangle;
        }

        public void TurnAround(string side)
        {

        }

        public void TakeDamage(string side)
        {
            switch (side)
            {
                case "top":
                    this.yPosition += 25;
                    break;
                case "bottom":
                    this.yPosition -= 25;
                    break;
                case "left":
                    this.xPosition += 25;
                    break;
                case "right":
                    this.xPosition -= 25;
                    break;
                default:
                    break;
            }
        }
        public ISprite DropItem()
        {
            return null;
        }
        public void PoofIn(SpriteBatch spriteBatch) { }
    }
}