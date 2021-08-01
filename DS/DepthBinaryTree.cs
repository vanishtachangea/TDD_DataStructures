using System;

namespace DS
{

    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class DepthBinaryTree
    {

        public int MaxDepth(TreeNode root)
        {
            int cnt = 0;
            if (root != null)
            {
                cnt = DFS(root, 0);
            }
            return cnt;
        }
        public int DFS(TreeNode root, int cnt)
        {
            if (root == null)
            {
                return cnt;
            }
            if (root != null)
            {
                cnt += 1;
                return Math.Max(DFS(root.left, cnt), DFS(root.right, cnt));
            }
            return cnt;

        }
    }
}
