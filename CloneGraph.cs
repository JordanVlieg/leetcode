/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node(){}
    public Node(int _val,IList<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
}
*/
public class Solution
{
    public Node CloneGraph(Node node)
    {
        var dict = new Dictonary<Node, Node>();
        var clone = new Node(node.val, node.neighbors)
        dict.Add(node, clone);
        var q = Queue<Node>();
        //var set = new MyNode(q);
        q.Add(node);
        while (!q.IsEmpty())
        {
            Node n = q.Dequeue();
            foreach (var n in q.neighbors)
            {
                if (!dict.Contains(n))
                {
                    dict.Add(n, new Node(n.val, ))
                }
            }
        }
    }

    public MyNode Find(MyNode node)
    {
        if (node.parent != node)
        {
            node.parent = Find(node);
        }
        return node.parent;
    }

    public void Union(MyNode p, MyNode c)
    {
        var pRoot = Find(p);
        var cRoot = Find(c);
        if (pRoot == cRoot)
        {
            return;
        }

        if (pRoot.rank < cRoot.rank)
        {
            var swap = p;
            p = c;
            c = p;
        }

        cRoot.parent = pRoot;
        if (pRoot.rank == cRoot.rank)
        {
            pRoot.rank++;
        }
    }
}

public class MyNode
{
    Node value;
    int rank;
    MyNode parent;

    MyNode(Node value)
    {
        value = value;
        rank = 0;
        parent = value;
    }
}