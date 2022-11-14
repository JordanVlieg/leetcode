'''
Given an array of unsorted integers, return indices of the two numbers such that they add up to a specific target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
'''

class Solution:
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        index_map = {}
        for index, num in enumerate(nums):
            if (target - num) in index_map:
                return [index_map.get(target-num), index]
            index_map[num] = index
        print("NOT FOUND")
        return []
