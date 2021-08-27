// 110 Balanced Binary Tree
// https://leetcode.com/problems/balanced-binary-tree

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

public class Solution {
    public bool IsBalanced(TreeNode root)
    {
        return Dfs(root).isBalanced;
    }

    /**
     * タプルで返す
     * isBalance: 引数のノード以下ですべてバランスしているか
     * depth: 引数のノードの深さ
     */
    private (bool isBalanced, int depth) Dfs(TreeNode root)
    {
        if (root == null)
        {
            return (true, 0);
        }
        var (leftIsBalanced,leftDepth) = Dfs(root.left);
        var (rightIsBalanced, rightDepth) = Dfs(root.right);

        return (Math.Abs(leftDepth - rightDepth) <= 1 && leftIsBalanced && rightIsBalanced,
            Math.Max(leftDepth, rightDepth) + 1);
    }
}