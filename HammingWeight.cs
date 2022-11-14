// https://leetcode.com/problems/number-of-1-bits/submissions/

public class Solution
{
    public int HammingWeight(uint n)
    {
        uint weight = 0;
        for (; n != 0; n = n >> 1)
        {
            weight += n & 1;
        }
        return (int)weight;
    }
}