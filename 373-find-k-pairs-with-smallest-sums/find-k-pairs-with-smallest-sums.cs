public class Solution {
   
public IList<IList<int>> KSmallestPairs(int[] list1, int[] list2, int k)
    {
        var result = new List<IList<int>>();
        if (list1.Length == 0 || list2.Length == 0 || k == 0)
            return result;

        // PriorityQueue stores ((i, j), priority), where priority = list1[i] + list2[j]
        var minHeap = new PriorityQueue<(int i, int j), int>();

        // Initialize heap with first element in list2 paired with up to k elements in list1
        for (int i = 0; i < Math.Min(k, list1.Length); i++)
        {
            minHeap.Enqueue((i, 0), list1[i] + list2[0]);
        }

        while (k-- > 0 && minHeap.Count > 0)
        {
            var (i, j) = minHeap.Dequeue();
            result.Add(new List<int> { list1[i], list2[j] });

            if (j + 1 < list2.Length)
            {
                minHeap.Enqueue((i, j + 1), list1[i] + list2[j + 1]);
            }
        }

        return result;
    }
}