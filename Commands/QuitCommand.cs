using LegendofZelda.Interfaces;

namespace Commands
{
    public class QuitCommand : ICommand
    {
        private Game1 currGame;

        public QuitCommand(Game1 currGame)
        {
            this.currGame = currGame;
        }
        public void Execute()
        {
            currGame.Exit();
        }
    }

}


