// 101 Symmetric Tree
// https://leetcode.com/problems/symmetric-tree/

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
    public bool IsSymmetric(TreeNode root)
    {
        // 与えられた親ノードに対して、左右の子ノードを引数に実行する
        return Dfs(root.right, root.left);
    }

    private bool Dfs(TreeNode p, TreeNode q)
    {
        // 両方ともnullの場合はここで止めるためtrueを返す
        if (p == null && q == null)
        {
            return true;
        }

        // いずれか一方のみnullの場合は鏡面になっていないためfalseを返す
        if (p == null || q == null)
        {
            return false;
        }

        // 値が異なる場合は鏡面になっていないためfalseを返す
        if (p.val != q.val)
        {
            return false;
        }

        // 鏡面を確認するため、pの子の右ノードとqの子の左ノード、pの子の左ノードとqの子の右ノードに対して再帰的に実行する
        return Dfs(p.right, q.left) && Dfs(p.left, q.right);
    }
}