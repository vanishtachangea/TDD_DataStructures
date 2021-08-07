using System.Collections.Generic;

namespace DS
{

    //Definition for a binary tree node.
    //public class TreeNode2
    //{
    //    public int val;
    //    public TreeNode2 left;
    //    public TreeNode2 right;
    //    public TreeNode2(int val = 0, TreeNode2 left = null, TreeNode2 right = null)
    //    {
    //        this.val = val;
    //        this.left = left;
    //        this.right = right;
    //    }
    //}


    /// <summary>
    /// https://leetcode.com/problems/binary-tree-level-order-traversal/
    /// </summary>
    public class BinaryTreeLevelOrderTraversal : IBinaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> list { get; set; }
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            list = new List<IList<int>>();
            BFS(root);
            return list;

        }
        public void BFS(TreeNode root)
        {
            if (root != null)
            {

                List<int> tempList = new List<int>();
                Queue<TreeNode> nodesQueue = new Queue<TreeNode>();
                nodesQueue.Enqueue(root);


                while (nodesQueue.Count > 0)
                {
                    int tempCount = 0;
                    int queueLength = nodesQueue.Count;

                    while (tempCount < queueLength)
                    {
                        TreeNode temp = nodesQueue.Dequeue();
                        tempCount++;


                        //Add value to tempList
                        if (temp != null)
                        {
                            //Console.WriteLine(temp.val);
                            tempList.Add(temp.val);
                        }



                        //Enqueue Children of the Node which we have just dequeued
                        if (temp.left != null)
                            nodesQueue.Enqueue(temp.left);
                        if (temp.right != null)
                            nodesQueue.Enqueue(temp.right);
                    }
                    list.Add(tempList);
                    tempList = new List<int>();

                }
            }
        }
    }
}
