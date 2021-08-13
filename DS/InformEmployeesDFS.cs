using System;
using System.Collections.Generic;

namespace DS
{

    public class InformEmployeesDFS
    {
        private Dictionary<int, List<int>> subordinatesAdjacencyList { get; set; }
        private Dictionary<int, int> visited { get; set; }
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {

            int totalMins = 0;
            SetSubordinatesAdjacencyList(manager);

            visited = new Dictionary<int, int>();

            //totalMins= BFS(headID, manager, informTime);
            totalMins = DFS(headID, manager, informTime, headID);

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

        public int DFS(int headID, int[] manager, int[] informTime, int currentManager)
        {
            if (visited.ContainsKey(currentManager))
            {
                return 0;

            }

            //get value
            if (!visited.ContainsKey(currentManager))
            {
                visited.Add(currentManager, 1);

            }


            if (!subordinatesAdjacencyList.ContainsKey(currentManager))
            {
                return 0;
            }

            int maxSubordinates = 0;
            for (int i = 0; i < subordinatesAdjacencyList[currentManager].Count; i++)
            {
                int subordinate = subordinatesAdjacencyList[currentManager][i];

                if (!visited.ContainsKey(subordinate))
                {
                    maxSubordinates = Math.Max(DFS(headID, manager, informTime, subordinate), informTime[subordinate]);
                }

            }
            return maxSubordinates + informTime[currentManager];

        }

    }
}
