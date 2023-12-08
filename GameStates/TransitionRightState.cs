using System;
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using LegendofZelda.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using LegendofZelda.SpriteFactories;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using CommonReferences;

namespace GameStates

{
    public class TransitionRightState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
   
        public TransitionRightState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void BossRush()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(new(130, 395), false);
            controller.gameState = game.bossRushState;
        }
        public void GamePlay()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(new(130, 395), false);
            controller.gameState = new GamePlayState(controller, game);
        }
      
        public void Pause()
        {
            controller.gameState = new PauseState(controller, game);
        }
     
        public void Update()
        {
            var background = game.currentRoom.Background as IBackground;
            background.Update();

            if (!background.IsTransitioning)
            {
                if (game.currentRoomIndex < Common.Instance.rushRoomsIndex || game.currentRoomIndex == Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms)
                {
                    GamePlay();
                }
                else if (game.currentRoomIndex > Common.Instance.rushRoomsIndex - 1)
                {
                    BossRush();
                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.currentRoom.Draw(_spriteBatch);
            game.hud.Draw(_spriteBatch);
        }


        //all invalid states from the current state
        public void Inventory() { }
        public void GameOver() { }
        public void WinGame() { }
        public void TransitionUp() { }
        public void TransitionDown() { }
        public void TransitionLeft() { }
        public void TransitionRight() { }
        public void EnemiesPause() { }

    }
}

