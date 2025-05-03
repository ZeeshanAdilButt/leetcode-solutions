public class Solution {
    public long CountPairs(int[] nums1, int[] nums2) {
        int n = nums1.Length;
        long[] difference = new long[n];

        // Step 1: Compute difference[i] = nums1[i] - nums2[i]
        for (int i = 0; i < n; i++) {
            difference[i] = nums1[i] - nums2[i];
        }

        // Step 2: Sort the difference array
        Array.Sort(difference);

        long result = 0;

        // Step 3: Count valid pairs
        for (int i = 0; i < n; i++) {
            if (difference[i] > 0) {
                result += n - i - 1;
            } else {
                // Binary search for first j > i where difference[i] + difference[j] > 0
                int left = i + 1, right = n - 1;

                while (left <= right) {
                    int mid = left + (right - left) / 2;

                    if (difference[i] + difference[mid] > 0) {
                        right = mid - 1;
                    } else {
                        left = mid + 1;
                    }
                }

                result += n - left;
            }
        }

        return result;
    }
}
