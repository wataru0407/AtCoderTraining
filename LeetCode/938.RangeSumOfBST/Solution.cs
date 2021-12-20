// 938. Range Sum of BST
// https://leetcode.com/problems/range-sum-of-bst/

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
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        return Dfs(root, low, high).Sum();
    }

    private List<int> Dfs(TreeNode root, int low, int high)
    {
        var list = new List<int>();
        if (root == null) return list;

        // lowとhighの間の場合のみlistに追加する
        if (low <= root.val && root.val <= high)
        {
            list.Add(root.val);
        }

        // 二分探索木のため、lowより大きい場合のみ左ノードを探す
        if (low < root.val)
        {
            list.AddRange(Dfs(root.left, low, high));
        }

        // 二分探索木のため、highより小さい場合のみ右ノードを探す
        if (root.val < high)
        {
            list.AddRange(Dfs(root.right, low, high));
        }
        return list;
    }

}
