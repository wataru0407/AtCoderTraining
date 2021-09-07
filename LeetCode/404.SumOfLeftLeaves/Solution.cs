// 404. Sum of Left Leaves
// https://leetcode.com/problems/sum-of-left-leaves/

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
    public int SumOfLeftLeaves(TreeNode root)
    {
        return Dfs(root);
    }

    private int Dfs(TreeNode root, bool isLeft = false)
    {
        // 終了条件
        if (root == null)
        {
            return 0;
        }

        // リーフでかつ左ノードのときは値を返す
        if (root.left == null && root.right == null && isLeft)
        {
            return root.val;
        }

        // 左ノードは再帰を行うときにisLeft=trueとする
        var left = Dfs(root.left, true);

        // 右ノードは再帰を行うときにisLeft=falseとする
        var right = Dfs(root.right, false);

        return left + right;
    }
}