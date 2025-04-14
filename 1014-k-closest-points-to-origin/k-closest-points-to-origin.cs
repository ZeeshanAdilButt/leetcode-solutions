public class Solution {
   
   public int[][] KClosest(int[][] points, int k)
    {
        // Max heap: store (point, distance), use -distance as priority
        var maxHeap = new PriorityQueue<(int[] point, int dist), int>();

        // Add first k points
        for (int i = 0; i < k; i++)
        {
            int dist = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            maxHeap.Enqueue((points[i], dist), -dist); // store original dist, but use -dist as priority
        }

        // Process remaining points
        for (int i = k; i < points.Length; i++)
        {
            int dist = points[i][0] * points[i][0] + points[i][1] * points[i][1];

            // Get current max (peek top)
            var (topPoint, topDist) = maxHeap.Peek();

            if (dist < topDist)
            {
                maxHeap.Dequeue();
                maxHeap.Enqueue((points[i], dist), -dist);
            }
        }

        // Extract results
        int[][] result = new int[k][];
        for (int i = 0; i < k; i++)
        {
            result[i] = maxHeap.Dequeue().point;
        }

        return result;
    }
}