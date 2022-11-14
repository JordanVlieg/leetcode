// A working resizable min heap for me to use.  Pretty messy, gets the job done.
using System;
using System.Collections.Generic;

public class MinHeap
{
    private List<int> Heap;

    public MinHeap()
    {
        Heap = new List<int>();
    }

    public int Peek()
    {
        return Heap.Count > 0 ? Heap[0] : Int32.MaxValue;
    }

    public int Pop()
    {
        int val = Peek();

        Heap[0] = Heap[Heap.Count - 1];

        int index = 0;
        while (Heap[index] > Heap[LChildIndex(index)] || Heap[index] > Heap[RChildIndex(index)])
        {
            if (Heap[LChildIndex(index)] < Heap[RChildIndex(index)])
            {
                index = LChildIndex(index);
            }
            else
            {
                index = RChildIndex(index);
            }
            int swap = Heap[index];
            Heap[index] = Heap[ParentIndex(index)];
            Heap[ParentIndex(index)] = swap;
        }

        Heap.RemoveAt(Heap.Count - 1);
        return val;
    }

    public void Add(int value)
    {
        Heap.Add(value);
        int index = Heap.Count - 1;
        while (Heap[ParentIndex(index)] > Heap[index])
        {
            int swap = Heap[index];
            Heap[index] = Heap[ParentIndex(index)];
            Heap[ParentIndex(index)] = swap;
            index = ParentIndex(index);
        }
    }
    public bool IsEmpty()
    {
        return Heap.Count <= 0;
    }

    private int ParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    private int LChildIndex(int index)
    {
        int i = index * 2 + 1;
        return i < Heap.Count ? i : Heap.Count - 1;
    }

    private int RChildIndex(int index)
    {
        int i = index * 2 + 2;
        return i < Heap.Count ? i : Heap.Count - 1;
    }

    public void Print()
    {
        for (int i = 0; i < Heap.Count; i++)
        {
            Console.Write(Heap[i] + " ");
        }
    }
}

public class MaxHeap
{
    public List<int> Heap;

    public MaxHeap()
    {
        Heap = new List<int>();
    }

    public int Peek()
    {
        if (Heap.Count == 0)
        {
            return Int32.MinValue;
        }
        return Heap[0];
    }

    public int Pop()
    {
        int val = Peek();

        Heap[0] = Heap[Heap.Count - 1];

        int index = 0;
        while (Heap[index] < Heap[LChildIndex(index)] || Heap[index] < Heap[RChildIndex(index)])
        {
            if (Heap[LChildIndex(index)] > Heap[RChildIndex(index)])
            {
                index = LChildIndex(index);
            }
            else
            {
                index = RChildIndex(index);
            }
            int swap = Heap[index];
            Heap[index] = Heap[ParentIndex(index)];
            Heap[ParentIndex(index)] = swap;
        }

        Heap.RemoveAt(Heap.Count - 1);
        return val;
    }

    public void Add(int value)
    {
        Heap.Add(value);
        int index = Heap.Count - 1;
        while (Heap[ParentIndex(index)] < Heap[index])
        {
            int swap = Heap[index];
            Heap[index] = Heap[ParentIndex(index)];
            Heap[ParentIndex(index)] = swap;
            index = ParentIndex(index);
        }
    }

    public bool IsEmpty()
    {
        return Heap.Count <= 0;
    }

    private int ParentIndex(int index)
    {
        return (index - 1) / 2;
    }

    private int LChildIndex(int index)
    {
        int i = index * 2 + 1;
        return i < Heap.Count ? i : Heap.Count - 1;
    }

    private int RChildIndex(int index)
    {
        int i = index * 2 + 2;
        return i < Heap.Count ? i : Heap.Count - 1;
    }

    public void Print()
    {
        for (int i = 0; i < Heap.Count; i++)
        {
            Console.Write(Heap[i] + " ");
        }
    }

}