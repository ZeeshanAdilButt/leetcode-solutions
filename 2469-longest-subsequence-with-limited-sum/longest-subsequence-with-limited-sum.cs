public class Solution {
    public int[] AnswerQueries(int[] nums, int[] queries) {

        Array.Sort(nums);

        int[] prefixSum = new int[nums.Length];
        prefixSum[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i];
        }

        int[] answer = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            answer[i] = BinarySearch(prefixSum, queries[i]);
        }

        return answer;
    }

    public static int BinarySearch(int[] arr, int target)
    {
        int left = 0, right = arr.Length;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] <= target)
                left = mid + 1;
            else
                    right = mid;
        }

        return left;
    }
}