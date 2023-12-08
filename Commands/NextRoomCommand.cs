using LegendofZelda.Interfaces;
using CommonReferences;

namespace Commands
{
    public class NextRoomCommand : ICommand
    {
        private Game1 myGame;


        public NextRoomCommand(Game1 myGame)
        {
            this.myGame = myGame;

        }

        public void Execute()
        {

            if (myGame.currentRoomIndex == Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms+1)
            {
                myGame.currentRoomIndex = 0;
            }
            else
            {
                myGame.currentRoomIndex++;
            }

            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
        }
    }

}


