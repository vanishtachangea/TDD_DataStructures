using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DS
{
    public class Sudoku
    {
        public Dictionary<int, List<char>> RowsHash { get; set; }
        public Dictionary<int, List<char>> ColsHash { get; set; }
        public Dictionary<int, List<char>> BoxesHash { get; set; }
        public void SolveSudoku(char[][] board)
        {
            RowsHash = new Dictionary<int, List<char>>();
            ColsHash = new Dictionary<int, List<char>>();
            BoxesHash = new Dictionary<int, List<char>>();
            int n = board.GetLength(0);
            InitialiseHashes(board, n);

            bool IsSolved = SolveBackTrackSudoku(board, n, '1', 0, 0);

        }
        private bool SolveBackTrackSudoku(char[][] board, int n, char val, int i, int j)
        {
            int boxId = -1;
            //Check Empty
            while(i<n && board[i][j] !='.')
            {
                if(j+1<n)
                {
                    j++;
                }
                else
                {
                    i++;
                    j = 0;
                }
            }


            if (i == n) //The Goal // End Result
            {
                Console.WriteLine(board);
                return true;
            }


            for (int t = 1; t <= n; t++)
            {
                boxId = GetBoxId(i, j);
                val = (char)char.Parse(t.ToString());
                if (!IsValidPlacement(i, j, val, boxId))
                {
                    continue;
                }
                board[i][j] = val;
                SaveValidPlacement(i, j, board[i][j], boxId);
                if (j + 1 < n)
                {
                    if (SolveBackTrackSudoku(board, n, val, i, j + 1) == true)
                    {
                        return true;
                    }
                }
                else
                    if(SolveBackTrackSudoku(board, n, val, i + 1, 0)==true)
                    {
                        return true;
                    }

                board[i][j] = '.';
                RemovePlacement(i, j, val, boxId);
            }
            return false;
        }

        private void InitialiseHashes(char[][] board, int n)
        {
            int boxId = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] != '.')
                    {
                        boxId = GetBoxId(i, j);
                        SaveValidPlacement(i, j, board[i][j], boxId);
                    }
                }
            }

        }
        private bool IsValidPlacement(int i, int j, char val, int boxId)
        {

            if (RowsHash.ContainsKey(i) && RowsHash[i].Contains(val))
            {
                return false;
            }
            if (ColsHash.ContainsKey(j) && ColsHash[j].Contains(val))
            {
                return false;
            }
            if (BoxesHash.ContainsKey(boxId) && BoxesHash[boxId].Contains(val))
            {
                return false;
            }
            return true;
        }
        private void SaveValidPlacement(int i, int j, char val, int boxId)
        {
            if (!RowsHash.ContainsKey(i))
            {
                List<char> list = new List<char>();
                list.Add(val);
                RowsHash.Add(i, list);
            }
            else if (RowsHash.ContainsKey(i) && !RowsHash[i].Contains(val))
            {
                RowsHash[i].Add(val);
            }

            if (ColsHash.ContainsKey(j) && !ColsHash[j].Contains(val))
            {
                ColsHash[j].Add(val);
            }
            else if (!ColsHash.ContainsKey(j))
            {
                List<char> list = new List<char>();
                list.Add(val);
                ColsHash.Add(j, list);
            }
            if (BoxesHash.ContainsKey(boxId) && !BoxesHash[boxId].Contains(val))
            {
                BoxesHash[boxId].Add(val);
            }
            else if (!BoxesHash.ContainsKey(boxId))
            {
                List<char> list = new List<char>();
                list.Add(val);
                BoxesHash.Add(boxId, list);
            }
        }

        private void RemovePlacement(int i, int j, char val, int boxId)
        {
            if (RowsHash.ContainsKey(i) && RowsHash[i].Contains(val))
            {
                RowsHash[i].Remove(val);
            }
            if (ColsHash.ContainsKey(j) && ColsHash[j].Contains(val))
            {
                ColsHash[j].Remove(val);
            }
            if (BoxesHash.ContainsKey(boxId) && BoxesHash[boxId].Contains(val))
            {
                BoxesHash[boxId].Remove(val);
            }
        }
        private int GetBoxId(int i, int j)
        {
            int rowValue = (int)Math.Floor(i / 3.0) * 3;
            int colValue = (int)Math.Floor(j / 3.0);
            return rowValue + colValue;
        }
    }
}
