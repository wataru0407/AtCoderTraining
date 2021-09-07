// 226. Invert Binary Tree
// https://leetcode.com/problems/invert-binary-tree/

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
    public TreeNode InvertTree(TreeNode root)
    {
        return Dfs(root);
    }

    private TreeNode Dfs(TreeNode root)
    {
        if (root == null)
        {
            return root;
        }

        var left = Dfs(root.left);
        var right = Dfs(root.right);

        // Invertするため再帰したものを左右逆にいれる
        root.left = right;
        root.right = left;

        return root;
    }
}