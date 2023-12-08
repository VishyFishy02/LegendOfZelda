using System;
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using Sprites;
using LegendofZelda.Interfaces;

namespace GameStates

{
    public class EnemiesPausedState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public EnemiesPausedState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {
            controller.gameState = new GamePlayState(controller, game);
        }

        public void EnemiesPause()
        {
           // Already in this state
        }
        public void Update()
        {
            game.keyboardController.Update();

            Link.Instance.Update();
            game.mouseController.Update();
            game.collisionDetector.Update();
            game.keyboardController.Update();
            game.currentRoom.ClockUpdate();
            game.hud.Update();

            if ((Link.Instance.currentLinkSprite is IAttackingSprite))
            {
                this.GamePlay();
            }
        }

        public void Draw(SpriteBatch _spriteBatch) {
            game.GraphicsDevice.Clear(Color.Black);
            game.currentRoom.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            game.hud.Draw(_spriteBatch);
        }

        //these are all empty because they are not valid states from PauseState
        public void Inventory() { }
        public void GameOver() { }
        
        public void Pause() { }
        public void WinGame() { }
        public void BossRush() { }
        public void TransitionUp() { }
        public void TransitionDown() { }
        public void TransitionLeft() { }
        public void TransitionRight() { }

    }
}

