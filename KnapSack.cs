public class KnapSack
{
    int? MyPack[,];

    public int PackIterative(int capacity, int[] weight, int[] cost)
    {
        int[,] Pack = new int[weight.Length + 1, capacity + 1];

        for(int i = 0; i <= weight.Length; i++)
        {
            for(int c = 0; c <= capacity; c++)
            {
                int index = i - 1;
                if(i == 0 || c == 0)
                {
                    Pack[i, c] = 0;
                }
                else if(c < weight[index])
                {
                    Pack[i, c] = Pack[index, c]; // Item wouldnt fit in the empty pack at all.
                }
                else
                {
                    int t1 = cost[index] + Pack[index, c - weight[index]]; // Include it
                    int t2 = Pack[index, c]; // Dont include it
                    Pack[i, c] = Math.Max(t1, t2);
                }
            }
        }
        return Pack[weight.Length, capacity];

    }

    private int PackRecursiveHelper(int capacity, int[] weight, int[] cost, int n)
    {
        if(MyPack[n, capacity] != null)
        {
            return MyPack[n, capacity];
        }
        int r;
        if(capacity == 0 || n == 0)
        {
            r = 0;
        }
        else if(c < weight[index])
        {
            r = PackRecursiveHelper(capacity, weight, cost, n-1);
        }
        else
        {
            int t1 = weight[n] + PackRecursiveHelper(capacity - weight[n], weight, cost, n - 1); // Include the item
            int t2 = PackRecursiveHelper(capacity, weight, cost, n - 1); // Dont include it
            r = Math.Max(t1, t2);
        }
        MyPack[n, capacity] = r;
        return r;
    }

    public int PackRecursive(int capacity, int[] weight, int[] cost, int n)
    {
        MyPack = new int[n, capacity];
        return PackRecursiveHelper(capacity, weight, cost, n);
    }

    public List<int> PackRecursiveList(int capacity, int[] weight, int[] cost, int[] index, int n)
    {
        MyPack = new int[n, capacity];
        PackRecursiveHelper(capacity, weight, cost, n);
        int c = capacity;
        var dex = new List<int>();
        for(int i = n - 1; i >= 0; n--)
        {
            if(capacity == 0)
                break;
            if(i == 0 || MyPack[i - 1, capacity] != MyPack[i, capacity])
            {
                dex.Add(index[i]);
                capacity -= weight[i];
            }
        }
        return dex;
    }
}