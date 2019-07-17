// https://leetcode.com/problems/median-of-two-sorted-arrays/

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }
        long start = 0;
        long end = nums1.Length;
        long totalLength = nums1.Length + nums2.Length + 1;
        long x = (start + end) / 2;
        long y = (totalLength / 2) - x;

        var xLeft = x == 0 || nums1.Length == 0 ? Int64.MinValue : nums1[x - 1];
        var yLeft = y == 0 || nums2.Length == 0 ? Int64.MinValue : nums2[y - 1];
        var xRight = x >= nums1.Length ? Int64.MaxValue : nums1[x];
        var yRight = y >= nums2.Length ? Int64.MaxValue : nums2[y];

        while(!(xRight >= yLeft && xLeft <= yRight))
        {
            if (xRight < yLeft)
            {
                // Move towards the right of nums1
                start = x + 1;
            }
            else
            {
                // Move towards the left of nums1
                end = x - 1;
            }
            x = (start + end) / 2;
            y = (totalLength / 2) - x;
            xLeft = x == 0 ? Int64.MinValue : nums1[x - 1];
            yLeft = y == 0 ? Int64.MinValue : nums2[y - 1];
            xRight = x >= nums1.Length ? Int64.MaxValue : nums1[x];
            yRight = y >= nums2.Length ? Int64.MaxValue : nums2[y];
        }
        if ((nums1.Length + nums2.Length) % 2 == 0)
        {
            return ((double)Math.Max(xLeft, yLeft) +  (double)Math.Min(xRight, yRight)) / 2;
        }
        else
        {
            return (double)Math.Max(xLeft, yLeft);
        }
    }
}