// https://leetcode.com/problems/merge-k-sorted-lists/
//
// This solution just shoves all the elements into a Priority Queue and pops them off into a new memory structure to return.  
// O(Nlog(N)) time with memory usage of O(2N) for the pq and return structure.
// A better algorithm exists to do this in O(Nlog(k)) time (k is the number of lists), if we instead only add to the PQ one element from each list at a time. May implement later.

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        MinHeap pQ = new MinHeap();
        ListNode myNode;
        for(int i = 0; i < lists.Length; i++)
        {
            myNode = lists[i];
            while(myNode != null)
            {
                pQ.Add(myNode.val);
                myNode = myNode.next;
            }
        }
        if(pQ.IsEmpty())
            return null;
        ListNode head = new ListNode(pQ.Pop());
        myNode = head;
        while(!pQ.IsEmpty())
        {
            myNode.next = new ListNode(pQ.Pop());
            myNode = myNode.next;
        }
        return head;
    }
}

public class MinHeap
{
    private List<int?> Heap;
    private int size;

    public MinHeap()
    {
        Heap = new List<int?>();
        Heap.Add(Int32.MaxValue);
    }

    public int Peek()
    {
        return (int)Heap[0];
    }

    public int Pop()
    {
        if (size == 0)
        {
            throw new Exception();
        }
        var value = Heap[0];
        var index = 0;
        Heap[0] = Heap[size - 1];
        Heap[--size] = Int32.MaxValue;
        var temp = value;
        var leftIndex = 2 * index + 1;
        var rightIndex = 2 * index + 2;
        var leftChild = leftIndex < size ? Heap[leftIndex] : null;
        var rightChild = rightIndex < size ? Heap[rightIndex] : null;
        while (Heap[index] > rightChild || Heap[index] > leftChild)
        {
            temp = Heap[index];
            if (rightChild > leftChild || rightChild == null)
            {
                Heap[index] = leftChild;
                Heap[leftIndex] = temp;
                index = leftIndex;
            }
            else
            {
                Heap[index] = rightChild;
                Heap[rightIndex] = temp;
                index = rightIndex;
            }
            leftIndex = 2 * index + 1;
            rightIndex = 2 * index + 2;
            leftChild = leftIndex < size ? Heap[leftIndex] : null;
            rightChild = rightIndex < size ? Heap[rightIndex] : null;
        }
        return (int)value;
    }

    public void Add(int value)
    {
        if (Heap.Count <= size)
        {
            Heap.Add(value);
            size++;
        }
        else
        {
            Heap[size++] = value;
        }
        var index = size - 1;
        var parentIndex = (index - 1) / 2;
        int? temp = value;
        while (parentIndex >= 0 && Heap[index] < Heap[parentIndex])
        {
            temp = Heap[index];
            Heap[index] = Heap[parentIndex];
            Heap[parentIndex] = temp;
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    public bool IsEmpty()
    {
        if (size <= 0)
        {
            return true;
        }
        return false;
    }
}