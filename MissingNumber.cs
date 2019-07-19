// https://leetcode.com/problems/missing-number/

public class Solution
{
    public int MissingNumber(int[] nums)
    {
        int sum = 0;
        int total = nums.Length;
        for(int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            total += i;
        }
        return total - sum;
    }
}