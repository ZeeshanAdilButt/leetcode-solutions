public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
         // Build adjacency list
        var adjacency = new Dictionary<int, List<(int, int)>>();

        foreach (var time in times)
        {
            int source = time[0];
            int destination = time[1];
            int travelTime = time[2];

            if (!adjacency.ContainsKey(source))
                adjacency[source] = new List<(int, int)>();

            adjacency[source].Add((destination, travelTime));
        }

        // Use built-in PriorityQueue in C# (available from .NET 6)
        var pq = new PriorityQueue<int, int>(); // (node, time) with time as priority
        pq.Enqueue(k, 0);

        var visited = new HashSet<int>();
        int delays = 0;

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int node, out int time);

            if (visited.Contains(node))
                continue;

            visited.Add(node);
            delays = Math.Max(delays, time);

            if (!adjacency.TryGetValue(node, out var neighbors))
                continue;

            foreach (var (neighborNode, neighborTime) in neighbors)
            {
                if (!visited.Contains(neighborNode))
                {
                    pq.Enqueue(neighborNode, time + neighborTime);
                }
            }
        }

        return visited.Count == n ? delays : -1;
    }
}