using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using LegendofZelda.SpriteFactories;
using System.Runtime.CompilerServices;

namespace Sprites
{
    public class OldManBoss : IEnemy
    {
        private List<string> droppableItems = new List<string> { "Fairy" };

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 480;
        private int deathFrames = 0;
        private int maxDeathFrames = 40;

        private int poofCounter = 0;
        private int maxPoofCounter = 15;
        private List<Rectangle> poofRectangles = new() { new Rectangle(236, 270, 16, 16), new Rectangle(253, 270, 16, 16), new Rectangle(272, 272, 16, 16) };


        private int health = 4;
        private bool isDamaged = false;
        private int damagedCounter = 0;

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D orbTexture;
        private Texture2D dyingTexture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        // On screen location
        private Rectangle destinationRectangle;
        private Rectangle sourceRectangle;

        private List<Rectangle> sourceRectangles;

        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> {Directions.RIGHT, Directions.LEFT};
        Directions currDirection;

        //  Projectile orbs
        private FrontOldManOrb frontOrb;
        private LeftOldManOrb leftOrb;
        private RightOldManOrb rightOrb;

        public OldManBoss(Texture2D texture, Texture2D orbTexture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            dyingTexture = texture2;
            this.orbTexture = orbTexture;
            currDirection = directions[random.Next(0, directions.Count)];

            frontOrb = new FrontOldManOrb(orbTexture, xPosition, yPosition);
            leftOrb = new LeftOldManOrb(orbTexture, xPosition, yPosition);
            rightOrb = new RightOldManOrb(orbTexture, xPosition, yPosition);

            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(0, 0, 15, 15));
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
                    // keeps track of how long sprite stays red
                    if (isDamaged)
                    {
                        damagedCounter++;
                        if (damagedCounter > 60)
                        {
                            isDamaged = false;
                            damagedCounter = 0;
                        }
                    }

                    // pick a direction
                    if (random.Next(0, maxFrames) <= (maxFrames / 50))
                    {
                        currDirection = directions[random.Next(0, directions.Count)];
                    }

                    // update animation
                    if (currFrames == maxFrames)
                    {
                        currFrames = 0;
                        frontOrb = new FrontOldManOrb(orbTexture, xPosition, yPosition + 15);
                        leftOrb = new LeftOldManOrb(orbTexture, xPosition, yPosition + 15);
                        rightOrb = new RightOldManOrb(orbTexture, xPosition, yPosition + 15);
                    }
                    else
                    {
                        currFrames += 5;
                    }

                    // move old man in a direction
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
                    else
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
            if (poofCounter >= maxPoofCounter)
            {
                sourceRectangle = sourceRectangles[0];
            }
            if (!isDead)
            {
                this.destinationRectangle = new((int)xPosition, (int)yPosition, 15*3, 15*3);

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (isDamaged)
                {
                    spriteBatch.Draw(texture, this.DestinationRectangle, this.sourceRectangle, Color.Lerp(Color.White, Color.Red, 0.5f));
                }
                else
                {
                    spriteBatch.Draw(texture, this.DestinationRectangle, this.sourceRectangle, Color.White);

                }
                spriteBatch.End();

            }
            // death animation
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                this.destinationRectangle = new((int)xPosition , (int)yPosition , 15*3, 15*3);
                for (int i = 0; i < 4; i++)
                {
                    if (deathFrames > (i * maxDeathFrames) / 4 && deathFrames <= ((i + 1) * maxDeathFrames) / 4)
                    {
                        sourceRectangle = sourceRectangles[i];
                    }
                    else if (deathFrames > maxDeathFrames)
                    {
                        dyingComplete = true;
                    }
                }

                if (!dyingComplete)
                {
                    spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangle, Color.White);
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
            // Have the OldMan turn around based on what wall it is running into
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

        // Allows other things in the game to get the projectiles
        public List<ISprite> getEnemyProjectiles()
        {
            return new List<ISprite> { frontOrb, leftOrb, rightOrb }; ;
        }

        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            if (!isDamaged)
            {
                isDamaged = true;
                health -= 1;
            }

            if (health <= 0)
            {
                isDead = true;
            }
        }

        public ISprite DropItem()
        {
            if (dyingComplete)
            {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(xPosition, yPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }
        public void PoofIn(SpriteBatch spriteBatch) { }

    }

    public class LeftOldManOrb : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

 
        public bool keepThrowing { get; set; }

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public LeftOldManOrb(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
 
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 30);

            currOrb = 0;
            attackOrbs.Add(blueOrb);
            attackOrbs.Add(orangeOrb);
            attackOrbs.Add(greenOrb);
            attackOrbs.Add(multicolorOrb);
            keepThrowing = true;
        }
        public void Update()
        {
            // Update current orb
            currFrames += 1;
            if (currFrames % 2 == 0)
            {
                ++currOrb;
            }
            if (currOrb >= attackOrbs.Count)
            {
                currOrb = 0;
            }

            //update location
            if (currFrames % 3 == 0)
                xPosition -= 5;
            yPosition += 1;

            // Update the full location of the orb
            destinationRectangle = new((int)xPosition, (int)yPosition, 30, 30);

        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, attackOrbs[currOrb], Color.White);
            spriteBatch.End();

        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;

        }

        public void collide()
        {
            currFrames = maxFrames;
            keepThrowing = false;

        }
    }

    public class FrontOldManOrb : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // Original positions to reset to
        private int originalX;
        private int originalY;

        // Keeps track of if the projectile should keep going
        public bool keepThrowing { get; set; }

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public FrontOldManOrb(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            originalX = (int)xPosition;
            originalY = (int)yPosition;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 30);

            currOrb = 0;
            attackOrbs.Add(blueOrb);
            attackOrbs.Add(orangeOrb);
            attackOrbs.Add(greenOrb);
            attackOrbs.Add(multicolorOrb);
            keepThrowing = true;
        }
        public void Update()
        {

            // Update current orb
            currFrames += 1;
            if (currFrames % 2 == 0)
            {
                ++currOrb;
            }
            if (currOrb >= attackOrbs.Count)
            {
                currOrb = 0;
            }

            //update position
            yPosition += 1;

            // Update the full location of the orb
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 30);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //if(currFrames < maxFrames) {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, attackOrbs[currOrb], Color.White);
            spriteBatch.End();
            //} 
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;

        }
        public void collide()
        {
            currFrames = maxFrames;
            keepThrowing = false;
        }

    }

    public class RightOldManOrb : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // Keep track of if the projectile should keep going
        public bool keepThrowing { get; set; }


        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new();
        private Rectangle blueOrb = new(128, 14, 8, 10);
        private Rectangle orangeOrb = new(119, 14, 8, 10);
        private Rectangle greenOrb = new(110, 14, 8, 10);
        private Rectangle multicolorOrb = new(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public RightOldManOrb(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 30);

            currOrb = 0;
            attackOrbs.Add(blueOrb);
            attackOrbs.Add(orangeOrb);
            attackOrbs.Add(greenOrb);
            attackOrbs.Add(multicolorOrb);
            keepThrowing = true;
        }
        public void Update()
        {

            currFrames += 1;
            // Update current orb
            if (currFrames % 2 == 0)
            {
                ++currOrb;
            }
            if (currOrb >= attackOrbs.Count)
            {
                currOrb = 0;
            }

            // Update x and y so that this orb goes towards the upper left in a diagonal line
            if (currFrames % 3 == 0)
                xPosition += 5;
            yPosition += 1;


            // Update the full location of the orb
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 30);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, attackOrbs[currOrb], Color.White);
            spriteBatch.End();

        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;

        }
        public void collide()
        {
            currFrames = maxFrames;
            keepThrowing = false;
        }
    }
}
