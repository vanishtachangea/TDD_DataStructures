using System.Collections;
using System.Collections.Generic;

namespace DS
{
    public class DFS_2DArrays : IDFS_2DArrays
    {
        private Dictionary<string, int> hashVisited { get; set; }
        private ArrayList arrayListTemp { get; set; }
        private int[][] directions { get; set; }
        private ArrayList traversalResults { get; set; }

        public DFS_2DArrays()
        {
            directions = new int[4][];
            directions[0] = new int[] { -1, 0 };    //Top
            directions[1] = new int[] { 0, 1 };     //Right
            directions[2] = new int[] { 1, 0 };     //Down
            directions[3] = new int[] { 0, -1 };    //Left
        }

        #region DFS
        public int[] Traverse(int[,] array2D)
        {
            hashVisited = new Dictionary<string, int>();
            traversalResults = new ArrayList();
            DFS(array2D, 0, 0);
            return (int[])traversalResults.ToArray(typeof(int));
        }

        public void DFS(int[,] array2D, int row, int col)
        {
            if (row < 0 || row >= array2D.GetLength(0) || col < 0 || col >= array2D.GetLength(1))
            {
                return;
            }
            traversalResults.Add(array2D[row, col]);

            if (!hashVisited.ContainsKey(GetStringConcatKey(row, col)))
            {
                hashVisited.Add(GetStringConcatKey(row, col), 1);
            }
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int nextRow = row + directions[i][0];
                int nextCol = col + directions[i][1];

                if (!hashVisited.ContainsKey(GetStringConcatKey(nextRow, nextCol)))
                {
                    DFS(array2D, nextRow, nextCol);
                }

            }
            ////Top
            //if (row - 1 >= 0 && !hashVisited.Contains(arrayListTemp))
            //{
            //    DFS(array2D, row - 1, col);
            //}
            ////Right
            //if (col + 1 < array2D.GetLength(1) && !hashVisited.Contains(arrayListTemp))
            //{
            //    DFS(array2D, row, col + 1);
            //}
            ////Down
            //if (row + 1 < array2D.GetLength(0) && !hashVisited.Contains(arrayListTemp))
            //{
            //    DFS(array2D, row + 1, col);
            //}
            ////Left
            //if (col - 1 < array2D.GetLength(1) && !hashVisited.Contains(arrayListTemp))
            //{
            //    DFS(array2D, row, col - 1);
            //}
            //return;
        }

        private string GetStringConcatKey(int row, int col)
        {
            return string.Concat(row.ToString(), "-", col.ToString());
        }
        #endregion

        #region BFS
        public int[] TraverseBFS(int[,] array2D)
        {
            hashVisited = new Dictionary<string, int>();
            traversalResults = new ArrayList();



            BFS(array2D);
            return (int[])traversalResults.ToArray(typeof(int));
        }

        /// <summary>
        /// T = O(N)
        /// S = O(N)
        /// </summary>
        /// <param name="array2D"></param>
        public void BFS(int[,] array2D)
        {
            Queue<int[]> valuesQueueForBFS = new Queue<int[]>();
            valuesQueueForBFS.Enqueue(new int[] { 0, 0 });

            while (valuesQueueForBFS.Count > 0)
            {
                //DeQueue
                int[] position = (int[])valuesQueueForBFS.Dequeue();
                int row = position[0];
                int col = position[1];

                if (!hashVisited.ContainsKey(GetStringConcatKey(row, col)))
                {
                    //Read
                    traversalResults.Add(array2D[row, col]);
                    hashVisited.Add(GetStringConcatKey(row, col), 1);

                    //Enqueue
                    for (int i = 0; i < directions.GetLength(0); i++)
                    {
                        int nextRow = row + directions[i][0];
                        int nextCol = col + directions[i][1];

                        if (!hashVisited.ContainsKey(GetStringConcatKey(nextRow, nextCol)) && (
                            nextRow >= 0 && nextRow < array2D.GetLength(0) && nextCol >= 0 && nextCol < array2D.GetLength(1)
                            ))
                        {
                            valuesQueueForBFS.Enqueue(new int[] { nextRow, nextCol });
                        }

                    }
                }



            }
        }

        #endregion
    }
}
