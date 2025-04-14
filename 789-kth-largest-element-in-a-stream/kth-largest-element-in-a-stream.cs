public class KthLargest
{
    private readonly int k;
    private readonly PriorityQueue<int, int> minHeap;

    public KthLargest(int k, int[] nums)
    {
        this.k = k;
        minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }
    }

    public int Add(int val)
    {
        minHeap.Enqueue(val, val);
        if (minHeap.Count > k)
        {
            minHeap.Dequeue();
        }
        return minHeap.Peek();
    }
}
/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */