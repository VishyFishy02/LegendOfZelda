using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CommonReferences;

namespace GameStates

{
    public class GamePlayState : IGameState
    {
        private readonly GameStateController controller;
        private readonly Game1 game;
        public GamePlayState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {
            // Already in gameplay state
        }
        public void Inventory()
        {
            controller.gameState = new InventoryState(controller, game, game.hud);
        }
        public void GameOver()
        {
            controller.gameState = new GameOverState(controller, game);
        }
        public void Pause()
        {
            controller.gameState = new PauseState(controller, game);
        }
        public void WinGame()
        {
            controller.gameState = new WinGameState(controller, game);
        }
        public void BossRush()
        {
            controller.gameState = game.bossRushState;
        }
        public void TransitionUp()
        {
            controller.gameState = new TransitionUpState(controller, game);
        }
        public void TransitionDown()
        {
            controller.gameState = new TransitionDownState(controller, game);
        }
        public void TransitionLeft()
        {
            controller.gameState = new TransitionLeftState(controller, game);
        }
        public void TransitionRight()
        {
            controller.gameState = new TransitionRightState(controller, game);
        }

        public  void EnemiesPause()
        {
            controller.gameState = new EnemiesPausedState(controller, game);
        }
        public void Update()
        {
            if (game.currentRoomIndex == Common.Instance.rushRoomsIndex)
            {
                BossRush();
            }

            Link.Instance.Update();
            game.mouseController.Update();
            game.collisionDetector.Update();
            game.keyboardController.Update();
            game.currentRoom.Update();
            game.hud.Update();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.currentRoom.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            game.hud.Draw(_spriteBatch);
        }
    }
}

