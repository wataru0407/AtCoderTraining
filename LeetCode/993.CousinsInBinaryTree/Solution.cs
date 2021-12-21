// 993. Cousins in Binary Tree
// https://leetcode.com/tag/depth-first-search/

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
    public bool IsCousins(TreeNode root, int x, int y)
    {
        var result = Dfs(root, root.val, 0);

        // x, yをkeyに、深さが同じで親が異なる要素のものがあればtrueとする
        return result[x].depth == result[y].depth && result[x].parent != result[y].parent;
    }

    private Dictionary<int, (int parent, int depth)> Dfs(TreeNode node, int parent, int depth)
    {
        var dic = new Dictionary<int, (int parent, int depth)>();
        if (node == null) return dic;

        // ノードの値をkey、親の値と深さのタプルをValueとして追加する
        dic.Add(node.val, (parent, depth));

        var left = Dfs(node.left, node.val, depth + 1);
        var right = Dfs(node.right, node.val, depth + 1);

        // 再帰的に実行したものを結合して返す
        var result = dic.Concat(left).Concat(right).ToDictionary(x => x.Key, x => x.Value);
        return result;
    }
}
