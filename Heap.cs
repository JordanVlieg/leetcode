// A working resizable min heap for me to use.  Pretty messy, gets the job done.

public class MinHeap
{
    private List<int?> heap;

    public MinHeap()
    {
        this.heap = new List<int?>();
    }

    public MinHeap(int?[] arr)
    {
        this.heap = arr.ToList();
        Heapify();
    }

    public int Peek()
    {
        if (heap.Count == 0)
        {
            throw new Exception("Heap is empty");
        }
        return (int)heap[0];
    }

    public bool IsTrueHeap()
    {
        // Check that it satisfies the heap property, each element should be larger than or equal to than its parent element. 
        int parent = 0;
        for (int i = 0; i < heap.Count; i++)
        {
            parent = (i-1) / 2;
            if (heap[i] < heap[parent])
            {
                return false;
            }
        }
        return true;
    }

    private void _Heapify(int i)
    {

        // Recursively heapify, top to bottom.  If an element doesnt satisfy the minheap property, swap it with the smaller of its two children and then heapify the subtree that was swapped with.
        // O(n) time cause this is kruskals method, crazy math proof.  Basically each iteration is O(h), and most values of h are small.
        int lChild = 2 * i + 1;
        int rChild = 2 * i + 2;
        int minIndex = i;
        
        if (lChild < heap.Count && heap[lChild] < heap[minIndex])
        {
            minIndex = lChild;
        }
        if (rChild < heap.Count && heap[rChild] < heap[minIndex])
        {
            minIndex = rChild;
        }
        if (minIndex != i)
        {
            int? temp = heap[i];
            heap[i] = heap[minIndex];
            heap[minIndex] = temp;
            _Heapify(minIndex);
        }
    }

    private void Heapify()
    {
        for (int i = (heap.Count - 1) / 2; i >= 0; i--)
        {
            _Heapify(i);
        }
        return;
    }

    public int? Dequeue()
    {
        if (heap.Count == 0)
        {
            throw new Exception();
        }
        var value = heap[0];

        heap[0] = heap[heap.Count - 1];
        // O(1) for the last element.
        heap.RemoveAt(heap.Count - 1);

        _Heapify(0);

        return value;
    }

    public void Enqueue(int value)
    {
        heap.Add(value);

        // Add the element to the end of the heap, then bubble it up.
        var index = heap.Count - 1;
        var parentIndex = (index - 1) / 2;
        int? temp = value;
        while (parentIndex >= 0 && heap[index] < heap[parentIndex])
        {
            temp = heap[index];
            heap[index] = heap[parentIndex];
            heap[parentIndex] = temp;
            index = parentIndex;
            parentIndex = (index - 1) / 2;
        }
    }

    public bool IsEmpty()
    {
        if (heap.Count <= 0)
        {
            return true;
        }
        return false;
    }
}