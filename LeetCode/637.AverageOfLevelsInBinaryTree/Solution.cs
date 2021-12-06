// 637. Average of Levels in Binary Tree
// https://leetcode.com/problems/average-of-levels-in-binary-tree/

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
    public IList<double> AverageOfLevels(TreeNode root)
    {
        var list = new List<(int level, int val)>();

        // Dfsの返り値に対して、levelごとに平均値を算出する
        return Dfs(root, list).GroupBy(x => x.level).Select(y => y.Average(x => x.val)).ToList();
    }

    private List<(int level, int val)> Dfs(TreeNode root, List<(int level, int val)> list, int level = 1)
    {
        if (root == null) return list;

        // 引数のリストに(深さ, 数値)の組を追加する
        list.Add((level, root.val));

        // 再起的に探す前に深さに1を足す
        level++;

        var left = Dfs(root.left, list, level);
        var right = Dfs(root.right, left, level);

        return right;

    }
}
