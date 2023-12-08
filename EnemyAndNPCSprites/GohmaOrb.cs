using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendofZelda.EnemyAndNPCSprites
{
   
        public class GohmaOrb : IEnemyProjectile
        {
            // Keep track of frames
            private int currFrames = 0;
            private int maxFrames = 10000;

            // Texture to take sprites from
            private Texture2D texture;

            // X and Y positions of the sprite
            private int xPosition;
            private int yPosition;



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

            public GohmaOrb(Texture2D texture, float xPosition, float yPosition)
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
                if ((currFrames / 10) % 2 == 0)
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
