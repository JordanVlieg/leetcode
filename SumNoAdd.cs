// https://leetcode.com/problems/sum-of-two-integers/submissions/

public class Solution
{
    public int GetSum(int a, int b)
    {
        int carry = (a & b) << 1;
        int sum = a ^ b;
        int temp = 0;
        while (carry != 0)
        {
            temp = carry;
            carry = (sum & carry) << 1;
            sum = sum ^ temp;
        }
        return sum;
    }
}
