public class Solution {
    public int MinReorder(int n, int[][] connections) {
        var adj = new List<(int, int)>[n];
        for (int i = 0; i < n; i++) {
            adj[i] = new List<(int, int)>();
        }

        foreach (var conn in connections) {
            adj[conn[0]].Add((conn[1], 1)); // original direction
            adj[conn[1]].Add((conn[0], 0)); // reverse direction
        }

        var visited = new bool[n];
        var queue = new Queue<int>();
        queue.Enqueue(0);
        visited[0] = true;
        int changes = 0;

        while (queue.Count > 0) {
            int node = queue.Dequeue();
            foreach (var (neighbor, isForward) in adj[node]) {
                if (!visited[neighbor]) {
                    visited[neighbor] = true;
                    changes += isForward;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return changes;
    }
}
