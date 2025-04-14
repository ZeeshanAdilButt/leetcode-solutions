public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        // Min-heap: smallest element at the top
        var minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num); // use num as both element and priority

            if (minHeap.Count > k)
            {
                minHeap.Dequeue(); // remove smallest to keep top k largest
            }
        }

        return minHeap.Peek(); // the k-th largest is now at the top
    }
}