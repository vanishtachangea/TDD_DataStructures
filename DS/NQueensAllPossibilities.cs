using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public static class NQueensAllPossibilities
    {
        public static IList<IList<string>> ResultList { get; set; }
        public static StringBuilder stringBuilder { get; set; }
        public static IList<string> TempList { get; set; }
        public static string[,] board { get; set; }
        public static IList<IList<string>> SolveNQueens(int n)
        {
            board = new string[n,n];
            ResultList = new List<IList<string>>();
            TempList = new List<string>();

            stringBuilder = new StringBuilder();
            bool IsQueen = NQueens(board, n);
            if(IsQueen == true)
            {
                ResultList.Add(TempList);
            }
            return ResultList;
        }
        public static bool NQueens(string[,] board, int N)
        {            
            //If N = No of Queens
            if (N == 0)
            {
                return true;
            }
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            stringBuilder = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {             
                for (int j = 0; j < cols; j++)
                {         
                    if (IsAttacked(board, N, i, j, rows, cols))
                    {
                        continue;
                    }
                    board[i,j] = "Q";
                    stringBuilder.Append("Q");
                    if (NQueens(board, N - 1) == true)
                    {
                        return true;
                    }
                    board[i,j] = ".";
                    stringBuilder.Append(".");
                }
                TempList.Add(stringBuilder.ToString());
                stringBuilder = new StringBuilder();
            }
           
            return false;
        }
        public static bool IsAttacked(string[,] board, int N, int x, int y, int rows, int cols)
        {
            for (int j = 0; j < cols; j++)
            {
                if (board[x,j]=="Q")
                {
                    return true;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                if (board[i,y]=="Q")
                {
                    return true;
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i,j] == "Q")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}



