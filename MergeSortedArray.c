// https://leetcode.com/problems/merge-sorted-array/description/

void merge(int* nums1, int m, int* nums2, int n) {
    int* ptrA = nums1 + m - 1;
    int* ptrB = nums2 + n - 1;
    for(int i = n+m; ptrB >= nums2;)
    {
        nums1[--i] = (ptrA >= nums1 && *ptrA > *ptrB) ? *ptrA--:*ptrB--;
    }
}