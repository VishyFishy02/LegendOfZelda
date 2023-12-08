using System;
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using Sprites;
using SharpDX.Direct2D1;
using Microsoft.Xna.Framework;

namespace GameStates

{
    public class WinGameState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        private ISprite text;
        private ISprite winGame;
        public WinGameState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkWinning(Link.Instance.currentPosition);
            text = TextSpriteFactory.Instance.CreateTextSprite(new Vector2(390, 250), "YAY!");
            winGame = BackgroundSpriteFactory.Instance.WinGameScreen();

        }
      
        public void Pause()
        {
            controller.gameState = new PauseState(controller, game);
        }
        
        public void Update()
        {
            Link.Instance.game.currentRoom.Update();
            Link.Instance.Update();
            winGame.Update();
        }
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch)
        {
            Link.Instance.game.currentRoom.Draw(_spriteBatch);
            winGame.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            text.Draw(_spriteBatch);
            
        }

        //all invalid states from the current state
        public void Inventory() { }
        public void GameOver() { }
        public void GamePlay() { }
        public void WinGame() { }
        public void BossRush() { }
        public void TransitionUp() { }
        public void TransitionDown() { }
        public void TransitionLeft() { }
        public void TransitionRight() { }
        public void EnemiesPause() { }
    }
}

