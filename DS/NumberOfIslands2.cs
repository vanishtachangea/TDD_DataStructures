using System.Collections.Generic;

namespace DS
{
    public class NumberOfIslands2
    {
        private int countIslands { get; set; }
        private int[][] directions { get; set; }

        public int NumIslands(char[][] grid)
        {
            //Initialise
            countIslands = 0;
            directions = new int[4][];
            directions[0] = new int[] { -1, 0 };
            directions[1] = new int[] { 0, 1 };
            directions[2] = new int[] { 1, 0 };
            directions[3] = new int[] { 0, -1 };

            //Call Function
            FindIslands(grid);

            return countIslands;
        }
        private string GetStringPositionKey(int row, int col)
        {
            return string.Concat(row.ToString(), "-", col.ToString());
        }
        private void FindIslands(char[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                    {
                        continue;
                    }
                    BFS(grid, i, j);
                }
            }

        }
        private void BFS(char[][] grid, int startRow, int startCol)
        {

            Queue<int[]> processQueue = new Queue<int[]>();
            processQueue.Enqueue(new int[] { startRow, startCol });

            while (processQueue.Count > 0)
            {
                //Dequeue
                int[] position = processQueue.Dequeue();
                int row = position[0];
                int col = position[1];

                string stringPosition = GetStringPositionKey(row, col);

                //Do Processing

                int cellValue = grid[row][col];
                if (cellValue == '0')
                {
                    continue;
                }
                grid[row][col] = '0';

                //Enqueue Children
                for (int i = 0; i < directions.Length; i++)
                {
                    int nextRow = row + directions[i][0];
                    int nextCol = col + directions[i][1];
                    if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length)
                    {
                        processQueue.Enqueue(new int[] { nextRow, nextCol });
                    }
                }




            }

            if (processQueue.Count == 0)
            {
                countIslands += 1;
            }


        }


    }
}
