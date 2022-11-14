// https://leetcode.com/problems/binary-tree-level-order-traversal/

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    IList<IList<int>> order = new List<IList<int>>();
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        Traverse(root, 0);
        return order;
    }
    public void Traverse(TreeNode root, int level)
    {
        if (root == null)
        {
            return;
        }
        if (level >= order.Count)
        {
            order.Add(new List<int>());
        }
        order[level].Add(root.val);
        Traverse(root.left, level + 1);
        Traverse(root.right, level + 1);
    }
}