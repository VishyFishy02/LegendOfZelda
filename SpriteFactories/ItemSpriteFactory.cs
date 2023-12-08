using LegendofZelda.Interfaces;
using LegendofZelda.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda;
using CommonReferences;


namespace LegendofZelda.SpriteFactories
{
    public class ItemSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private readonly static ItemSpriteFactory instance = new();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private ItemSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("itemsandweapons");
        }

        public ISprite CreateItem(Vector2 location, string name)
        {

            switch (name)

            {
                case "PurpleGemstone":

                    return new PurpleGemstone(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "OrangeGemstone":

                    return new OrangeGemstone(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "Triforce":

                    return new Triforce(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "OrangeMap":

                    return new OrangeMap(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "SmallRedHeart":

                    return new SmallRedHeart(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "SmallBlueHeart":

                    return new SmallBlueHeart(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory);

                case "BigHeart":

                    return new BigHeart(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory);

                case "Fairy":

                    return new Fairy(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory); 

                case "Compass":

                    return new Compass(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "Clock":

                    return new Clock(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "Bow":

                    return new Bow(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "Boomerang":

                    return new Boomerang(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "Bomb":

                    return new Bomb(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "Key":

                    return new Key(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "MasterSword":

                    return new MasterSword(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                default:

                    return null;
            }
        }

    }
}
