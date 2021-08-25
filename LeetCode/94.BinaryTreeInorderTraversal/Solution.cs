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
    public IList<int> InorderTraversal(TreeNode root)
    {
        return Dfs(root).ToList();
    }

    private IEnumerable<int> Dfs(TreeNode root)
    {
        // ノードがない場合はメソッドを抜ける
        if (root == null)
        {
            yield break;
        }

        // 左ノードに対して再帰的に実行する
        foreach (var leftVal in Dfs(root.left))
        {
            yield return leftVal;
        }

        yield return root.val;

        // 右ノードに対して再帰的に実行する
        foreach (var rightVal in Dfs(root.right))
        {
            yield return rightVal;
        }
    }
}