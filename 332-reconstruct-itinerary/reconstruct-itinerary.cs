public class Solution {
    private readonly Dictionary<string, PriorityQueue<string, string>> graph = new();
    private readonly List<string> itinerary = new();

    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        // Build graph with priority queue for lexical order
        foreach (var ticket in tickets) {
            string from = ticket[0], to = ticket[1];
            if (!graph.ContainsKey(from))
                graph[from] = new PriorityQueue<string, string>();
            graph[from].Enqueue(to, to);
        }

        DFS("JFK");
        itinerary.Reverse(); // Hierholzer builds path in reverse
        return itinerary;
    }

    private void DFS(string airport) {
        var pq = graph.GetValueOrDefault(airport);
        while (pq != null && pq.Count > 0) {
            string next = pq.Dequeue();
            DFS(next);
        }
        itinerary.Add(airport);
    }
}
