using System;
using System.Collections.Generic;

namespace DS
{

    public class InformEmployees
    {
        private Dictionary<int, List<int>> subordinatesAdjacencyList { get; set; }
        private Dictionary<int, int> visited { get; set; }
        public List<int> traversalResult { get; set; }
        public int totalDFS { get; set; }
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {

            int totalMins = 0;
            SetSubordinatesAdjacencyList(manager);
            totalMins = BFS(headID, manager, informTime);

            return totalMins;
        }
        public void SetSubordinatesAdjacencyList(int[] manager)
        {
            subordinatesAdjacencyList = new Dictionary<int, List<int>>();
            for (int i = 0; i < manager.Length; i++)
            {
                if (manager[i] == -1)
                {
                    continue;
                }
                if (!subordinatesAdjacencyList.ContainsKey(manager[i]))
                {
                    List<int> list = new List<int>();
                    list.Add(i);
                    subordinatesAdjacencyList.Add(manager[i], list);
                }
                else
                {
                    subordinatesAdjacencyList[manager[i]].Add(i);
                }
            }
        }

        public InformEmployees()
        {
            visited = new Dictionary<int, int>();
            traversalResult = new List<int>();
            totalDFS = 0;
        }

        public void DFSTraversal(int currentManager)
        {
            if (!visited.ContainsKey(currentManager))
            {
                traversalResult.Add(currentManager);
                visited.Add(currentManager, 1);
            }
            if (subordinatesAdjacencyList.ContainsKey(currentManager))
            {
                for (int i = 0; i < subordinatesAdjacencyList[currentManager].Count; i++)
                {
                    int subordinate = subordinatesAdjacencyList[currentManager][i];
                    if (!visited.ContainsKey(subordinate))
                        DFSTraversal(subordinate);
                }
            }

        }
        public int DFSTraversalInformTime(int currentManager)
        {
            if (!subordinatesAdjacencyList.ContainsKey(currentManager))
            {
                return 0;
            }
            if (!visited.ContainsKey(currentManager))
            {
                traversalResult.Add(currentManager);
                visited.Add(currentManager, 1);
            }
            //if (subordinatesAdjacencyList.ContainsKey(currentManager))
            //{
            //    for (int i = 0; i < subordinatesAdjacencyList[currentManager].Count; i++)
            //    {
            //        int subordinate = subordinatesAdjacencyList[currentManager][i];
            //        if (!visited.ContainsKey(subordinate))
            //            int  MatDFSTraversalInformTime(subordinate);
            //    }
            //}
            //return informTime[currentManager]+ informTime[currentManager]
            return -11;

        }
        public int DFS(int headID, int[] manager, int[] informTime, int currentManager, int totalCnt)
        {
            int total = totalCnt;

            if (!subordinatesAdjacencyList.ContainsKey(currentManager) && currentManager != headID)
            {
                total += 0;
                return 0;
            }


            //get value
            if (!visited.ContainsKey(currentManager))
            {
                visited.Add(currentManager, 1);

            }

            int maxSubordinates = 0;
            for (int i = 0; i < subordinatesAdjacencyList[currentManager].Count; i++)
            {
                int subordinate = subordinatesAdjacencyList[currentManager][i];

                if (!visited.ContainsKey(subordinate))
                {
                    return Math.Max(DFS(headID, manager, informTime, subordinate, total), informTime[subordinate]);
                }

            }
            return total += maxSubordinates;

        }

        #region BFS - Does not work well
        public int BFS(int headID, int[] manager, int[] informTime)
        {
            int totalMinutes = 0;
            int totalMinutesAtLevel = 0;
            Queue<int> queue = new Queue<int>();
            visited = new Dictionary<int, int>();
            queue.Enqueue(headID);

            int tempCount = 0;
            int queueLevelCount = queue.Count;

            int level = 0;


            while (queue.Count > 0)
            {


                //Process
                int currentManager = queue.Peek();

                //About Levels
                if (tempCount == queueLevelCount)
                {
                    tempCount = 0;
                    queueLevelCount = queue.Count;
                    totalMinutes += totalMinutesAtLevel;
                    totalMinutesAtLevel = 0;
                    level++;

                }
                currentManager = queue.Dequeue();

                //Calculation for Informed Time 
                tempCount++;



                if (!visited.ContainsKey(currentManager))
                {
                    visited.Add(currentManager, 1);

                    if (currentManager == headID)
                        totalMinutesAtLevel = informTime[headID];
                    else if (subordinatesAdjacencyList.ContainsKey(currentManager))
                        totalMinutesAtLevel = Math.Max(totalMinutesAtLevel, informTime[currentManager]);

                    Console.WriteLine(string.Concat(currentManager, "-", queueLevelCount.ToString(), "-", tempCount.ToString(), "-", totalMinutes.ToString(), "-", totalMinutesAtLevel.ToString(), "-", level.ToString()));
                }





                if (!subordinatesAdjacencyList.ContainsKey(currentManager))
                    continue;

                //Enqueue Subordinates
                for (int i = 0; i < subordinatesAdjacencyList[currentManager].Count; i++)
                {
                    int subordinate = subordinatesAdjacencyList[currentManager][i];
                    if (!visited.ContainsKey(subordinate))
                        queue.Enqueue(subordinate);
                }

            }
            return totalMinutes;

        }
        //public int BFSlAST(int headID, int[] manager, int[] informTime)
        //{
        //    int totalMinutes = 0;
        //    int totalMinutesAtLevel = 0;
        //    Queue<int> queue = new Queue<int>();
        //    visited = new Dictionary<int, int>();
        //    queue.Enqueue(headID);

        //    int tempCount = 0;
        //    int queueLevelCount = queue.Count;

        //    int level = 0;


        //    while (queue.Count > 0)
        //    {


        //        //Process
        //        int currentManager = queue.Peek();

        //        //About Levels
        //        if (tempCount == queueLevelCount)
        //        {
        //            tempCount = 0;
        //            queueLevelCount = queue.Count;
        //            totalMinutes += totalMinutesAtLevel;
        //            totalMinutesAtLevel = 0;
        //            level++;

        //        }
        //        currentManager = queue.Dequeue();

        //        //Calculation for Informed Time 
        //        tempCount++;



        //        if (!visited.ContainsKey(currentManager))
        //        {
        //            visited.Add(currentManager, 1);

        //            if (currentManager == headID)
        //                totalMinutesAtLevel = informTime[headID];
        //            else if (subordinatesAdjacencyList.ContainsKey(currentManager))
        //                totalMinutesAtLevel = Math.Max(totalMinutesAtLevel, informTime[currentManager]);

        //            Console.WriteLine(string.Concat(currentManager, "-", queueLevelCount.ToString(), "-", tempCount.ToString(), "-", totalMinutes.ToString(), "-", totalMinutesAtLevel.ToString(), "-", level.ToString()));
        //        }





        //        if (!subordinatesAdjacencyList.ContainsKey(currentManager))
        //            continue;

        //        //Enqueue Subordinates
        //        for (int i = 0; i < subordinatesAdjacencyList[currentManager].Count; i++)
        //        {
        //            int subordinate = subordinatesAdjacencyList[currentManager][i];
        //            if (!visited.ContainsKey(subordinate))
        //                queue.Enqueue(subordinate);
        //        }

        //    }
        //    return totalMinutes;

        //}
        #endregion 
    }
}
