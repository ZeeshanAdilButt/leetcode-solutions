public class Solution {
    public int DuplicateNumbersXOR(int[] nums) {
        int ans = 0;
        int[] a = new int[51]; // Array to store the count of numbers

        // Count the occurrences of each number
        foreach (int num in nums) {
            if (num <= 50) { // Ensure the number is within the valid range
                a[num]++;
            }
        }

        // XOR the numbers which appear exactly twice
        for (int i = 1; i <= 50; i++) {
            if (a[i] == 2) {
                ans ^= i;
            }
        }

        return ans;
    }
}
