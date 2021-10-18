// 617. Merge Two Binary Trees
// https://leetcode.com/problems/merge-two-binary-trees/

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
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
        return Dfs(root1, root2);
    }

    private TreeNode Dfs(TreeNode root1, TreeNode root2)
    {
        if (root1 == null)
        {
            return root2;
        }
        if (root2 == null)
        {
            return root1;
        }

        var resultNode = new TreeNode();
        resultNode.val = root1.val + root2.val;
        resultNode.left = Dfs(root1.left, root2.left);
        resultNode.right = Dfs(root1.right, root2.right);
        return resultNode;
    }
}
