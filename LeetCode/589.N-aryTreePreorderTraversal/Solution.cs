// 589. N-ary Tree Preorder Traversal
// https://leetcode.com/problems/n-ary-tree-preorder-traversal/

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution
{
    public IList<int> Preorder(Node root)
    {
        return Dfs(root);
    }

    private IList<int> Dfs(Node root)
    {
        var list = new List<int>();

        if (root == null) return list;

        list.Add(root.val);

        foreach(var child in root.children)
        {
            list.AddRange(Dfs(child));

        }
        return list;
    }
}
