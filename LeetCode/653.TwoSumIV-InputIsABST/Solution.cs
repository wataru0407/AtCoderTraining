// 653. Two Sum IV - Input is a BST
// https://leetcode.com/problems/two-sum-iv-input-is-a-bst/

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
    public bool FindTarget(TreeNode root, int k)
    {
        var set = new HashSet<int>();
        return Dfs(root, set, k);
    }

    private bool Dfs(TreeNode root, HashSet<int> set, int k)
    {
        // nullの場合はfalse
        if(root == null) return false;

        // 引数のHashSetに(k - rootの値)が含まれていれば、合わせてkになる数値の組があることになるのでtrue
        if(set.Contains(k - root.val)) return true;

        // 引数のHashSetにrootの値を追加する
        set.Add(root.val);

        // 左右のノードを再帰的に探す(1つでも条件に当てはまればtrueでよいのでor条件とする)
        return Dfs(root.left, set, k) || Dfs(root.right, set, k);
    }
}
