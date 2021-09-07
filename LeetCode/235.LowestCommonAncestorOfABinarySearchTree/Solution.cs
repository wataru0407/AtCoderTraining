// 235. Lowest Common Ancestor of a Binary Search Tree
// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        // DFSの前にp < qの状態にしておく
        if (p.val > q.val)
        {
            (p, q) = (q, p);
        }

        return Dfs(root, p, q);
    }

    private TreeNode Dfs(TreeNode root, TreeNode p, TreeNode q)
    {

        // 二分探索木のため p <= root <= q を満たしている場合はrootがLCAとなる
        if (p.val <= root.val && root.val <= q.val)
        {
            return root;
        }

        // q < root の場合はLCAは左ノードにあるためそこを探索する
        if (q.val < root.val)
        {
            return Dfs(root.left, p, q);
        }
        // root < p の場合はLCAは右ノードにあるためそこを探索する
        else
        {
            return Dfs(root.right, p, q);
        }
    }
}