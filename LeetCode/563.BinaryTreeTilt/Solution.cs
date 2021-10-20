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
    public int FindTilt(TreeNode root) {
        var list = new List<int>();
        return Dfs(root, list).absList.Sum();
    }

    private (int result, List<int> absList) Dfs(TreeNode root, List<int> absList) {
        if (root == null) return (0, absList);

        int left = Dfs(root.left, absList).result;
        int right = Dfs(root.right, absList).result;
        absList.Add(Math.Abs(left - right));

        return (left + right + root.val, absList);
    }
}