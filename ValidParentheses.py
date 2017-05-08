'''
Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
'''


class Solution(object):
    def isValid(self, s):
        """
        :type s: str
        :rtype: bool
        """
        left_braces = ['[', '{', '(']
        right_braces = [']', '}', ')']
        brace_map = {}

        for i,b in enumerate(left_braces):
            brace_map[left_braces[i]] = right_braces[i]

        stack = []
        for char in s:
            if char in left_braces:
                stack.append(char)
            if char in right_braces:
                if len(stack) == 0:
                    return False
                if brace_map[stack.pop()] == char:
                    continue
                else:
                    return False
        if len(stack) > 0:
            return False
        return True

