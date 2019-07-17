// https://leetcode.com/problems/climbing-stairs/

public class Solution
{
    public int ClimbStairs(int n)
    {
        int[] ways = new int{1, 1, 0};
        for (int i = 0; i < n; i++)
        {
            ways[0] = ways[1] + ways[2];
            ways[2] = ways[1];
            ways[1] = ways[0];
        }
        return ways[0];
    }
}