using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using CommonReferences;
using LegendofZelda.EnemyAndNPCSprites;

namespace Sprites
{
    public class DragonBossSprite : IEnemy
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

        private int health = 3;
        private bool isDamaged = false, isDead = false, dyingComplete = false;
        private int damagedCounter = 0;

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private int direction = 1;

        private Rectangle sourceRectangle, dragonDestinationRectangle;
        private List<Rectangle> sourceRectangles;

        public bool IsDead { get => isDead; set => isDead = value; }
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        public Rectangle DestinationRectangle { get => dragonDestinationRectangle; set => dragonDestinationRectangle = value; }

        // Projectile orbs
        private TopDragonAttackOrbSprite topAttackOrb;
        private MiddleDragonAttackOrbSprite middleAttackOrb;
        private BottomDragonAttackOrbSprite bottomAttackOrb;
        public DragonBossSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            dyingTexture = texture2;

            topAttackOrb = new TopDragonAttackOrbSprite(texture, xPosition, yPosition);
            middleAttackOrb = new MiddleDragonAttackOrbSprite(texture, xPosition, yPosition);
            bottomAttackOrb = new BottomDragonAttackOrbSprite(texture, xPosition, yPosition);

            sourceRectangles = new();
            sourceRectangles.Add(new(0, 0, 15, 16));
            sourceRectangles.Add(new(16, 0, 15, 16));
            sourceRectangles.Add(new(35, 3, 9, 10));
            sourceRectangles.Add(new(51, 3, 9, 10));
            sourceRectangle = new();
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
                    // Go the other direction halfway through
                    if (currFrames == maxFrames / 2)
                    {
                        direction *= -1;
                    }
                    currFrames += 5;
                    // Reset motion if at max
                    if (currFrames == maxFrames)
                    {
                        currFrames = 0;
                        topAttackOrb = new TopDragonAttackOrbSprite(texture, xPosition, yPosition + 30);
                        middleAttackOrb = new MiddleDragonAttackOrbSprite(texture, xPosition, yPosition + 30);
                        bottomAttackOrb = new BottomDragonAttackOrbSprite(texture, xPosition, yPosition + 30);
                    }
                    // Update the x position
                    xPosition += 1 * direction;

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
            Rectangle dragonSourceRectangle = new Rectangle(1, 11, 24, 32);

            if (!isDead)
            {
                dragonDestinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 80, 100);

                if (currFrames <= maxFrames / 8)
                {
                    dragonSourceRectangle = new Rectangle(1, 11, 24, 32);
                }
                else if (currFrames <= maxFrames / 4)
                {
                    dragonSourceRectangle = new Rectangle(26, 11, 24, 32);
                }
                else if (currFrames <= maxFrames / 2)
                {
                    dragonSourceRectangle = new Rectangle(51, 11, 24, 32);
                }
                else if (currFrames <= maxFrames)
                {
                    dragonSourceRectangle = new Rectangle(76, 11, 24, 32);
                }
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (poofCounter < maxPoofCounter)
                {
                    dragonSourceRectangle = sourceRectangle;
                }
                if (isDamaged)
                {
                    spriteBatch.Draw(texture, dragonDestinationRectangle, dragonSourceRectangle, Color.Lerp(Color.White, Color.Red, 0.5f));
                }
                else
                {
                    spriteBatch.Draw(texture, dragonDestinationRectangle, dragonSourceRectangle, Color.White);
                }
                spriteBatch.End();

            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                dragonDestinationRectangle = new((int)xPosition + 48, (int)yPosition + 64, 60, 60);
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
                    spriteBatch.Draw(dyingTexture, dragonDestinationRectangle, sourceRectangle, Color.White);
                }

                spriteBatch.End();
            }

        }
        public Rectangle GetHitbox()
        {
            return dragonDestinationRectangle;
        }

        public void TurnAround(string side) { }
   
        // Allows other things in the game to get the projectiles
        public List<ISprite> getEnemyProjectiles()
        {
            return new List<ISprite> { topAttackOrb, middleAttackOrb, bottomAttackOrb }; ;
        }

        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            if (!isDamaged) { 
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
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(xPosition, yPosition - Common.Instance.heightOfInventory), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }

        public void PoofIn(SpriteBatch spriteBatch)
        {
           
        }
    } 
}

