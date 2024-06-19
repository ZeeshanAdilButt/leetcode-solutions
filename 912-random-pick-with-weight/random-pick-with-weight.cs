
public class Solution {
    private int[] prefixSums;
    private int totalSum;
    private Random rand;

    public Solution(int[] w) {
        prefixSums = new int[w.Length];
        totalSum = 0;
        rand = new Random();

        // Compute prefix sums
        for (int i = 0; i < w.Length; i++) {
            totalSum += w[i];
            prefixSums[i] = totalSum;
        }
    }

    public int PickIndex() {
        // Generate a random number between 1 and totalSum (inclusive)
        int target = rand.Next(totalSum) + 1;

        // Binary search to find the right index
        int low = 0;
        int high = prefixSums.Length - 1;

        while (low < high) {
            int mid = low + (high - low) / 2;
            if (prefixSums[mid] < target) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }

        return low;
    }
}

