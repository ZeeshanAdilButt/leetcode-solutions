public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1)
            return new List<int> { 0 };

        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; ++i)
            adj[i] = new List<int>();

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int[] edgeCount = new int[n];
        Queue<int> leaves = new Queue<int>();

        for (int i = 0; i < n; i++) {
            edgeCount[i] = adj[i].Count;
            if (edgeCount[i] == 1)
                leaves.Enqueue(i);
        }

        while (leaves.Count > 0) {
            if (n <= 2)
                return leaves.ToList();

            int size = leaves.Count;
            for (int i = 0; i < size; ++i) {
                int node = leaves.Dequeue();
                n--;
                foreach (int neighbor in adj[node]) {
                    edgeCount[neighbor]--;
                    if (edgeCount[neighbor] == 1)
                        leaves.Enqueue(neighbor);
                }
            }
        }

        return new List<int>();
    }
}
