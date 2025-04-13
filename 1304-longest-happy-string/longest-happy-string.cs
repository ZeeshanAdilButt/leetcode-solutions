public class Solution {
    public string LongestDiverseString(int a, int b, int c)
    {
        StringBuilder res = new StringBuilder();

        // PriorityQueue with inline comparer for max-heap (larger count first)
        var maxHeap = new PriorityQueue<(int count, char ch), (int count, char ch)>(
            Comparer<(int count, char ch)>.Create((a, b) => b.count.CompareTo(a.count))
        );

        // Add initial characters with their counts
        if (a > 0) maxHeap.Enqueue((a, 'a'), (a, 'a'));
        if (b > 0) maxHeap.Enqueue((b, 'b'), (b, 'b'));
        if (c > 0) maxHeap.Enqueue((c, 'c'), (c, 'c'));

        while (maxHeap.Count > 0)
        {
            var first = maxHeap.Dequeue();
            int len = res.Length;

            // Check if the last two characters are the same as this one
            if (len >= 2 && res[len - 1] == first.ch && res[len - 2] == first.ch)
            {
                if (maxHeap.Count == 0) break;

                var second = maxHeap.Dequeue();
                res.Append(second.ch);
                second.count--;

                if (second.count > 0)
                    maxHeap.Enqueue(second, second);

                maxHeap.Enqueue(first, first); // put the first back
            }
            else
            {
                res.Append(first.ch);
                first.count--;

                if (first.count > 0)
                    maxHeap.Enqueue(first, first);
            }
        }

        return res.ToString();
    }
}