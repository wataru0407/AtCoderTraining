// 111 Minimum Depth of Binary Tree
// https://leetcode.com/problems/minimum-depth-of-binary-tree

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
    public int MinDepth(TreeNode root)
    {
        return Dfs(root);
    }

    private int Dfs(TreeNode root)
    {
        // ノードが空の場合は0を返す
        if (root == null)
        {
            return 0;
        }

        // 左ノードがない場合は右ノードを探索して自身の深さの1を足す
        if (root.left == null)
        {
            return Dfs(root.right) + 1;
        }

        // 右ノードがない場合は左ノードを探索して自身の深さの1を足す
        if (root.right == null)
        {
            return Dfs(root.left) + 1;
        }

        // 左右の子ノードどちらもある場合は最小値をとって自身の深さの1を足す
        return (int)Math.Min(Dfs(root.left), Dfs(root.right)) + 1;

    }
}