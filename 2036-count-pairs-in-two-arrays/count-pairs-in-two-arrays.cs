public class Solution {
    public long CountPairs(int[] nums1, int[] nums2) {
        int n = nums1.Length;
        long[] difference = new long[n];

        for (int i = 0; i < n; i++) {
            difference[i] = nums1[i] - nums2[i];
        }

        Array.Sort(difference);

        long result = 0;

        for (int i = 0; i < n; i++) {
            // We want j > i such that difference[j] > -difference[i]
            int index = UpperBound(difference, -difference[i]);

            // Ensure j > i, so take max(i + 1, index)
            int validStart = Math.Max(i + 1, index);

            result += n - validStart;
        }

        return result;
    }

    // Reusable upper bound template
    public static int UpperBound(long[] arr, long target) {
        int left = 0, right = arr.Length;

        while (left < right) {
            int mid = left + (right - left) / 2;

            if (arr[mid] <= target)
                left = mid + 1;
            else
                right = mid;
        }

        return left;
    }
}
