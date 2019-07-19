// https://leetcode.com/problems/container-with-most-water/submissions/

public class Solution
{
    public int MaxArea(int[] height)
    {
        int start = 0;
        int end = height.Length - 1;
        int maxArea = 0;
        for (int area = 0; start < end;)
        {
            area = (end - start) * Math.Min(height[start], height[end]);
            if (area > maxArea)
            {
                maxArea = area;
            }
            if (height[end] <= height[start])
            {
                end--;
            }
            else
            {
                start++;
            }
        }
        
        return maxArea;
    }
}