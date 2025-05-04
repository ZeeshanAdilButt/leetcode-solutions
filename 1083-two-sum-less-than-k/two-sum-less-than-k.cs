public class Solution {
    public int TwoSumLessThanK(int[] nums, int k) {
         Array.Sort(nums); // Sort the array
        int left = 0, right = nums.Length - 1;
        int maxSum = -1;

        while (left < right) {
            int sum = nums[left] + nums[right];

            if (sum < k) {
                maxSum = Math.Max(maxSum, sum);
                left++; 
            } else {
                right--;
            }
        }

        return maxSum;
    }
}