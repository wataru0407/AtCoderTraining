// 104 Maximum Depth of Binary Tree
// https://leetcode.com/problems/maximum-depth-of-binary-tree

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
    public int MaxDepth(TreeNode root) {
        return Dfs(root);
    }

    private int Dfs(TreeNode root)
    {
        // ノードが空の場合は0を返す
        if (root == null)
        {
            return 0;
        }

        // 左右ノードの最大値に1を足した数を再帰的に計算する
        return (Math.Max(Dfs(root.left), Dfs(root.left)) + 1;
    }
}