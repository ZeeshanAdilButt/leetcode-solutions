public class Solution {

    // public int ThirdMax(int[] nums)
    // {
    //     var top = new SortedSet<int>();

    //     foreach (int num in nums)
    //     {
    //         top.Add(num);

    //         // Keep only the 3 largest numbers
    //         if (top.Count > 3)
    //         {
    //             top.Remove(top.Min); // Remove smallest
    //         }
    //     }

    //     // If we have 3 elements, return the smallest = 3rd max
    //     // Else return the largest
    //     return top.Count == 3 ? top.Min : top.Max;
    // }

    public int ThirdMax(int[] nums)
    {
        var minHeap = new PriorityQueue<int, int>();
        var seen = new HashSet<int>();

        int max = int.MinValue;

        foreach (int num in nums)
        {
             if (num > max)
                max = num;

            if (seen.Contains(num))
                continue;

            seen.Add(num);
            minHeap.Enqueue(num, num); // min-heap: priority = num

            if (minHeap.Count > 3)
            {
                minHeap.Dequeue(); // remove smallest to keep only top 3
            }
        }

        // If we have exactly 3 distinct values, return the smallest (3rd max)
        if (minHeap.Count == 3)
        {
            return minHeap.Peek(); // third max
        }
        else {
            return max;
        }
    }

    // public int ThirdMax(int[] nums) {
    //     long max1 = long.MinValue, max2 = long.MinValue, max3 = long.MinValue;
        
    //     foreach (int num in nums) {
    //         if (num > max1) {
    //             max3 = max2;
    //             max2 = max1;
    //             max1 = num;
    //         } else if (num < max1 && num > max2) {
    //             max3 = max2;
    //             max2 = num;
    //         } else if (num < max2 && num > max3) {
    //             max3 = num;
    //         }
    //     }
        
    //     return max3 != long.MinValue ? (int)max3 : (int)max1;
    // }
}
