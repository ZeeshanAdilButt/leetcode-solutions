public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end) {

        var graph = new Dictionary<int, List<(int, double)>>();

        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<(int, double)>();
        }

        for (int i = 0; i < edges.Length; i++)
        {
            int u = edges[i][0], v = edges[i][1];

            double prob = succProb[i];
            
            graph[u].Add((v, prob));
            graph[v].Add((u, prob));
        }

        double[] maxProb = new double[n];
        maxProb[start] = 1.0;

        var pq = new PriorityQueue<(double, int), double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

        pq.Enqueue((1.0, start), 1.0);

        while (pq.Count > 0)
        {
            var (curProb, curNode) = pq.Dequeue();
            
            if (curNode == end)
            {
                return curProb;
            }

            foreach (var (nextNode, edgeProb) in graph[curNode])
            {
                double newProb = curProb * edgeProb;
                if (newProb > maxProb[nextNode])
                {
                    maxProb[nextNode] = newProb;
                    pq.Enqueue((newProb, nextNode), newProb);
                }
            }
        }

        return 0.0;
    }
}