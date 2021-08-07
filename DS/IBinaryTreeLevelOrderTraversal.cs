using System.Collections.Generic;

namespace DS
{
    public interface IBinaryTreeLevelOrderTraversal
    {
        IList<IList<int>> LevelOrder(TreeNode root);
    }
}
