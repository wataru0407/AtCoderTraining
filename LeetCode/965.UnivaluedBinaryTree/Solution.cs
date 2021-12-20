// 965. Univalued Binary Tree
// https://leetcode.com/problems/univalued-binary-tree/

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
    public bool IsUnivalTree(TreeNode root)
    {
        return Dfs(root, root.val);
    }

    private bool Dfs(TreeNode node, int rootVal)
    {
        if (node == null) return true;

        if (node.val != rootVal) return false;

        return Dfs(node.left, rootVal) && Dfs(node.right, rootVal);
    }
}
