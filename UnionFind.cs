public class UnionFind
{
    public Node Find(Node node)
    {
        var current = node;
        if (current.parent != current)
        {
            current.parent = Find(current.parent);
        }
        return current.parent;
    }

    public void Union(Node x, Node y)
    {
        Node xRoot = Find(x);
        Node yRoot = Find(y);
        if (xRoot == yRoot)
        {
            return;
        }
        if (xRoot.rank < yRoot.rank)
        {
            var swap = xRoot;
            xRoot = yRoot;
            yRoot = swap;
        }
        yRoot.parent = xRoot;
        if (xRoot.rank == yRoot.rank)
        {
            xRoot.rank++;
        }
    }
}

public class Node
{
    public int value;
    public int rank;
    public Node parent;
}