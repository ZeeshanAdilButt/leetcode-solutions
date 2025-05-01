public class Solution {
    public int[] FindOrder(int n, int[][] prerequisites) {

         List<int> sortedOrder = new List<int>();
        if (n <= 0)
            return sortedOrder.ToArray();

        Dictionary<int, int> inDegree = new Dictionary<int, int>();
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            inDegree[i] = 0;
            graph[i] = new List<int>();
        }

        foreach (var prerequisite in prerequisites)
        {
            int parent = prerequisite[1], child = prerequisite[0];
            graph[parent].Add(child); 
            inDegree[child]++;
        }
        Queue<int> sources = new Queue<int>();
        
        foreach (var entry in inDegree)
        {
            if (entry.Value == 0)
                sources.Enqueue(entry.Key);
        }
        
        while (sources.Count > 0)
        {   
            int vertex = sources.Dequeue();
            
            sortedOrder.Add(vertex);
            List<int> children = graph[vertex]; 
            foreach (int child in children)
            {
                inDegree[child]--;
                
                if (inDegree[child] == 0)
                    sources.Enqueue(child);
            }
        }

        if (sortedOrder.Count != n) 
            return new int[0]; 

        return sortedOrder.ToArray();
    }
}