public class Solution {

    public int NumBusesToDestination(int[][] routes, int src, int dest) {

        Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();

        for (int i = 0; i < routes.Length; i++)
        {
            foreach (int station in routes[i])
            {
                if (!adjList.ContainsKey(station))
                {
                    adjList[station] = new List<int>();
                }
                adjList[station].Add(i);
            }
        }

        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { src, 0 });

        HashSet<int> visitedBuses = new HashSet<int>();

        while (queue.Count > 0)
        {
            int[] current = queue.Peek();
            int station = current[0];
            int busesTaken = current[1];
            queue.Dequeue();

            if (station == dest)
            {
                return busesTaken;
            }

            if (adjList.ContainsKey(station))
            {
                foreach (int bus in adjList[station])
                {
                    if (!visitedBuses.Contains(bus))
                    {
                        foreach (int s in routes[bus])
                        {
                            queue.Enqueue(new int[] { s, busesTaken + 1 });
                        }
                        visitedBuses.Add(bus);
                    }
                }
            }
        }

        return -1;
    }
}