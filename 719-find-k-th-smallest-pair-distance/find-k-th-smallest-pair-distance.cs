public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        Array.Sort(nums);
        int n = nums.Length;

        int low = 0;
        int high = nums[n - 1] - nums[0];

        while (low < high) {
            int mid = (low + high) / 2;
            int count = CountPairsWithMaxDistance(nums, mid, k);

            if (count < k) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }

        return low;
    }

    // Count number of pairs with distance <= maxDistance
    private int CountPairsWithMaxDistance(int[] nums, int maxDistance, int k) {
        int count = 0;
        int left = 0;

        for (int right = 0; right < nums.Length; right++) {
            while (nums[right] - nums[left] > maxDistance) {
                left++;
            }
            count += right - left;

            if(count >= k)
                   return count;
        }

        return count;
    }
}
