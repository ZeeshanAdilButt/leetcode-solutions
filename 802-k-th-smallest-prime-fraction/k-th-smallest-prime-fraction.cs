public class Solution {
    public int[] KthSmallestPrimeFraction(int[] arr, int k)
    {
        int n = arr.Length;

        // Min-heap: we use negative fraction as priority to simulate max-heap behavior
        var pq = new PriorityQueue<(int i, int j), double>();

        // Initialize with fractions arr[i] / arr[n-1] for i in [0..n-2]
        for (int i = 0; i < n - 1; i++)
        {
            double fraction = 1.0 * arr[i] / arr[n - 1];
            pq.Enqueue((i, n - 1), fraction);
        }

        // Pop k-1 times to get the kth smallest
        while (--k > 0)
        {
            var (i, j) = pq.Dequeue();

            if (j - 1 > i)
            {
                double newFraction = 1.0 * arr[i] / arr[j - 1];
                pq.Enqueue((i, j - 1), newFraction);
            }
        }

        var (finalI, finalJ) = pq.Dequeue();
        return new int[] { arr[finalI], arr[finalJ] };
    }
}