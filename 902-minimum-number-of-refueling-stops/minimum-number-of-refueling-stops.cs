public class Solution {
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        if (startFuel >= target)
        {
            return 0;
        }

        var maxHeap = new PriorityQueue<int, int>();

        int stops = 0;
        int maxDistance = startFuel;
        int i = 0;
        int n = stations.Length;

        while (i < n && stations[i][0] <= maxDistance)
        {
            maxHeap.Enqueue(stations[i][1], -stations[i][1]);
            i++;
        }

        if (maxHeap.Count == 0 && maxDistance >= target)
        {
            return 0;
        }

        while (maxDistance < target)
        {
            if (maxHeap.Count == 0)
            {
                return -1;
            }

            maxDistance += maxHeap.Dequeue();
            stops++;

            while (i < n && stations[i][0] <= maxDistance)
            {
                maxHeap.Enqueue(stations[i][1], -stations[i][1]);
                i++;
            }
        }

        // Return the number of stops taken
        return stops;
    }
}