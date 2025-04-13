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
    
    // public int[] FindRightInterval(int[][] intervals)
    // {
    //     int n = intervals.Length;
    //     int[] result = new int[n];
    //     Array.Fill(result, -1);
        
    //     PriorityQueue<int, int> startHeap = new PriorityQueue<int, int>();
    //     PriorityQueue<int, int> endHeap = new PriorityQueue<int, int>();
        
    //     for (int i = 0; i < n; i++)
    //     {
    //         startHeap.Enqueue(i, intervals[i][0]);
    //         endHeap.Enqueue(i, intervals[i][1]);
    //     }
        
    //     // Store all start intervals in a sorted list for binary search
    //     List<(int value, int index)> sortedStarts = new List<(int value, int index)>();
    //     while (startHeap.Count > 0)
    //     {
    //         int index = startHeap.Dequeue();
    //         sortedStarts.Add((intervals[index][0], index));
    //     }
        
    //     while (endHeap.Count > 0)
    //     {
    //         int index = endHeap.Dequeue();
    //         int endValue = intervals[index][1];
            
    //         // Binary search for the first interval that starts after or at the current end
    //         int left = 0;
    //         int right = sortedStarts.Count - 1;
    //         int resultIndex = -1;
            
    //         while (left <= right)
    //         {
    //             int mid = left + (right - left) / 2;
    //             if (sortedStarts[mid].value >= endValue)
    //             {
    //                 resultIndex = sortedStarts[mid].index;
    //                 right = mid - 1;
    //             }
    //             else
    //             {
    //                 left = mid + 1;
    //             }
    //         }
            
    //         result[index] = resultIndex;
    //     }
        
    //     return result;
    // }
}