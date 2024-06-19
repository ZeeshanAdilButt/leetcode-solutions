
public class Solution {
    public int MinimumSize(int[] nums, int maxOperations) {
        int start = 1;
        int end = nums.Max();
        int minPenalty = end;

        // Binary search on possible range
        while (start <= end) {
            int penalty = start + (end - start) / 2;
            if (IsPossible(nums, maxOperations, penalty)) {
                minPenalty = penalty;
                end = penalty - 1;
            } else {
                start = penalty + 1;
            }
        }

        return minPenalty;
    }

    private bool IsPossible(int[] nums, int maxOperations, int penalty) {
        int requiredOperations = 0;

        foreach (int num in nums) {
            int operations = num / penalty;
            if (num % penalty == 0) operations--;
            requiredOperations += operations;
        }

        return requiredOperations <= maxOperations;
    }
}