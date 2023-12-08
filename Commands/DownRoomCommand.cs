using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Commands
{
    public class DownRoomCommand : ICommand
    {
        private Game1 myGame;
        private Graph myGraph;
        private GameStateController myStateController;


        public DownRoomCommand(Game1 myGame, Graph myGraph, GameStateController gameStateController)
        {
            this.myGame = myGame;
            this.myGraph = myGraph;
            myStateController = gameStateController;

        }

        public void Execute()
        {
            myStateController.gameState.TransitionDown();
            myGame.currentRoomIndex = myGraph.GetDownRoom(myGame.currentRoomIndex);
            myGraph.AddToVisited(myGame.currentRoomIndex);
            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];

            var background = myGame.currentRoom.Background as IBackground;
            if (myGame.currentRoomIndex == 17 ) //cave room
            {
                background.SetTransitionDirection("cave");
            }
            else
            {
                background.SetTransitionDirection("down");

            }
        }
    }

}


