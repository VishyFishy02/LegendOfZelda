using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;
using LegendofZelda;
using LegendofZelda.SpriteFactories;

namespace Sprites
{
    public class OldManSprite : IEnemy
    {

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private string message = "ONLY A TRUE HERO IS FIT FOR THE TRIALS ABOVE!";
        private int messageOffsetX = 252;
        private int messageOffsetY = 38;
        private ISprite text;

        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        public OldManSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.text = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(this.xPosition - this.messageOffsetX, this.yPosition - this.messageOffsetY), message);
        }

        public void Update(){ }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 64, 64);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
            text.Draw(spriteBatch);
        }
        public Rectangle GetHitbox()
        {
            // change this to destination rectangle
            return new Rectangle();
        }

        public void TurnAround(string side)
        {

        }

        public void TakeDamage(string side)
        {

        }

        public ISprite DropItem()
        {
            return null;
        }

        public void PoofIn(SpriteBatch spriteBatch) { }
    }
}

