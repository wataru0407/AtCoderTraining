// 783. Minimum Distance Between BST Nodes
// https://leetcode.com/problems/minimum-distance-between-bst-nodes/

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
    public int MinDiffInBST(TreeNode root)
    {
        return Dfs(root, Int32.MaxValue, Int32.MinValue + (int)Math.Pow(10, 5) + 1).min;
    }

    private (int min, int rootVal) Dfs(TreeNode root, int min, int preRootVal)
    {
        // ノードがない場合は引数の値を返す
        if (root == null)
        {
            Console.WriteLine("null");
            return (min, preRootVal);
        }

        // 左ノードに対して再帰的に実行する
        var left =  Dfs(root.left, min, preRootVal);

        // 左ノードを回ったあとの最小値と、現在のノードの値と前のノードの値の差のうち、小さいほうを返す
        var currentMin = Math.Min(left.min, root.val - left.rootVal);

        // 右ノードに対して再帰的に実行する
        var right = Dfs(root.right, currentMin, root.val);

        return right;
    }
}
