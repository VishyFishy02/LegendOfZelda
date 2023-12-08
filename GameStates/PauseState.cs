using System;
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;


namespace GameStates

{
    public class PauseState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public PauseState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void GamePlay()
        {
            controller.gameState = new GamePlayState(controller, game);
        }
        public void Update()
        {
            game.keyboardController.Update();
        }

        //these are all empty because they are not valid states from PauseState
        public void Inventory(){}
        public void GameOver() {}
        public void Draw(SpriteBatch _spriteBatch) {}
        public void Pause() {}
        public void WinGame() {}
        public void BossRush() { }
        public void TransitionUp() {}
        public void TransitionDown() {}
        public void TransitionLeft() {}
        public void TransitionRight() {}
        public void EnemiesPause() { }
       
    }
}

