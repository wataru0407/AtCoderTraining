// 897. Increasing Order Search Tree
// https://leetcode.com/problems/increasing-order-search-tree/


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
    public TreeNode IncreasingBST(TreeNode root)
    {
        var list = InOrder(root).AsEnumerable().Reverse().ToList();
        TreeNode result = null;
        foreach(var item in list)
        {
            result = new TreeNode(item, null, result);
        }
        return result;
    }

    private List<int> InOrder(TreeNode root)
    {
        var list = new List<int>();
        if (root == null) return list;

        list.AddRange(InOrder(root.left));
        list.Add(root.val);
        list.AddRange(InOrder(root.right));
        return list;
    }
}
