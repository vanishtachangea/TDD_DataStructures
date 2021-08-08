using System.Collections.Generic;

namespace DS
{
    /// <summary>
    /// https://leetcode.com/problems/rotting-oranges/submissions/
    /// T=0(N)
    /// S=0(N)
    /// </summary>
    public class RottingOranges
    {
        private Queue<int[]> processQueue { get; set; }
        private int[][] directions { get; set; }

        private List<int[]> rottenOranges { get; set; }
        private int countFreshOranges { get; set; }
        private int countEmpty { get; set; }

        private const int FRESH = 1;
        private const int ROTTEN = 2;
        private const int EMPTY = 0;

        public int OrangesRotting(int[][] grid)
        {

            //Initialise
            directions = new int[4][];
            directions[0] = new int[] { -1, 0 };    //top -1,0        
            directions[1] = new int[] { 0, 1 };    //right 0, 1
            directions[2] = new int[] { 1, 0 };    //bottom 1,0
            directions[3] = new int[] { 0, -1 };    //left 0 -1

            //Process
            return FindRottingOranges(grid);

        }
        private int FindRottingOranges(int[][] grid)
        {
            //Check Grid Size
            if (grid.Length == 0)
            {
                return 0;
            }

            int countMinutes = 0;
            countFreshOranges = 0;
            countEmpty = 0;

            //Find positions of rotten oranges and at the same time count the Number of Fresh Oranges
            rottenOranges = new List<int[]>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == ROTTEN)
                    {
                        int[] position = new int[] { i, j };
                        rottenOranges.Add(position);
                    }
                    else if (grid[i][j] == FRESH)
                    {
                        countFreshOranges++;
                    }
                    else
                    {
                        countEmpty++;
                    }
                }
            }

            //If No Fresh Oranges No Point Continuing
            if (countFreshOranges == 0)
            {
                return 0;
            }
            //If All are Empty cells, No point Continuing either
            if (countEmpty == (grid.Length * grid[0].Length))
            {
                return 0;
            }

            //If All are Rotten already, no point continuing 
            if (rottenOranges.Count == (grid.Length * grid[0].Length))
            {
                return 0;
            }

            //Start Processing
            processQueue = new Queue<int[]>();


            //For each rotten orange,  traverse to find the adjacent oranges which will become rotten
            for (int i = 0; i < rottenOranges.Count; i++)
            {
                processQueue.Enqueue(new int[] { rottenOranges[i][0], rottenOranges[i][1] });
            }

            countMinutes = BFS(grid);

            //Check whether we still have Fresh Oranges after the Traversals 
            if (countFreshOranges > 0)
            {
                return -1;
            }
            return countMinutes;
        }
        private int BFS(int[][] grid)
        {
            int countMinutes = 0;

            int tempCount = 0;
            int queueCount = processQueue.Count;


            while (processQueue.Count > 0)
            {
                if (tempCount == queueCount)
                {
                    countMinutes++;
                    tempCount = 0;
                    queueCount = processQueue.Count;
                }


                //DeQueue
                int[] currentPosition = processQueue.Dequeue();
                int row = currentPosition[0];
                int col = currentPosition[1];

                //Increment tempCount
                tempCount++;


                //Process
                if (grid[row][col] == FRESH)
                {
                    //Orange becomes rotten - set to 2
                    grid[row][col] = ROTTEN;
                    countFreshOranges--;
                }

                //Enqueue the children 
                for (int i = 0; i < directions.Length; i++)
                {
                    int nextRow = row + directions[i][0];
                    int nextCol = col + directions[i][1];
                    if (nextRow >= 0 && nextRow < grid.Length && nextCol >= 0 && nextCol < grid[0].Length && grid[nextRow][nextCol] == FRESH)
                    {

                        //Process
                        if (grid[nextRow][nextCol] == FRESH)
                        {
                            //Orange becomes rotten - set to 2
                            grid[nextRow][nextCol] = ROTTEN;
                            countFreshOranges--;
                        }

                        processQueue.Enqueue(new int[] { nextRow, nextCol });
                    }
                }

            }
            return countMinutes;
        }
    }
}
