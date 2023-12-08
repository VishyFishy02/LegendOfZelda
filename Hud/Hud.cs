using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;

using System.Diagnostics;
using LegendofZelda;
using Sprites;

namespace HeadsUpDisplay
{
    public class Hud
    {
        public List<ISprite> sprites = new List<ISprite>();
        // For setting the positions of the heart sprites. 
        private int x;
        private int y;
        readonly private Vector2 heartOnePos, heartTwoPos, heartThreePos, heartFourPos, backgroundPos;

        int bombCount, keyCount, gemstoneCount;
        ISprite bombCountText, keyCountText, gemstoneCountText;
        int mapCount;
        ISprite blueMap;
        ISprite red1, red2, red3, red4;
        ISprite halfRed1, halfRed2, halfRed3, halfRed4;
        ISprite pink1, pink2, pink3, pink4;
        private ISprite throwableSprite;
        public ISprite ThrowableSprite { set => throwableSprite = value; }
        ISprite selectedBoomerang, selectedBomb, selectedFire, selectedArrow;
        float heartCount;
        private List<ISprite> heartsList;
        private ISprite levelText;
        public Hud(int xPos, int yPos)
        {
            x = xPos;
            y = yPos;
            int heartXPos = x + 540;
            int heartYPos = y + 106;
            int heartSpacing = 34;
            heartOnePos = new Vector2(heartXPos, heartYPos);
            heartTwoPos = new Vector2(heartXPos + heartSpacing, heartYPos);
            heartThreePos = new Vector2(heartXPos + heartSpacing * 2, heartYPos);
            heartFourPos = new Vector2(heartXPos + heartSpacing * 3, heartYPos);
            backgroundPos = new Vector2(x, y);

            heartCount = 3;
            red1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "RedHeartSprite");
            red2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "RedHeartSprite");
            red3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "RedHeartSprite");
            red4 = HudSpriteFactory.Instance.CreateSprite(heartFourPos, "RedHeartSprite");

            halfRed1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "HalfRedHeartSprite");
            halfRed2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "HalfRedHeartSprite");
            halfRed3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "HalfRedHeartSprite");
            halfRed4 = HudSpriteFactory.Instance.CreateSprite(heartFourPos, "HalfRedHeartSprite");

            pink1 = HudSpriteFactory.Instance.CreateSprite(heartOnePos, "PinkHeartSprite");
            pink2 = HudSpriteFactory.Instance.CreateSprite(heartTwoPos, "PinkHeartSprite");
            pink3 = HudSpriteFactory.Instance.CreateSprite(heartThreePos, "PinkHeartSprite");
            pink4 = HudSpriteFactory.Instance.CreateSprite(heartFourPos, "PinkHeartSprite");

            heartsList = new()
            {
                red1, red2, red3, red4
            };
            levelText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(xPos + 65, yPos + 20), "LEVEL-1");

        //    heartsList = new()
        //    {
        //        {0,  new() { pink1, pink2, pink3, pink4 } },
        //        {0.5f, new() { halfRed1, pink2, pink3, pink4 } },
        //        {1.0f,  new() { red1, pink2, pink3, pink4 } },
        //        {1.5f,  new(0){ red1, halfRed2, pink3, pink4 } },
        //        {2.0f, new() { red1, red2, pink3, pink4 } },
        //        {2.5f, new() { red1, red2, halfRed3, pink4 } },
        //        {3.0f,  new() { red1, red2, red3, pink4 }},
        //        {3.5f,  new() { red1, red2, red3, halfRed4 } },
        //        {4.0f,  new() { red1, red2, red3, red4 } }
        //};

            blueMap = HudSpriteFactory.Instance.CreateSprite(new Vector2(x + 40, y + 55), "HudBlueMapSprite");
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(backgroundPos, "hudBackground"));
            sprites.Add(HudSpriteFactory.Instance.CreateSprite(new Vector2(x + 472, y + 62), "LinkSwordSprite"));

            Vector2 hudSelectedItemLocation = new Vector2(420, 50);
            selectedBoomerang = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudBoomerangSprite");
            selectedBomb = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudBombSprite");
            selectedFire = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudFireSprite");
            selectedArrow = HudSpriteFactory.Instance.CreateSprite(hudSelectedItemLocation, "HudBowSprite");
            throwableSprite = selectedFire;
        }

        public void Update()
        {
            bombCount = Link.Instance.inventory.getItemCount("bomb");
            bombCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(x + 300, y + 115), "X" + bombCount.ToString());
            keyCount = Link.Instance.inventory.getItemCount("key");
            keyCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(x + 300, y + 90), "X" + keyCount.ToString());
            gemstoneCount = Link.Instance.inventory.getItemCount("orange gemstone");
            gemstoneCountText = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(x + 300, y + 40), "X" + gemstoneCount.ToString());
            blueMap.Update();
            heartCount = Link.Instance.health;
            mapCount = Link.Instance.inventory.getItemCount("orange map");

            switch (heartCount)
            {
                case 0:
                    heartsList = new() { pink1, pink2, pink3, pink4 };
                    break;
                case .5f:
                    heartsList = new() { halfRed1, pink2, pink3, pink4 };
                    break;
                case 1:
                    heartsList = new() { red1, pink2, pink3, pink4 };
                    break;
                case 1.5f:               
                    heartsList = new() { red1, halfRed2, pink3, pink4 };
                    break;
                case 2:               
                    heartsList = new() { red1, red2, pink3, pink4 };
                    break;
                case 2.5f:          
                    heartsList = new() { red1, red2, halfRed3, pink4 };
                    break;
                case 3:
                    heartsList = new() { red1, red2, red3, pink4 };
                    break;
                case 3.5f:
                    heartsList = new() { red1, red2, red3, halfRed4 };
                    break;
                case 4:
                    heartsList = new() { red1, red2, red3, red4};
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (ISprite sprite in sprites)
            {
                sprite.Draw(_spriteBatch);
            }

            if (bombCountText != null)
            {
                bombCountText.Draw(_spriteBatch);
            }
            if (keyCountText != null)
            {
                keyCountText.Draw(_spriteBatch);
            }
            if (gemstoneCountText != null)
            {
                gemstoneCountText.Draw(_spriteBatch);
            }
            if (blueMap != null && mapCount > 0)
            {
                blueMap.Draw(_spriteBatch);
            }

            for (int i = 0; i < 3; i++)
            {
                heartsList[i].Draw(_spriteBatch);
            }
            if (Link.Instance.maxHealth == 4)
            {
                heartsList[3].Draw(_spriteBatch);
            }
            levelText.Draw(_spriteBatch);
        }

        public void switchProjectile(Link.Throwables type)
        {   
            sprites.Remove(throwableSprite);
            switch (type)
            {
                case Link.Throwables.Boomerang:
                    throwableSprite = selectedBoomerang;
                    break;
                case Link.Throwables.Bomb:
                    throwableSprite = selectedBomb;
                    break;
                case Link.Throwables.Fire:
                    throwableSprite = selectedFire;           
                    break;
                case Link.Throwables.Arrow:
                    throwableSprite = selectedArrow;
                    break;
            }
            sprites.Add(throwableSprite);
        }
    }
}

