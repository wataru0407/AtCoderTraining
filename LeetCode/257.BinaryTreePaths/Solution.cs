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

    public IList<string> BinaryTreePaths(TreeNode root) {
        return Dfs(root).ToList();
    }

    private IEnumerable<string> Dfs(TreeNode root, IEnumerable<string> paths = null, IEnumerable<int> path = null)
    {
        // 初回呼び出しのときのみpathsをインスタンス化する
        if (paths == null)
        {
            paths = new List<string>();
        }

        // 初回呼び出しのときのみpathをインスタンス化する
        if (path == null)
        {
            path = new List<int>();
        }

        // 終了条件
        if(root == null)
        {
            return paths;
        }

        // pathに自身を加える
        var newPath = path.Append(root.val);

        // リーフの場合にpathを出力形式に変換してpathsに加えて返す
        if (root.left == null && root.right == null)
        {
            return paths.Append(string.Join("->", newPath));
        }

        // 左右のノードで探索を行う
        var left = Dfs(root.left, paths, newPath);
        var right = Dfs(root.right, paths, newPath);

        // 再帰的に実行したものをpathsに加えて返す
        return paths.Concat(left).Concat(right);
    }
}