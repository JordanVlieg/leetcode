public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node() { }
    public Node(int _val, IList<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }