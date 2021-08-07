using System.Collections;
using System.Collections.Generic;

namespace DS
{
    public class DFS_2DArrays :IDFS_2DArrays
    {
        private Dictionary<string, int> hashVisited { get; set; }
        private ArrayList arrayListTemp { get; set; }
        private int[][] directions { get; set; }
        private ArrayList traversalResults { get; set; }
        public int[] Traverse(int[,] array2D)
        {
            hashVisited = new Dictionary<string, int>();
            traversalResults = new ArrayList();

            directions = new int[4][];
            directions[0] = new int[] { -1, 0 };    //Top
            directions[1] = new int[] { 0, 1 };     //Right
            directions[2] = new int[] { 1, 0 };     //Down
            directions[3] = new int[] { 0, -1 };    //Left

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

            if(!hashVisited.ContainsKey(GetStringConcatKey(row,col)))
            {
                hashVisited.Add(GetStringConcatKey(row,col), 1);
            }
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int nextRow = row + directions[i][0];
                int nextCol = col + directions[i][1];

                if (!hashVisited.ContainsKey(GetStringConcatKey(nextRow, nextCol )))
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
    }
}
