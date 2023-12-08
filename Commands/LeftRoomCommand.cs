using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Commands
{
    public class LeftRoomCommand : ICommand
    {
        private Game1 myGame;
        private Graph myGraph;
        private GameStateController myStateController;


        public LeftRoomCommand(Game1 myGame, Graph myGraph, GameStateController gameStateController)
        {
            this.myGame = myGame;
            this.myGraph = myGraph;
            myStateController = gameStateController;

        }

        public void Execute()
        {

            myStateController.gameState.TransitionLeft();
            myGame.currentRoomIndex = myGraph.GetLeftRoom(myGame.currentRoomIndex);
            myGraph.AddToVisited(myGame.currentRoomIndex);
            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];

            var background = myGame.currentRoom.Background as IBackground;
            background.SetTransitionDirection("left");

        }
    }

}


