public class Solution {
    public int LeastInterval(char[] tasks, int n) {

       var freqMap = new Dictionary<char, int>();
       
        foreach (var t in tasks) {
            if (!freqMap.ContainsKey(t)) freqMap[t] = 0;
            freqMap[t]++;
        }

        var maxHeap = new PriorityQueue<char, int>();
        foreach (var kv in freqMap) {
            maxHeap.Enqueue(kv.Key, -kv.Value);  // Invert priority to simulate max-heap
        }

        var cooldownQueue = new Queue<(char task, int availableTime)>();
        int time = 0;

        while (maxHeap.Count > 0 || cooldownQueue.Count > 0) {
            time++;

            if (maxHeap.Count > 0) {
                var task = maxHeap.Dequeue();
                freqMap[task]--;

                if (freqMap[task] > 0) {
                    cooldownQueue.Enqueue((task, time + n));
                }
            }

            if (cooldownQueue.Count > 0 && cooldownQueue.Peek().availableTime == time) {
                var (task, _) = cooldownQueue.Dequeue();
                maxHeap.Enqueue(task, -freqMap[task]);
            }
        }

        return time;
        
    }
}