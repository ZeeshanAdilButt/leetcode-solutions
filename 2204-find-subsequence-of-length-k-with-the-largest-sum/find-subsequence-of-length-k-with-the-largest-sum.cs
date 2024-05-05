

public class Solution {
    public int[] MaxSubsequence(int[] nums, int k) 
    {
         //min priority queue by default
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        for(int i = 0; i < nums.Length; ++i)
        {
            // adding negative of number to queue > whihc changes it to max heap
            pq.Enqueue( i, -nums[i]);
        }

        int[] result = new int[k];
        for(int i = 0; i < k; ++i)
        {
            result[i] = pq.Dequeue();
        }
        Array.Sort(result);
        for(int i = 0; i < k; ++i)
        {
            result[i] = nums[result[i]];
        }

        return result;
    }
}
