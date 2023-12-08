using LegendofZelda.Interfaces;
using GameStates;

namespace Commands
{
    public class PauseCommand : ICommand
    {
        private GameStateController controller;
        public PauseCommand(GameStateController controller)
        {
            this.controller = controller;
        }
        public void Execute()
        {
            
            if (this.controller.gameState is PauseState)
            {
                this.controller.gameState.GamePlay();
            }
            else
            {
                this.controller.gameState.Pause();
            }
        }
    }

}


