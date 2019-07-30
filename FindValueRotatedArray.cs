// https://leetcode.com/problems/search-in-rotated-sorted-array/

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length -1;
        int mid = 0;
        
        while(left <= right)
        {
            mid = (right + left + 1) / 2;
            if(nums[mid] == target)
            {
                return mid;
            }
            else if(nums[left] < nums[mid])
            {
                // left side doesnt contain rotation (sorted)
                if(target < nums[mid] && target >= nums[left])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                // right side is sorted
                if(target > nums[mid] && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
        return -1;
    }
}

public class Solution
{
    public int Search(int[] nums, int target)
    {
        if(nums.Length == 0)
            return -1;
        int pivot = FindMin(nums);
        int start = 0;
        int end = nums.Length - 1;
        int x = ((start + end + 1) / 2) % nums.Length; // x represents the virtual index if it was non pivoted.

        int i; // i represents the true index.

        while(start <= end)
        {
            i = (x + pivot) % nums.Length;
            if (nums[i] == target)
            {
                return i;
            }
            if (nums[i] > target)
            {
                // Its to the left
                end = x - 1;
            }
            else
            {
                // Its to the right
                start = x + 1;
            }
            x = ((start + end + 1) / 2) % nums.Length;
        }
        return -1;
    }
    public int FindMin(int[] nums)
    {
        int start = 0;
        int end = nums.Length - 1;
        int x = ((start + end + 1) / 2) % nums.Length;
        while(true)
        {
            if (nums[(x + nums.Length - 1) % nums.Length] >= nums[x])
            {
                return x;
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