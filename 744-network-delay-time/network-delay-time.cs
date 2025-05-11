public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        
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

        // PriorityQueue<Element=node and time, Priority=time>
        
        var pq = new PriorityQueue<(int node, int time), int>();

        pq.Enqueue((k, 0), 0);  // Start from node k with time 0

        var visited = new HashSet<int>();
        int delays = 0;

        while (pq.Count > 0)
        {
            var (node, time) = pq.Dequeue();  // Gets the node and time

            if (visited.Contains(node))
                continue;

            visited.Add(node);
            delays = Math.Max(delays, time);

            if (!adjacency.TryGetValue(node, out var neighbors))
                continue;

            foreach (var (neighbor, weight) in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    pq.Enqueue((neighbor, time + weight), time + weight);
                }
            }
        }

        return visited.Count == n ? delays : -1;
    }
}