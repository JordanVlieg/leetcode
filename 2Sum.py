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
        left_index = 0
        right_index = len(nums) - 1
        sorted_nums = list(nums)
        sorted_nums.sort()
        while True:
            if left_index == right_index:
                print("NOT FOUND")
                return
            if sorted_nums[left_index] + sorted_nums[right_index] == target:
                return [nums.index(sorted_nums[left_index]), nums.index(sorted_nums[right_index])]
            elif sorted_nums[left_index] + sorted_nums[right_index] > target:
                right_index -= 1
            elif sorted_nums[left_index] + sorted_nums[right_index] < target:
                left_index += 1
