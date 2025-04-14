public class Solution {
    
    // public int MaxKelements(int[] nums, int k)
    // {
    //     var maxHeap = new PriorityQueue<int, int>();
        
    //     foreach (int num in nums)
    //     {
    //         maxHeap.Enqueue(num, -num);
    //     }

    //     int score = 0;

    //     for (int i = 0; i < k; i++)
    //     {
    //         int largest = maxHeap.Dequeue();
    //         score += largest;

    //         int reduced = (largest + 2) / 3;
    //         maxHeap.Enqueue(reduced, -reduced);
    //     }

    //     return score;
    // }

    public long MaxKelements(int[] nums, int k)
    {
        // Simulate max-heap using -num as priority
        var maxHeap = new PriorityQueue<long, long>();

        foreach (int num in nums)
        {
            long val = num;
            maxHeap.Enqueue(val, -val); // max-heap using negative priority
        }

        long score = 0;

        for (int i = 0; i < k; i++)
        {
            long largest = maxHeap.Dequeue();
            score += largest;

            long reduced = (int)Math.Ceiling(largest / 3.0);
            maxHeap.Enqueue(reduced, -reduced);
        }

        return score;
    }
}