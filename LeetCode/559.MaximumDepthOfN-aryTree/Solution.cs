// 559. Maximum Depth of N-ary Tree
// https://leetcode.com/problems/maximum-depth-of-n-ary-tree/

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

public class Solution
{
    public int MaxDepth(Node root)
    {
        return Dfs(root);
    }

    private int Dfs(Node root)
    {
        if (root == null) return 0;

        if (root.children == null) return 1;

        var result = 1;
        foreach(var child in root.children)
        {
            result = Math.Max(result, Dfs(child)+1);

        }
        return result;
    }
}
