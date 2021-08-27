// 112 Path Sum

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
public class Solution
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        return Dfs(root, 0, targetSum);
    }

    private bool Dfs(TreeNode root, int depth, int target)
    {
        // 自身のノードがnullの場合はそこで止める
        if (root == null)
        {
            return false;
        }

        int sum = depth + root.val;

        // 左右の子ノードがない場合はその時点で判定を行う
        if (root.right == null && root.left == null)
        {
            return sum == target;
        }

        // 左右のいずれかでも判定が同じならtrueを返すようにする
        return Dfs(root.left, sum, target) || Dfs(root.right, sum, target);
    }
}