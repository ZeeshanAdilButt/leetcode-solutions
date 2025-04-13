public class Solution {
   public int NthUglyNumber(int n)
    {
        // Set to avoid inserting duplicates into the heap
        HashSet<long> seen = new HashSet<long>();

        // Min-heap to always get the next smallest ugly number
        PriorityQueue<long, long> minHeap = new PriorityQueue<long, long>();

        // Initialize heap with the first ugly number: 1
        minHeap.Enqueue(1, 1);
        seen.Add(1);

        // Primes for generating ugly numbers
        int[] primes = { 2, 3, 5 };

        long current = 1;

        for (int i = 0; i < n; i++)
        {
            current = minHeap.Dequeue();

            foreach (int prime in primes)
            {
                long next = current * prime;

                // Avoid pushing duplicates into the heap
                if (!seen.Contains(next))
                {
                    seen.Add(next);
                    minHeap.Enqueue(next, next);
                }
            }
        }

        return (int)current;
    }
}