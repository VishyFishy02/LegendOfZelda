
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using Microsoft.Xna.Framework;
using LegendofZelda.Interfaces;
using CommonReferences;

namespace LegendofZelda.SpriteFactories
{
    public class EnemyAndNPCSpriteFactory : ISpriteFactory
    {
        private Texture2D enemySpriteSheet;
        private Texture2D oldManSpriteSheet;
        private Texture2D bossSpriteSheet;
        private Texture2D dyingSpriteSheet;
        
        private static EnemyAndNPCSpriteFactory instance = new();
        public static EnemyAndNPCSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemyAndNPCSpriteFactory()
        {
        }


        public void loadContent(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("enemies");
            oldManSpriteSheet = content.Load<Texture2D>("oldman");
            bossSpriteSheet = content.Load<Texture2D>("bosses");
            dyingSpriteSheet = content.Load<Texture2D>("enemy_death");
        }

        public IEnemy CreateEnemyOrNPC(Vector2 location, string name)
        {

            switch (name)
            {
                case "Goriya":

                    return new GoriyaSprite(enemySpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);

                case "Keese":

                    return new KeeseSprite(enemySpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);

                case "Stalfos":

                    return new StalfosSprite(enemySpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);

                case "Gel":

                    return new GelSprite(enemySpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);

                case "DragonBoss":

                    return new DragonBossSprite(bossSpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);

                case "OldMan":

                    return new OldManSprite(oldManSpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory);

                case "Wallmaster":

                    return new WallMasterSprite(enemySpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);

                case "Trap":

                    return new TrapSprite(enemySpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory);

                case "Dodongo":

                    return new DodongoSprite(bossSpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);
                
                case "Digdogger":
                    
                    return new Digdogger(bossSpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);

                 case "OldManBoss":

                    return new OldManBoss(oldManSpriteSheet, bossSpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet);            

                case "Gohma":

                    return new GohmaSprite(bossSpriteSheet, bossSpriteSheet, location.X, location.Y + Common.Instance.heightOfInventory, dyingSpriteSheet); 
                default:

                    return null;
            }
        }
    }
}