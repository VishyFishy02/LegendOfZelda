using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static LegendofZelda.Link;
using Sprites;
using LegendofZelda;
using LegendofZelda.Interfaces;
using LegendofZelda.Backgrounds;
using System.Diagnostics;

namespace LegendofZelda.SpriteFactories
{
    public class TextSpriteFactory : ISpriteFactory
    {

        private SpriteFont font;
        private static TextSpriteFactory instance = new();

        public static TextSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private TextSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Times New Roman");
        }

        public ISprite CreateTextSprite(Vector2 location, string text)
        {
            return new TextSprite(location, font, text);
        }

    }
}
