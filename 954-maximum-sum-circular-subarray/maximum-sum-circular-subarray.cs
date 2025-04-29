public class Solution {

    public int MaxSubarraySumCircular(int[] nums)
    {
        int n = nums.Length;
        int[] rightMax = new int[n];
        rightMax[n - 1] = nums[n - 1];
        int suffixSum = nums[n - 1];

        for (int i = n - 2; i >= 0; --i)
        {
            suffixSum += nums[i];
            rightMax[i] = Math.Max(rightMax[i + 1], suffixSum);
        }

        int maxSum = nums[0];
        int specialSum = nums[0];
        int curMax = 0;
        int prefixSum = 0;

        for (int i = 0; i < n; ++i)
        {
            // This is Kadane's algorithm.
            curMax = Math.Max(curMax, 0) + nums[i];
            maxSum = Math.Max(maxSum, curMax);

            prefixSum += nums[i];
            if (i + 1 < n)
            {
                specialSum = Math.Max(specialSum, prefixSum + rightMax[i + 1]);
            }
        }

        return Math.Max(maxSum, specialSum);
    }

//    private int KadaneMax(int[] nums, int n)
//     {
//         int sum = nums[0];
//         int maxSum = nums[0];

//         for (int i = 1; i < n; i++)
//         {
//             sum = Math.Max(nums[i], sum + nums[i]);
//             maxSum = Math.Max(maxSum, sum);
//         }
//         return maxSum;
//     }

//     private int KadaneMin(int[] nums, int n)
//     {
//         int sum = nums[0];
//         int minSum = nums[0];

//         for (int i = 1; i < n; i++)
//         {
//             sum = Math.Min(nums[i], sum + nums[i]);
//             minSum = Math.Min(minSum, sum);
//         }
//         return minSum;
//     }

//     public int MaxSubarraySumCircular(int[] nums)
//     {
//         int n = nums.Length;

//         // 1. Total sum of array
//         int SUM = nums.Sum();

//         // 2. Minimum subarray sum
//         int minSum = KadaneMin(nums, n);

//         // 3. Maximum subarray sum (normal case)
//         int maxSum = KadaneMax(nums, n);

//         // 4. Maximum circular subarray sum
//         int circularSum = SUM - minSum;

//         if (maxSum > 0)
//         {
//             return Math.Max(maxSum, circularSum);
//         }

//         return maxSum;
//     }
}