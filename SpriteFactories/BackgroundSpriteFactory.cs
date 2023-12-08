
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using LegendofZelda.Backgrounds;
using CommonReferences;

namespace LegendofZelda.SpriteFactories
{
    public class BackgroundSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private Texture2D gameOverBackground;
        private Texture2D whiteRooms;
        private readonly static BackgroundSpriteFactory instance = new();

        public static BackgroundSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BackgroundSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("allbackgrounds");
            whiteRooms = content.Load<Texture2D>("WhiteRooms");
            gameOverBackground = content.Load<Texture2D>("game_over");
        }

        public ISprite CreateBackground(string name)
        {
            var split= name.Split('d');
            int roomNum = int.Parse(split[1]);
            if (roomNum < Common.Instance.rushRoomsIndex) { 
                return new Background(spriteSheet, roomNum);
            }
            else {
                return new Background(whiteRooms, roomNum);
            }
        }

        public ISprite GameOverScreen()
        {
            return new GameOverScreen(gameOverBackground);
        }

        public ISprite WinGameScreen()
        {
            return new WinGameScreen(gameOverBackground);
        }

    }
}
