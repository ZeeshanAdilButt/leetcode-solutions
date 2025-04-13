public class Solution {
    public int ConnectSticks(int[] sticks)
    {
        int totalCost = 0;

        // Create a min-priority queue where the value and priority are the same (since we want the smallest values first)
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        // Enqueue all sticks into the priority queue
        foreach (int stick in sticks)
        {
            pq.Enqueue(stick, stick);
        }

        // While more than one stick is left, connect two smallest
        while (pq.Count > 1)
        {
            int first = pq.Dequeue();
            int second = pq.Dequeue();

            int cost = first + second;
            totalCost += cost;

            // Enqueue the new stick with its length as the priority
            pq.Enqueue(cost, cost);
        }

        return totalCost;
    }
}