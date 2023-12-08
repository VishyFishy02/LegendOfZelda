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
    public class BottomDragonAttackOrbSprite : IEnemyProjectile
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

        public BottomDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            originalX = (int)xPosition;
            originalY = (int)yPosition;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 40);

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
                yPosition += 5;
            xPosition -= 5;


            // Update the full location of the orb
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 40);

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
