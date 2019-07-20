// https://leetcode.com/problems/number-of-islands/

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int count = 0;
        Node[][] nodes = new Node[grid.Length][];
        for(int i = 0; i < grid.Length; i++)
        {
            nodes[i] = new Node[grid[i].Length];
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    nodes[i][j] = new Node();
                }
            }
        }
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    if (i > 0 && grid[i - 1][j] == '1')
                    {
                        Union(nodes[i - 1][j], nodes[i][j]);
                    }
                    if (j > 0 && grid[i][j - 1] == '1')
                    {
                        Union(nodes[i][j - 1], nodes[i][j]);
                    }
                    if (i + 1 < grid.Length && grid[i + 1][j] == '1')
                    {
                        Union(nodes[i + 1][j], nodes[i][j]);
                    }
                    if (j + 1 < grid[i].Length && grid[i][j + 1] == '1')
                    {
                        Union(nodes[i][j + 1], nodes[i][j]);
                    }
                }
            }
        }
        for (int i = 0; i < nodes.Length; i++)
        {
            for (int j = 0; j < nodes[i].Length; j++)
            {
                if (nodes[i][j] != null && Find(nodes[i][j]) == nodes[i][j])
                {
                    count++;
                }
            }
        }
        return count;
    }

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
    public int rank;
    public Node parent;

    public Node()
    {
        this.rank = 0;
        this.parent = this;
    }
}