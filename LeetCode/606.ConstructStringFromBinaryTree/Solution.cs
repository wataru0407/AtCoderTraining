// 606. Construct String from Binary Tree
// https://leetcode.com/problems/construct-string-from-binary-tree/

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
    public string Tree2str(TreeNode root) {
        var stringBuilder = new StringBuilder();
        return Dfs(root, stringBuilder).ToString();
    }

    private StringBuilder Dfs(TreeNode root, StringBuilder builder)
    {
        // 終了条件
        if (root == null)
        {
            return builder;
        }

        var result = builder.Append(root.val);

        // 右ノードのみあるときは"()"を出力したいため root.right != null の条件も加える
        if (root.left != null || root.right != null)
        {
            result.Append("(");
            Dfs(root.left, result);
            result.Append(")");
        }

        if (root.right != null)
        {
            result.Append("(");
            Dfs(root.right, result);
            result.Append(")");
        }

        return result;
    }
}