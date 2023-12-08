using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using LegendofZelda.Blocks;
using CommonReferences;

namespace LegendofZelda.SpriteFactories
{
    public class BlockSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private Texture2D doorSpriteSheet;
        private Texture2D whiteDoorSpriteSheet;
        private Texture2D fireTexture;
        private readonly static BlockSpriteFactory instance = new();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private BlockSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("blocks");
            fireTexture = content.Load<Texture2D>("LinkandProjectileSprites");
            doorSpriteSheet = content.Load<Texture2D>("doors");
            whiteDoorSpriteSheet = content.Load<Texture2D>("WhiteDoors");
        }

        public ISprite CreateBlock(Vector2 location, string name)
        {

            
            switch (name)
            {
                case "StatueOneBlock":

                    return new StatueOneBlock(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory);

                case "StatueTwoBlock":

                    return new StatueTwoBlock(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory);

                case "DepthBlock":

                    return new DepthBlock(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory);

                case "PlainDarkBlueBlock":

                    return new PlainDarkBlueBlock(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory);

                case "VerticalBoundingBlock":

                    return new VerticalBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "HorizontalBoundingBlock":

                    return new HorizontalBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "BoundingBlock":

                    return new BoundingBlock(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "VerticalHalfBoundingBlock":

                    return new VerticalHalfBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "HorizontalHalfBoundingBlock":

                    return new HorizontalHalfBoundingBlock(spriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory);

                case "DepthPushableBlock":

                    return new DepthPushableBlock(spriteSheet, (int)location.X,(int)location.Y + Common.Instance.heightOfInventory);

                case "LockedDoorBlockTop":

                    return new LockedDoorBlock(doorSpriteSheet,350,22 + Common.Instance.heightOfInventory, 0);
                
                case "LockedDoorBlockLeft":

                    return new LockedDoorBlock(doorSpriteSheet, 33, 195 + Common.Instance.heightOfInventory, 1);

                case "LockedDoorBlockRight":

                    return new LockedDoorBlock(doorSpriteSheet, 702, 200 + Common.Instance.heightOfInventory, 2);

                case "LockedDoorBlockBottom":

                    return new LockedDoorBlock(doorSpriteSheet, 350, 395 + Common.Instance.heightOfInventory, 3);

                case "PuzzleDoorBlockTop":

                    return new PuzzleDoorBlock(whiteDoorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 0);
                
                case "PuzzleDoorBlockLeft":

                    return new PuzzleDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 1);

                case "PuzzleDoorBlockRight":

                    return new PuzzleDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 2);

                case "PuzzleDoorBlockBottom":

                    return new PuzzleDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 3);

                case "OpenDoorBlockTop":

                    return new OpenDoorBlock(doorSpriteSheet, 350, 15 + Common.Instance.heightOfInventory, 0);
                
                case "OpenDoorBlockLeft":

                    return new OpenDoorBlock(doorSpriteSheet,32, 199 + Common.Instance.heightOfInventory, 1);
                
                case "OpenDoorBlockRight":

                    return new OpenDoorBlock(doorSpriteSheet, 700, 200 + Common.Instance.heightOfInventory, 2);
                
                case "OpenDoorBlockBottom":

                    return new OpenDoorBlock(doorSpriteSheet, 350, 400 + Common.Instance.heightOfInventory, 3);

                case "BombableDoorBlockTop":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory, 0);
                
                case "BombableDoorBlockLeft":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 1);
                
                case "BombableDoorBlockRight":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 2);
                
                case "BombableDoorBlockBottom":

                    return new BombableDoorBlock(doorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 3);
                case "OpenWhiteDoorBlockTop":

                    return new OpenWhiteDoorBlock(whiteDoorSpriteSheet, 350, 22 + Common.Instance.heightOfInventory, 0);

                case "OpenWhiteDoorBlockLeft":

                    return new OpenWhiteDoorBlock(whiteDoorSpriteSheet, 33, 195 + Common.Instance.heightOfInventory, 1);

                case "OpenWhiteDoorBlockRight":

                    return new OpenWhiteDoorBlock(whiteDoorSpriteSheet, 700, 200 + Common.Instance.heightOfInventory, 2);

                case "OpenWhiteDoorBlockBottom":

                    return new OpenWhiteDoorBlock(whiteDoorSpriteSheet, 350, 390 + Common.Instance.heightOfInventory, 3);

                case "Fire":

                    return new Fire(fireTexture, location.X, location.Y + Common.Instance.heightOfInventory);

                case "StairsBlock":

                    return new StairsBlock(doorSpriteSheet, (int)location.X, (int)location.Y + Common.Instance.heightOfInventory, 2);

                case "WhiteDepthBlock":

                     return new WhiteDepthBlock(spriteSheet, (int)location.X, (int)location.Y+Common.Instance.heightOfInventory);

                default:

                    return null;
            }
        }

    }
}
