using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Commands
{
    public class RightRoomCommand : ICommand
    {
        private Game1 myGame;
        private Graph myGraph;
        private GameStateController myStateController;

        public RightRoomCommand(Game1 myGame, Graph myGraph, GameStateController gameStateController)
        {
            this.myGame = myGame;
            this.myGraph = myGraph;
            myStateController = gameStateController;
        }

        public void Execute()
        {
            myStateController.gameState.TransitionRight();
            myGame.currentRoomIndex = myGraph.GetRightRoom(myGame.currentRoomIndex);
            myGraph.AddToVisited(myGame.currentRoomIndex);
            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
            var background = myGame.currentRoom.Background as IBackground;
            background.SetTransitionDirection("right");

        }
    }

}


