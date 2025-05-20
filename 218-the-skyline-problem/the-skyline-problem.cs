public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var events = new List<(int x, int height, bool isStart)>();

        // 1. Break buildings into events
        foreach (var b in buildings)
        {
            events.Add((b[0], b[2], true));  // start of building
            events.Add((b[1], b[2], false)); // end of building
        }

        // 2. Sort events
        events.Sort((a, b) =>
        {
            if (a.x != b.x) return a.x.CompareTo(b.x);

            // If same x:
            if (a.isStart && b.isStart) return b.height.CompareTo(a.height); // higher first
            if (!a.isStart && !b.isStart) return a.height.CompareTo(b.height); // lower first
            return a.isStart ? -1 : 1; // start before end
        });

        // 3. Max heap for active heights
        var maxHeap = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        maxHeap[0] = 1; // ground level
        int prevMax = 0;

        var result = new List<int[]>();

        // 4. Process events
        foreach (var (x, h, isStart) in events)
        {
            if (isStart)
            {
                if (!maxHeap.ContainsKey(h)) maxHeap[h] = 0;
                maxHeap[h]++;
            }
            else
            {
                maxHeap[h]--;
                if (maxHeap[h] == 0) maxHeap.Remove(h);
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