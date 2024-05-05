public class Solution {
    public int MinSwaps(int[][] grid) {
        int n = grid.Length;
        int[] zeroes = new int[n];
        
        // Count trailing zeroes in each row
        for (int i = 0; i < n; i++) {
            int count = 0;
            for (int j = n - 1; j >= 0 && grid[i][j] == 0; j--)
                count++;
            zeroes[i] = count;
        }
        
        int swaps = 0;
        
        // Greedy approach to find the minimum number of swaps
        for (int i = 0; i < n; i++) {
            int target = n - i - 1;
            if (zeroes[i] >= target)
                continue;
            int j = i + 1;
            while (j < n && zeroes[j] < target)
                j++;
            if (j == n)
                return -1; // Not possible to arrange
            while (j > i) {
                int temp = zeroes[j];
                zeroes[j] = zeroes[j - 1];
                zeroes[j - 1] = temp;
                swaps++;
                j--;
            }
        }
        
        return swaps;
    }
}
