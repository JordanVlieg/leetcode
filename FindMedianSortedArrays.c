#include <stdio.h>
#include <stdlib.h>

double findMedianSortedArrays(int* nums1, int nums1Size, int* nums2, int nums2Size) 
{
    int median1Pos = --nums1Size/2;
    int median2Pos = --nums2Size/2;
    int right = 0;
    int left = 0;
    int* median1 = nums1 + median1Pos;
    int* median2 = nums2 + median2Pos;

    if(*median1 > *median2)
    {
        //insert on right of large list (nums2 is larger)
        right = right + (nums1Size / 2);
        nums1Size -= (nums1Size/2);
        median1 = nums1 + (nums1Size/2);
    }
    else if(*median1 < *median2)
    {
        //insert on the left of the larger list
        left = left + (nums1Size / 2);
        nums1Size -= (nums1Size/2);
    }
    

}

void main()
{
    int testA[] = {1,3,6,9,12};
    int testB[] = {2,4,5,8,11};
    findMedianSortedArrays(testA, 5, testB, 5);
}