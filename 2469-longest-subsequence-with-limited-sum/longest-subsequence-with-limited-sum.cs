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

    public static int BinarySearch(int[] prefixSum, int target)
    {
        int low = 0, high = prefixSum.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (prefixSum[mid] <= target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        
        return low;
    }
}