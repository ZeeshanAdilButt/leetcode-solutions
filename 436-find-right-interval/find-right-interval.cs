public class Solution {
  
public int[] FindRightInterval(int[][] intervals)
    {
        int n = intervals.Length;
        int[] result = new int[n];
        Array.Fill(result, -1);

        // Min-heap of (startValue, index)
        var startHeap = new PriorityQueue<(int start, int index), int>();
        // Min-heap of (endValue, index)
        var endHeap = new PriorityQueue<(int end, int index), int>();

        for (int i = 0; i < n; i++)
        {
            startHeap.Enqueue((intervals[i][0], i), intervals[i][0]); // priority is start value
            endHeap.Enqueue((intervals[i][1], i), intervals[i][1]);   // priority is end value
        }

        while (endHeap.Count > 0)
        {
            var (endValue, index) = endHeap.Dequeue();

            // Remove all starts that are less than the current end
            while (startHeap.Count > 0 && startHeap.Peek().start < endValue)
            {
                startHeap.Dequeue();
            }

            if (startHeap.Count > 0)
            {
                result[index] = startHeap.Peek().index;
            }
        }

        return result;
    }


//binary search solution
//    public int[] FindRightInterval(int[][] intervals)
//     {
//         int n = intervals.Length;
//         int[] result = new int[n];

//         // Create a list of (start value, index) to remember the original position
//         List<(int start, int index)> starts = new List<(int, int)>();
//         for (int i = 0; i < n; i++)
//         {
//             starts.Add((intervals[i][0], i));
//         }

//         // Sort the list based on start values (so we can binary search)
//         starts.Sort((a, b) => a.start.CompareTo(b.start));

//         // For each interval, find the smallest start >= current interval's end using binary search
//         for (int i = 0; i < n; i++)
//         {
//             int end = intervals[i][1];
//             int left = 0, right = n - 1;
//             int indexFound = -1;

//             // Binary search to find the minimal start >= end
//             while (left <= right)
//             {
//                 int mid = left + (right - left) / 2;
//                 if (starts[mid].start >= end)
//                 {
//                     indexFound = starts[mid].index;
//                     right = mid - 1; // try to find a smaller one
//                 }
//                 else
//                 {
//                     left = mid + 1;
//                 }
//             }

//             result[i] = indexFound;
//         }

//         return result;
//     }
}