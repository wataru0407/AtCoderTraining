// 100 Same Tree
// https://leetcode.com/problems/same-tree/

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
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        return Dfs(p, q);
    }

    private bool Dfs(TreeNode p, TreeNode q)
    {
        // 両方ともnullの場合はここで止めるためtrueを返す
        if (p == null && q == null)
        {
            return true;
        }

        // いずれか一方のみnullの場合は同じではないためfalseを返す
        if (p == null || q == null)
        {
            return false;
        }

        // 値が異なる場合は同じではないためfalseを返す
        if (p.val != q.val)
        {
            return false;
        }

        // 左右の子ノードに対して再帰的に実行する
        return Dfs(p.left, q.left) && Dfs(p.right, q.right);
    }
}