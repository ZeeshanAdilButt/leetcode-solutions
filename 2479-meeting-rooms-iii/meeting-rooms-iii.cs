public class Solution {

    public int MostBooked(int n, int[][] meetings) {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        
        PriorityQueue<int, int> available = new PriorityQueue<int, int>();
        
        PriorityQueue<(long endTime, int roomId), (long, int)> used = new PriorityQueue<(long, int), (long, int)>();
        
        for (int i = 0; i < n; i++) {
            available.Enqueue(i, i);
        }
        
        int[] count = new int[n];
        foreach (int[] meeting in meetings) {
            long start = meeting[0];
            long end = meeting[1];
            
            while (used.Count > 0 && used.Peek().endTime <= start) {
                int room = used.Dequeue().roomId;
                available.Enqueue(room, room);
            }
            
            if (available.Count == 0) {
                var current = used.Dequeue();
                int room = current.roomId;
                end = current.endTime + (end - start);
                available.Enqueue(room, room);
            }
            
            int assignedRoom = available.Dequeue();
            used.Enqueue((end, assignedRoom), (end, assignedRoom));
            count[assignedRoom]++;
        }
        
        int maxRoom = 0;
        for (int i = 1; i < n; i++) {
            if (count[i] > count[maxRoom]) {
                maxRoom = i;
            }
        }
        
        return maxRoom;
    }
}