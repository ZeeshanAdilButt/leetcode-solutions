public class Solution {
   
     public IList<long> MinOperations(int[] nums, int[] queries) {
        Array.Sort(nums);
        int n = nums.Length;

        long[] prefix = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + nums[i];
        }

        IList<long> answer = new List<long>();
        foreach (int query in queries)
        {
            int idx = BinarySearch(nums, query);

            long leftOperations = (long)query * idx - prefix[idx];
            long rightOperations = (prefix[n] - prefix[idx]) - (long)query * (n - idx);

            answer.Add(leftOperations + rightOperations);
        }

        return answer;
    }
    
    public static int BinarySearch(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] < target)
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