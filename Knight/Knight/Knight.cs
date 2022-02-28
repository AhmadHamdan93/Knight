using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight
{
    class Knight
    {
        Queue<Node> stack;
        List<Node> solutions;
        int[,] move = { { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 },
                      { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 } };

        public Knight()
        {
            stack = new Queue<Node>();
            solutions = new List<Node>();
        }

        public void Search()
        {
            this.solutions = new List<Node>();
            this.stack = new Queue<Node>();
            // ---------- init solution ---------------
            InitalSolutions();
            // ---------------------------------------

            // ------- loop -------------------------
            while (stack.Count != 0)
            {
                Node n = stack.Dequeue();
                if (n.Rank == 64)
                {
                    solutions.Add(n);
                    break;
                }
                else
                {
                    Generation(n);
                }
            }
            // ------------------ end loop ----------------
        }

        void Generation(Node n)
        {
            
            for (int i = 0; i < 8; i++)
            {
                Node sol = copyNode(n);
                int x = move[i, 0];     
                int y = move[i, 1];     
                int row = sol.currentRow;
                int col = sol.currentColumn;
                if (CheckMove(row, col, x, y))
                {
                    if(n.boardList[row+x][col+y] == -1)
                    {
                        sol.storeSite(row + x, col + y);
                        stack.Enqueue(sol);
                    }
                    
                }
            }

        }

        void InitalSolutions()
        {
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        Node n = new Node();
            //        n.storeSite(i, j);
            //        stack.Push(n);
            //    }
            //}
            Node n = new Node();
            n.storeSite(0, 0);
            stack.Enqueue(n);
        }

        Node copyNode(Node sol)
        {
            Node n = new Node();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int x1 = sol.board[i, j];
                    n.board[i, j] = x1;
                    int x2 = sol.boardList[i][j];
                    n.boardList[i][j] = x2;
                }
            }
            n.currentColumn = sol.currentColumn;
            n.currentRow = sol.currentRow;
            n.Rank = sol.Rank;

            return n;
        }

        Boolean CheckMove(int row, int col, int delta_x, int delta_y)
        {
            if (delta_x + row < 0)
                return false;
            if (delta_y + col < 0)
                return false;
            if (delta_x + row > 7)
                return false;
            if (delta_y + col > 7)
                return false;
            return true;
        }

        public List<Node> getSolution()
        {
            return solutions;
        }

    }
}
