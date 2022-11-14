'''
Reverse digits of an integer.

Example1: x = 123, return 321
Example2: x = -123, return -321
'''

class Solution(object):
    def reverse(self, x):
        """
        :type x: int
        :rtype: int
        """
        value = 0
        int_string = str(x)
        if x < 0:
            int_string.append('-')
        revers = int_string[::-1]
        if revers > 2147483647 or revers < -2147483648:
            return 0
        return int(reversed)

