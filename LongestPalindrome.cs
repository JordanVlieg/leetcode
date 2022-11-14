public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length < 1)
            return "";
        string longest = s[0].ToString();
        for (int i = 0; i < s.Length - 1; i++)
        {
            var a = FindPalindrome(s, i, i);
            var b = FindPalindrome(s, i, i + 1);
            if (a.Length > longest.Length)
                longest = a;
            if (b.Length > longest.Length)
                longest = b;
        }
        return longest;
    }

    public string FindPalindrome(string s, int l, int r)
    {
        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            l--;
            r++;
        }
        return s.Substring(l + 1, (r - l - 1)); // Fix index overshoot
    }

}