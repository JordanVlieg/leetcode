// https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

public class Solution
{
    public int FindMin(int[] nums)
    {
        int start = 0;
        int end = nums.Length - 1;
        int x = ((start + end + 1) / 2) % nums.Length;
        while(true)
        {
            if (nums[(x + nums.Length - 1) % nums.Length] >= nums[x])
            {
                return nums[x];
            }
            if (nums[x] >= nums[0])
            {
                // its to the right
                start = x + 1;
            }
            else
            {
                // Its to the left
                end = x - 1;
            }
            x = ((start + end + 1) / 2) % nums.Length;
        }
    }
}