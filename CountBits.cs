// https://leetcode.com/problems/counting-bits/

public class Solution
{
    public int[] CountBits(int num)
    {
        int[] bits = new int[num + 1];
        uint weight = 0;
        for(; n != 0; n = n >> 1)
        {
            weight += n & 1;
        }
        return (int)weight;
    }
}