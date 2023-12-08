using LegendofZelda.Interfaces;
using LegendofZelda.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda;
using Sprites;

namespace LegendofZelda.SpriteFactories
{
    public class MapPieceSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private readonly static MapPieceSpriteFactory instance = new();

        public static MapPieceSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private MapPieceSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("actual_hud_sprites");
               
        }

        public ISprite CreateMapPiece(Vector2 location, int roomNumber)
        {
            return new MapSprite(roomNumber, spriteSheet);
                
        }

    }
}
