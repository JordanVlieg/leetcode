// https://leetcode.com/problems/kth-smallest-element-in-a-bst/

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
    int count = 0;
    int value = 0;

    public void Traverse(TreeNode node, int k)
    {
        if (node.left != null)
        {
            Traverse(node.left, k);
        }
        if(++count == k)
        {
            value = node.val;
        }
        if(count >= k)
        {
            return;
        }
        if (node.right != null)
        {
            Traverse(node.right, k);
        }
    }

    public int KthSmallest(TreeNode root, int k)
    {
        Traverse(root, k);
        return value;
    }
}