public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        UnionFind uf = new UnionFind(n);

        foreach (var edge in edges)
        {
            uf.Union(edge[0], edge[1]);
        }

        return uf.Find(source) == uf.Find(destination);
    }

    public class UnionFind
    {
        private int[] parent;

        public UnionFind(int size)
        {
            parent = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]); // path compression
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
                parent[rootX] = rootY;
        }
    }
}

// public class Solution
// {
//     public bool ValidPath(int n, int[][] edges, int source, int destination)
//     {
//         // Step 1: Build the graph
//         var graph = new Dictionary<int, List<int>>();
//         for (int i = 0; i < n; i++)
//             graph[i] = new List<int>();

//         foreach (var edge in edges)
//         {
//             graph[edge[0]].Add(edge[1]);
//             graph[edge[1]].Add(edge[0]);
//         }

//         // Step 2: DFS traversal
//         var visited = new HashSet<int>();
//         return Dfs(graph, source, destination, visited);
//     }

//     private bool Dfs(Dictionary<int, List<int>> graph, int current, int target, HashSet<int> visited)
//     {
//         if (current == target) return true;
//         if (visited.Contains(current)) return false;

//         visited.Add(current);

//         foreach (int neighbor in graph[current])
//         {
//             if (Dfs(graph, neighbor, target, visited))
//                 return true;
//         }

//         return false;
//     }
// }
