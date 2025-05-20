public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var events = new List<(int x, int height, bool isStart)>();

        // 1. Break buildings into events
        foreach (var b in buildings)
        {
            events.Add((b[0], b[2], true)); 
            events.Add((b[1], b[2], false));
        }

        events.Sort((a, b) => 
            a.x != b.x ? a.x.CompareTo(b.x) : 
            a.isStart != b.isStart ? (a.isStart ? -1 : 1) : 
            (a.isStart ? b.height.CompareTo(a.height) : a.height.CompareTo(b.height))
        );


        // 3. Max heap for active heights
        var maxHeap = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        maxHeap[0] = 0; // ground level
        int prevMax = 0;

        var result = new List<int[]>();

        // 4. Process events
        foreach (var (x, h, isStart) in events)
        {
            if (isStart)
            {
                if (!maxHeap.ContainsKey(h)) 
                    maxHeap[h] = 0;
                
                maxHeap[h]++;
            }
            else
            {
                maxHeap[h]--;
                
                if (maxHeap[h] == 0) 
                    maxHeap.Remove(h);
            }

            int currMax = maxHeap.First().Key;

            if (currMax != prevMax)
            {
                result.Add(new int[] { x, currMax });
                prevMax = currMax;
            }
        }

        return result.ToArray();
    }
}