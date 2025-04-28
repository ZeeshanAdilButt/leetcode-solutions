public class Solution {
   private int KadaneMax(int[] nums, int n)
    {
        int sum = nums[0];
        int maxSum = nums[0];

        for (int i = 1; i < n; i++)
        {
            sum = Math.Max(nums[i], sum + nums[i]);
            maxSum = Math.Max(maxSum, sum);
        }
        return maxSum;
    }

    private int KadaneMin(int[] nums, int n)
    {
        int sum = nums[0];
        int minSum = nums[0];

        for (int i = 1; i < n; i++)
        {
            sum = Math.Min(nums[i], sum + nums[i]);
            minSum = Math.Min(minSum, sum);
        }
        return minSum;
    }

    public int MaxSubarraySumCircular(int[] nums)
    {
        int n = nums.Length;

        // 1. Total sum of array
        int SUM = nums.Sum();

        // 2. Minimum subarray sum
        int minSum = KadaneMin(nums, n);

        // 3. Maximum subarray sum (normal case)
        int maxSum = KadaneMax(nums, n);

        // 4. Maximum circular subarray sum
        int circularSum = SUM - minSum;

        if (maxSum > 0)
        {
            return Math.Max(maxSum, circularSum);
        }

        return maxSum;
    }
}