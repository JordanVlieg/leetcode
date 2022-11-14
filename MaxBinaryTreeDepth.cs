// https://leetcode.com/problems/maximum-depth-of-binary-tree/

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
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        int leftDepth = MaxDepth(root.left) + 1;
        int rightDepth = MaxDepth(root.right) + 1;
        return Math.Max(leftDepth, rightDepth);
    }
}