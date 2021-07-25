using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS
{
    public class NQueensAllPossibilities
    {
        public IList<IList<string>> possibilities { get; set; }
        public Dictionary<int, bool> ColsHashTable { get; set; }
        public Dictionary<int, bool> RowsHashTable { get; set; }
        public Dictionary<int, bool> PositiveDiagonalsHashTable { get; set; }
        public Dictionary<int, bool> NegativeDiagonalsHashTable { get; set; }
        public string[,] Board { get; set; }

        public NQueensAllPossibilities()
        {
            possibilities = new List<IList<string>>();

        }
        public IList<IList<string>> SolveNQueens(int n)
        {
            possibilities = new List<IList<string>>();
            // Populate the Board 
            this.InitialiseBoard(n);
            this.ColsHashTable = new Dictionary<int, bool>();
            this.RowsHashTable = new Dictionary<int, bool>();
            this.PositiveDiagonalsHashTable = new Dictionary<int, bool>();
            this.NegativeDiagonalsHashTable = new Dictionary<int, bool>();


            SolveBackTrackQueen(n, 0);
            return possibilities;
        }
        private void SolveBackTrackQueen(int n, int row)
        {
            if(row==n)
            {
                //1 Possibility Reached because we have placed all the Queens. 
                possibilities.Add(this.ConvertBoardToList());            
            }
            for (int j = 0; j < n; j++)
            {
                if (IsValidPlacement(row, j) == false)
                {
                    continue;
                }
                Board[row, j] = "Q";
                this.SavePlacementInHashTable(row, j);

                SolveBackTrackQueen(n, row+1);
                                          
                Board[row, j] = ".";
                this.RemovePlaceInHashTable(row, j);
            }      
        }
        private void InitialiseBoard(int n)
        {
            Board = new string[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Board[row, col] = ".";
                }
            }
        }
        private List<string> ConvertBoardToList()
        {
            int N = Board.GetLength(0);
            List<string> rowList = new List<string>();
            for (int row = 0; row < N; row++)
            {
                String rowValues = "";
                for (int col = 0; col < N; col++)
                {
                    rowValues= String.Concat(rowValues,Board[row, col]);
                }
                rowList.Add(rowValues);
            }
            return rowList;
        }
        private bool IsValidPlacement(int row, int col)
        {
            if (this.ColsHashTable.ContainsKey(col))
            {
                return false;
            }
            if (this.RowsHashTable.ContainsKey(row))
            {
                return false;
            }
            if (this.PositiveDiagonalsHashTable.ContainsKey(row + col))
            {
                return false;
            }
            if (this.NegativeDiagonalsHashTable.ContainsKey(row - col))
            {
                return false;
            }
            return true;
        }
        private void SavePlacementInHashTable(int row, int col)
        {
            if (!this.ColsHashTable.ContainsKey(col))
            {
                this.ColsHashTable.Add(col, true);
            }
            if (!this.RowsHashTable.ContainsKey(row))
            {
                this.RowsHashTable.Add(row, true);
            }
            if (!this.PositiveDiagonalsHashTable.ContainsKey(row + col))
            {
                this.PositiveDiagonalsHashTable.Add(row + col, true);
            }
            if (!this.NegativeDiagonalsHashTable.ContainsKey(row - col))
            {
                this.NegativeDiagonalsHashTable.Add(row - col, true);
            }
        }
        private void RemovePlaceInHashTable(int row, int col)
        {
            if (this.ColsHashTable.ContainsKey(col))
            {
                this.ColsHashTable.Remove(col);
            }
            if (this.RowsHashTable.ContainsKey(row))
            {
                this.RowsHashTable.Remove(row);
            }
            if (this.PositiveDiagonalsHashTable.ContainsKey(row + col))
            {
                this.PositiveDiagonalsHashTable.Remove(row + col);
            }
            if (this.NegativeDiagonalsHashTable.ContainsKey(row - col))
            {
                this.NegativeDiagonalsHashTable.Remove(row - col);
            }
        }
    }
}



