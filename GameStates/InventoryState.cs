using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using HeadsUpDisplay;

namespace GameStates
{
    public class InventoryState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        private int mapCount, compassCount;
        private ISprite map, compass;

        private ISprite boomerang, bomb, fire, arrow;
        private ISprite selectedBoomerang, selectedBomb, selectedFire, selectedArrow;

        //private List<ISprite> selectedItems;
        private ISprite selectedItem;

        private ISprite itemSelectionBackground;
        private ISprite mapDisplayBackground;
        public ISprite cursor;
        public Link.Throwables currentThrowable;

        private Dictionary<Vector2, Link.Throwables> inventory;
        private Dictionary<Link.Throwables, ISprite> selectedItemDict;

        private Hud hud;
        private Hud inGameHud;
        public InventoryState(GameStateController controller, Game1 game, Hud inGameHud)
        {

            this.controller = controller;
            this.game = game;
            this.inGameHud = inGameHud;
            hud = new Hud(0, 460);
          
            boomerang = HudSpriteFactory.Instance.CreateSprite(new Vector2(412, 122), "HudBoomerangSprite");
            bomb = HudSpriteFactory.Instance.CreateSprite(new Vector2(412 + 50, 122), "HudBombSprite");
            fire = HudSpriteFactory.Instance.CreateSprite(new Vector2(412 + 2 * 50, 122), "HudFireSprite");
            arrow = HudSpriteFactory.Instance.CreateSprite(new Vector2(412 + 3 * 50, 122), "HudBowSprite");

            Vector2 selectedItemLocation = new(220, 122);
            selectedBoomerang = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudBoomerangSprite");
            selectedBomb = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudBombSprite");
            selectedFire = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudFireSprite");
            selectedArrow = HudSpriteFactory.Instance.CreateSprite(selectedItemLocation, "HudBowSprite");
          
            itemSelectionBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 0), "InventorySelectionSprite");
            mapDisplayBackground = HudSpriteFactory.Instance.CreateSprite(new Vector2(0, 230), "MapDisplaySprite");
            cursor = HudSpriteFactory.Instance.CreateSprite(new Vector2(400, 122), "HudSelectionCursor");

            selectedItemDict= new()
            {
                { Link.Throwables.Boomerang, selectedBoomerang},
                { Link.Throwables.Bomb,  selectedBomb},
                { Link.Throwables.Fire, selectedFire},
                { Link.Throwables.Arrow, selectedArrow}
            };

            List<Link.Throwables> throwablesList = new()
            {
                Link.Throwables.Boomerang,
                Link.Throwables.Bomb,
                Link.Throwables.Fire,
                Link.Throwables.Arrow
            };
            selectedItem = selectedFire;
            currentThrowable = Link.Throwables.Fire;

            inventory = new();
            var newRect = cursor.DestinationRectangle;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    inventory.Add(new Vector2(400 + (i * newRect.Width), 122 + (j * newRect.Height)), throwablesList[i]);
                }
            }

            map = ItemSpriteFactory.Instance.CreateItem(new Vector2(150, 135), "OrangeMap");
            compass = ItemSpriteFactory.Instance.CreateItem(new Vector2(150, 250), "Compass");
        }

        public void BossRush() {
            controller.gameState = new BossRushState(controller, game);
        }
        public void GamePlay()
        {    
            controller.gameState = new GamePlayState(controller, game);
        }
        public void Update()
        {
            mapCount = Link.Instance.inventory.getItemCount("orange map");
            compassCount = Link.Instance.inventory.getItemCount("compass");
            cursor.Update();
            hud.Update();
            game.keyboardController.Update();
            if (inventory.ContainsKey(new(cursor.DestinationRectangle.X, cursor.DestinationRectangle.Y)))
            {
                currentThrowable = inventory[new(cursor.DestinationRectangle.X, cursor.DestinationRectangle.Y)];
            }
            if (Link.Instance.inventory.getThrowableCount(currentThrowable) > 0)
            {
                Link.Instance.throwable = currentThrowable;
                inGameHud.switchProjectile(currentThrowable);
                selectedItem = selectedItemDict[currentThrowable];
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {  
            itemSelectionBackground.Draw(_spriteBatch);
            mapDisplayBackground.Draw(_spriteBatch);
            hud.Draw(_spriteBatch);
            cursor.Draw(_spriteBatch);

            if (Link.Instance.inventory.getThrowableCount(Link.Throwables.Bomb) > 0)
            { 
                bomb.Draw(_spriteBatch);
            }
            if (Link.Instance.inventory.getThrowableCount(Link.Throwables.Fire) > 0)
            {
                fire.Draw(_spriteBatch);
            }
            if (Link.Instance.inventory.getThrowableCount(Link.Throwables.Boomerang) > 0)
            {
                boomerang.Draw(_spriteBatch);
            }
            if (Link.Instance.inventory.getThrowableCount(Link.Throwables.Arrow) > 0)
            {
                arrow.Draw(_spriteBatch);
            }
            if (Link.Instance.inventory.getThrowableCount(currentThrowable) > 0)
            {
                selectedItem.Draw(_spriteBatch);
            }

            for (int i = 0; i < 18; i++)
            {
                if (game.roomsGraph.Visited[i])
                {
                    MapPieceSpriteFactory.Instance.CreateMapPiece(new(0, 0), i).Draw(_spriteBatch);
                }
            }

            if (mapCount > 0)
            {
                map.Draw(_spriteBatch);
            }
            if (compassCount > 0)
            {
                compass.Draw(_spriteBatch);
            }
        }

        //all invalid states from the current state
        public void Inventory() { }
        public void GameOver() { }
        public void WinGame() { }
        public void TransitionUp() { }
        public void TransitionDown() { }
        public void TransitionLeft() { }
        public void TransitionRight() { }
        public void Pause() { }
        public void EnemiesPause() { }
       
       
    }
}
