using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight
{
    class Node
    {
        public int[,] board = new int[8,8];
        public List<List<int>> boardList = new List<List<int>>();
        public int currentRow = 0;
        public int currentColumn = 0;
        public int Rank = 0;

        public Node()
        {
            for (int i = 0; i < 8; i++)
            {
                List<int> t = new List<int>();
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = -1;
                    t.Add(-1);
                }
                boardList.Add(t);
            }
        }
        public void storeSite(int x,int y)
        {
            currentColumn = y;
            currentRow = x;

            board[currentRow, currentColumn] = Rank;
            boardList[currentRow][currentColumn] = Rank;
            Rank += 1;
        }

    }
}
