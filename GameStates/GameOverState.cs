
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using Sprites;
using LegendofZelda.Interfaces;

namespace GameStates

{
    public class GameOverState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        int resetCounter = 0;
        public GameOverState(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
            Link.Instance.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkDying(Link.Instance.currentPosition);
        }
        
        public void Pause()
        {
            controller.gameState = new PauseState(controller, game);
        }

        public void EnemiesPause()
        {
            controller.gameState = new EnemiesPausedState(controller, game);
        }
      
        public void Update()
        {
            game.hud.Update();
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (sprite != null)
            {
                if (!sprite.isComplete)
                {
                    sprite.Update();
                }
            }
            resetCounter++;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            game.hud.Draw(_spriteBatch);
            LinkDyingSprite sprite = Link.Instance.currentLinkSprite as LinkDyingSprite;
            if (sprite != null)
            {
                if (!sprite.isComplete)
                {
                    Link.Instance.game.currentRoom.Background.Draw(_spriteBatch);
                    sprite.Draw(_spriteBatch);
                }
                if (sprite.isComplete)
                {
                    ISprite gameOver = BackgroundSpriteFactory.Instance.GameOverScreen();
                    gameOver.Draw(_spriteBatch);
                }
            }
            if (resetCounter > 210)
            {
                Link.Instance.Reset();
            }
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

    }
}

