using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using LegendofZelda.SpriteFactories;

namespace LegendofZelda
{
    public class Graph
    {
       
        private List<Tuple<int, int>> leftRightAdj;
        private List<Tuple<int, int>> downUpAdj;
        private bool[] visited;
        public bool[] Visited { get => visited; }

        public Graph()
        {
            leftRightAdj = new List<Tuple<int, int>>();
            downUpAdj = new List<Tuple<int, int>>();
            visited = new bool[23];
            for (int i = 1; i < 23; i++)
            {
                visited[i] = false;
            }
            visited[0] = true;
            
        }

        public void AddLeftRightEdge(int room1, int room2)
        {
            leftRightAdj.Add(new Tuple<int, int>(room1, room2));
        }

        public void RemoveDownUpEdge(int room1)
        {
            downUpAdj.RemoveAll(item => item.Item1 == room1);
        }

        public void AddDownUpEdge(int room1, int room2)
        {
            downUpAdj.Add(new Tuple<int, int>(room1, room2));
        }

        public int GetRightRoom(int currentRoomIndex)
        {
            int returner = currentRoomIndex;
            
            foreach(var tuple in leftRightAdj){

                if (tuple.Item1 == currentRoomIndex)
                {
                    returner = tuple.Item2;

                }

            }

            return returner;
        }


        public int GetLeftRoom(int currentRoomIndex)
        {
            int returner = currentRoomIndex;

            foreach (var tuple in leftRightAdj)
            {

                if (tuple.Item2 == currentRoomIndex)
                {
                    returner = tuple.Item1;

                }

            }

            return returner;

        }

        public int GetUpRoom(int currentRoomIndex)
        {
            int returner = currentRoomIndex;

            foreach (var tuple in downUpAdj)
            {

                if (tuple.Item1 == currentRoomIndex)
                {
                    returner = tuple.Item2;
                }

            }

            return returner;

        }

        public int GetDownRoom(int currentRoomIndex)
        {
            int returner = currentRoomIndex;

            foreach (var tuple in downUpAdj)
            {

                if (tuple.Item2 == currentRoomIndex)
                {
                    returner = tuple.Item1;

                }

            }

            return returner;
        }

        public void AddToVisited(int roomNumber)
        {
            if (roomNumber < 19)
            {
                visited[roomNumber] = true;
            }
        }

        public void Draw()
        {

            for(int i = 0;i<18; i++)
            {
                if (visited[i] == true)
                {
                    MapPieceSpriteFactory.Instance.CreateMapPiece(new(0, 0), i);

                }
            }

        }

    }
}
