//1022. Sum of Root To Leaf Binary Numbers
// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/

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
    public int SumRootToLeaf(TreeNode root)
    {
        var str = "";
        var result = Dfs(root, str);
        return result.Select(x => Convert.ToInt32(x, 2)).Sum();
    }

    private List<string> Dfs(TreeNode node, string str)
    {
        var list = new List<string>();
        if (node == null) return list;

        var binary = str + node.val;
        if (node.left == null && node.right == null)
        {
            list.Add(binary);
            return list;
        }

        var left = Dfs(node.left, binary);
        list.AddRange(left);

        var right = Dfs(node.right, binary);
        list.AddRange(right);

        return list;
    }
}
