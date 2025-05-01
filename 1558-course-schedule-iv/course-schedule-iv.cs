public class Solution {
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var adj = new List<HashSet<int>>();
        var isPrereq = new List<HashSet<int>>();
        int[] indegree = new int[numCourses];

        // Initialize graph
        for (int i = 0; i < numCourses; i++) {
            adj.Add(new HashSet<int>());
            isPrereq.Add(new HashSet<int>());
        }

        // Build the adjacency list and in-degree array
        foreach (var pre in prerequisites) {
            adj[pre[0]].Add(pre[1]);
            indegree[pre[1]]++;
        }

        // Topological sort using BFS
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) {
                queue.Enqueue(i);
            }
        }

        while (queue.Count > 0) {
            int node = queue.Dequeue();
            foreach (int neighbor in adj[node]) {
                // Update the prerequisite set of the neighbor
                isPrereq[neighbor].Add(node);
                foreach (int pre in isPrereq[node]) {
                    isPrereq[neighbor].Add(pre);
                }

                indegree[neighbor]--;
                if (indegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Process queries
        var result = new List<bool>();
        foreach (var query in queries) {
            result.Add(isPrereq[query[1]].Contains(query[0]));
        }

        return result;
    }
}
