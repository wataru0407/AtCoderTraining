// 144. Binary Tree Preorder Traversal
// https://leetcode.com/problems/binary-tree-preorder-traversal/

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
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var list = new List<int>();
        return Dfs(root, list);
    }

    private List<int> Dfs(TreeNode root, List<int> list)
    {
        // ノードがない場合は引数のリストを返す
        if (root == null)
        {
            return list;
        }

        // 自身のvalueを追加したListを作る
        var addList = list.Append(root.val).ToList();

        // 左ノードに対して再帰的に実行する
        var leftList =  Dfs(root.left, addList);

        // 右ノードに対して再帰的に実行する
        var rightList =  Dfs(root.right, leftList);

        return rightList;
    }
}