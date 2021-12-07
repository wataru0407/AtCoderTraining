// 671. Second Minimum Node In a Binary Tree
// https://leetcode.com/problems/second-minimum-node-in-a-binary-tree/

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
    public int FindSecondMinimumValue(TreeNode root)
    {
        var set = new SortedSet<int>();
        var result = Dfs(root, set);

        // 1つのみの場合は制約にしたがって-1を返す
        if (result.Count() == 1) return -1;

        // SortedSetの2番目を返す
        return result.ElementAt(1);
    }

    private SortedSet<int> Dfs(TreeNode root, SortedSet<int> set)
    {
        if (root == null) return set;

        set.Add(root.val);

        var left = Dfs(root.left, set);
        var right = Dfs(root.right, left);
        return right;
    }
}
