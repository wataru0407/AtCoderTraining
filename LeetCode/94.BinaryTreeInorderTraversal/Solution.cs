using System;
using System.Collections.Generic;
using System.Text;

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
    public List<int> Result { get; } = new List<int>();

    public IList<int> InorderTraversal(TreeNode root)
    {
        Dfs(root);
        return Result;
    }

    private void Dfs(TreeNode root)
    {
        if (root == null)
        {
            return;
        }
        Dfs(root.left);
        Result.Add(root.val);
        Dfs(root.right);
    }
}