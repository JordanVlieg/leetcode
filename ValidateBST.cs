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
    List<int> list = new List<int>();

    public void Traverse(TreeNode node)
    {
        if(node.left != null)
        {
            Traverse(node.left);
        }
        list.Add(node.val);
        if(node.right != null)
        {
            Traverse(node.right);
        }
    }

    public bool IsValidBST(TreeNode root)
    {
        if(root == null)
            return true;
        Traverse(root);
        var prev = list[0];
        for(int i = 1; i < list.Count; i++)
        {
            if(prev >= list[i])
            {
                return false;
            }
            prev = list[i];
        }
        return true;
    }
}