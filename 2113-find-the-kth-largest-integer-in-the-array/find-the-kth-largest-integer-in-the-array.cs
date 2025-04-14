public class Solution {
    // public string KthLargestNumber(string[] nums, int k) {
        
    // }

     public string KthLargestNumber(string[] nums, int k)
    {

        // Min-heap that keeps the k largest elements
        var minHeap = new PriorityQueue<string, string>(
            Comparer<string>.Create((a, b) =>
                a.Length != b.Length
                    ? a.Length.CompareTo(b.Length)
                    : string.Compare(a, b, StringComparison.Ordinal))
        );

        foreach (var num in nums)
        {
            minHeap.Enqueue(num, num);

            if (minHeap.Count > k)
                minHeap.Dequeue(); 
        }

        return minHeap.Peek(); 
    }
}