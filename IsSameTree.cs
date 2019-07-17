// https://leetcode.com/problems/same-tree/

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
    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        if (p == null || q == null)
        {
            if (p == null && q == null)
            {
                return true;
            }
            return false;
        }
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right) && p.val == q.val;
    }
}