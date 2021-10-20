// 543. Diameter of Binary Tree
// https://leetcode.com/problems/diameter-of-binary-tree/

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
    public int DiameterOfBinaryTree(TreeNode root) {
        var list = new List<int>();
        return Dfs(root, list).maxList.Max();
    }

    private (int result, List<int> maxList) Dfs(TreeNode root, List<int> maxList) {
        if (root == null) return (0, maxList);

        int left = Dfs(root.left, maxList).result;
        int right = Dfs(root.right, maxList).result;
        maxList.Add(left + right);

        return (Math.Max(left, right) + 1, maxList);
    }
}