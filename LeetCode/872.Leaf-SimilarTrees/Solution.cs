// 872. Leaf-Similar Trees
// https://leetcode.com/problems/leaf-similar-trees/

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
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        var list1 = GetLeafList(root1);
        var list2 = GetLeafList(root2);
        return list1.SequenceEqual(list2);
    }

    private List<int> GetLeafList(TreeNode root)
    {
        var result = new List<int>();
        if (root == null) return result;

        // 子ノードがない場合のみvalueをsequenceに加える
        if (root.left == null && root.right == null)
        {
            result.Add(root.val);
        }

        result.AddRange(GetLeafList(root.left));
        result.AddRange(GetLeafList(root.right));
        return result;
    }
}
