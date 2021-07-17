using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public static class NQueenAlgorithm
    {
        public static  bool IsAttackedCell(int x, int y, int[,] board, int N, int rows, int cols)
        {
            //check Rows
            for(int i=0;i<cols;i++)
            {
                if(board[x,i] == 1)
                {
                    return true;
                }
            }
            //check Columns
            for (int i = 0; i < rows; i++)
            {
                if (board[i,y] == 1)
                {
                    return true;
                }
            }
            //Check Diagonals
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if( (x-i)==(j-y) || (x-i) ==(y-j))
                    {
                        if (board[i, j] != null && board[i, j] == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool NQueen(int[,] board , int N)
        {
            if(N==0)//All Queens have been Placed
            {
                return true;
            }
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            if(rows !=cols)
            {
                return false;
            }
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if(IsAttackedCell(i, j, board,  N, rows, cols))
                    {
                        continue;
                    }
                    board[i,j] = 1;
                    if(NQueen(board,N-1)==true)
                    {
                        return true;
                    }
                    else
                    {
                        board[i,j] = 0;
                    }
                }
            }
            return false;
        }
    }
}
