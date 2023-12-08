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
    public class HudSpriteFactory : ISpriteFactory
    {

        private Texture2D spriteSheet;
        private Texture2D _spriteSheet;
        private static HudSpriteFactory instance = new();
        
        public static HudSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private HudSpriteFactory()
        {
        }

        public void loadContent(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>("actual_hud_sprites");
            _spriteSheet = content.Load<Texture2D>("LinkandProjectileSprites");

        }

        public ISprite CreateSprite(Vector2 location, string name)
        {
            switch (name)
            {
                case "hudBackground":

                    return new HudBackgroundSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "LinkSwordSprite":

                    return new LinkSwordSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "RedHeartSprite":                    
                    
                    return new RedHeartSprite(spriteSheet, (int)location.X, (int)location.Y); 
                
                case "HalfRedHeartSprite":                    
                    
                    return new HalfRedHeartSprite(spriteSheet, (int)location.X, (int)location.Y); 
                
                case "PinkHeartSprite":                    
                    
                    return new PinkHeartSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "InventorySelectionSprite":
                    
                    return new InventorySelectionSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "MapDisplaySprite":
                    
                    return new MapDisplaySprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "HudBoomerangSprite":
                    
                    return new HudBoomerangSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "HudBowSprite":
                    
                    return new HudBowSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "HudBombSprite":
                    
                    return new HudBombSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "HudSelectionCursor":
                    
                    return new HudSelectionCursor(spriteSheet, (int)location.X, (int)location.Y);
                
                case "HudBlueMapSprite":
                    
                    return new HudBlueMapSprite(spriteSheet, (int)location.X, (int)location.Y);
                
                case "HudFireSprite":
                    
                    return new HudFireSprite(_spriteSheet, (int)location.X, (int)location.Y);

                default:
                    return null;
            }
        }

    }
}
