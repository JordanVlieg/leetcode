// https://leetcode.com/problems/validate-binary-search-tree/

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
    int? prev = null;

    public bool Traverse(TreeNode node)
    {
        if (node.left != null)
        {
            if (!Traverse(node.left))
                return false;
        }
        if (prev >= node.val)
        {
            return false;
        }
        prev = node.val;
        if (node.right != null)
        {
            if (!Traverse(node.right))
                return false;
        }
        return true;
    }

    public bool IsValidBST(TreeNode root)
    {
        if (root == null)
            return true;
        return Traverse(root);
    }
}