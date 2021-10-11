// 563. Binary Tree Tilt
// https://leetcode.com/problems/binary-tree-tilt/

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
    private int result = 0;

    public int FindTilt(TreeNode root) {
        Dfs(root);
        return result;
    }
    private int Dfs(TreeNode root) {
        if (root == null) return 0;

        int left = Dfs(root.left);
        int right = Dfs(root.right);
        result += Math.Abs(left - right);

        return left + right + root.val;
    }
}