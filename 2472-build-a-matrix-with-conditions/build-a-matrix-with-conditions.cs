public class Solution {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        
        int[] rowOrder = TopoSort(k, rowConditions);
        if (rowOrder.Length != k) return new int[0][];

        int[] colOrder = TopoSort(k, colConditions);
        if (colOrder.Length != k) return new int[0][];

        int[][] res = new int[k][];
        for (int i = 0; i < k; i++) {
            res[i] = new int[k];
        }

        int[] colIndex = new int[k + 1]; // index by value
        for (int i = 0; i < k; i++) {
            colIndex[colOrder[i]] = i;
        }

        for (int i = 0; i < k; i++) {
            int row = i;
            int col = colIndex[rowOrder[i]];
            res[row][col] = rowOrder[i];
        }

        return res;
    }

    private int[] TopoSort(int k, int[][] edges) {
        int[] indegree = new int[k + 1];
        var adj = new List<List<int>>();
        for (int i = 0; i <= k; i++) {
            adj.Add(new List<int>());
        }

        foreach (var edge in edges) {
            adj[edge[0]].Add(edge[1]);
            indegree[edge[1]]++;
        }

        Queue<int> queue = new Queue<int>();
        int[] order = new int[k];
        int idx = 0;

        for (int i = 1; i <= k; i++) {
            if (indegree[i] == 0) {
                queue.Enqueue(i);
            }
        }

        while (queue.Count > 0) {
            int node = queue.Dequeue();
            if (idx >= k) break;
            order[idx++] = node;

            foreach (int nei in adj[node]) {
                indegree[nei]--;
                if (indegree[nei] == 0) {
                    queue.Enqueue(nei);
                }
            }
        }

        return idx == k ? order : new int[0];
    }
}
