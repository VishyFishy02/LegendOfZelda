using System;
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;
using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using CommonReferences;

namespace GameStates

{
    public class TransitionDownState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        public TransitionDownState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }

        public void BossRush()
        {
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(new(400, 260), false);
            controller.gameState = game.bossRushState;
        }

        public void GamePlay()
        {
            if (game.currentRoomIndex == Common.Instance.caveRoomsIndex)
            {
                Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(new(180, 180), false);
            }
            else
            {
                Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingDown(new(400, 260), false);
            }
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
                if (game.currentRoomIndex < Common.Instance.rushRoomsIndex || game.currentRoomIndex== Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms)
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

        //none of these are valid states from TransitionDownState
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

