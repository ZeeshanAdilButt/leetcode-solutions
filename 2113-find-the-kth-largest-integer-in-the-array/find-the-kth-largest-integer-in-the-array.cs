public class Solution {
    // public string KthLargestNumber(string[] nums, int k) {
        
    // }

     public string KthLargestNumber(string[] nums, int k)
    {

       var maxHeap = new PriorityQueue<string, string>(
            Comparer<string>.Create((a, b) => a.Length != b.Length 
                ? b.Length.CompareTo(a.Length) 
                : string.Compare(b, a, StringComparison.Ordinal))
        );

        foreach (var num in nums)
        {
            maxHeap.Enqueue(num, num);
        }

        while (--k > 0)
        {
            maxHeap.Dequeue();
        }

        return maxHeap.Dequeue();
    }
}