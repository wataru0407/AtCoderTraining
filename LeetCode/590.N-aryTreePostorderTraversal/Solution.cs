// 590. N-ary Tree Postorder Traversal
// https://leetcode.com/problems/n-ary-tree-postorder-traversal/

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<int> Postorder(Node root) {
        return Dfs(root);
    }

    private IList<int> Dfs(Node root)
    {
        var list = new List<int>();

        if (root == null) return list;

        foreach(var child in root.children)
        {
            list.AddRange(Dfs(child));

        }
        list.Add(root.val);
        return list;
    }
}
