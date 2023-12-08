using System;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda;

namespace LegendofZelda
{
    public class TextSprite : ISprite
    {
        private Vector2 position;

        // Font to use
        private SpriteFont font;

        // Text to produce
        private string text;

        public Rectangle DestinationRectangle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TextSprite(Vector2 location, SpriteFont font, string text)
        {
            this.position = location;
            this.font = font;
            this.text = text;
        }

        public void Update()
        {
            // Only drawing once, no need for anything here
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //// Where to position the font
            //Vector2 fontPosition = new Vector2(graphics.PreferredBackBufferWidth / 3, graphics.PreferredBackBufferHeight / 3);

            //// Get the origin of the font to center it
            //Vector2 fontOrigin = font.MeasureString(text) / 2;

            //public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
            // Draw the text
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, position, Color.White);
            spriteBatch.End();

        }

        public Rectangle GetHitbox()
        {
            throw new NotImplementedException();
        }
    }
}
