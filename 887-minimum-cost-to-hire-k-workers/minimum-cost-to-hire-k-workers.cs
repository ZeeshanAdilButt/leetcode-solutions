public class Solution {

    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        // Step 1: Build list of (wage-to-quality ratio, quality)
        var workers = new List<(double ratio, int quality)>();
        for (int i = 0; i < quality.Length; i++)
        {
            double ratio = (double)wage[i] / quality[i];
            workers.Add((ratio, quality[i]));
        }

        // Step 2: Sort workers by increasing ratio
        workers.Sort((a, b) => a.ratio.CompareTo(b.ratio));

        // Step 3: Use max-heap to maintain k smallest quality values
        var maxHeap = new PriorityQueue<int, int>(); // max-heap: store -q as priority
        int totalQuality = 0;
        double minCost = double.MaxValue;

        foreach (var (ratio, q) in workers)
        {
            maxHeap.Enqueue(q, -q); // simulate max-heap using -q
            totalQuality += q;

            // Maintain size k
            if (maxHeap.Count > k)
            {
                totalQuality -= maxHeap.Dequeue(); // remove largest quality
            }

            // If we have exactly k workers, calculate cost
            if (maxHeap.Count == k)
            {
                minCost = Math.Min(minCost, ratio * totalQuality);
            }
        }

        return minCost;
    }
}