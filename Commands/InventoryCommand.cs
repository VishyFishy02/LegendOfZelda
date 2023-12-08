using LegendofZelda.Interfaces;
using GameStates;

namespace Commands
{
    public class InventoryCommand : ICommand
    {
        private GameStateController controller;
        private Game1 game;

        public InventoryCommand(GameStateController controller, Game1 game)
        {
            this.controller = controller;
            this.game = game;
        }
        public void Execute()
        {
            if (controller.gameState is InventoryState)
            {
                if (game.currentRoomIndex< 19)
                {
                    controller.gameState.GamePlay();
                }
                else
                {
                    controller.gameState.BossRush();
                }
               
            }
            else if(controller.gameState is GamePlayState || controller.gameState is BossRushState)
            {
                controller.gameState.Inventory();
            }
        }
    }

}


