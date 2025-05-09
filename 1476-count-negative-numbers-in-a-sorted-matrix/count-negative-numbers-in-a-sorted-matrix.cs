public class Solution {
    public int CountNegatives(int[][] grid) {
        int count = 0;
        int n = grid[0].Length;
        int currentIndex = n - 1;

        for (int row = 0; row < grid.Length; row++)
        {
            while (currentIndex >= 0 && grid[row][currentIndex] < 0)
            {
                currentIndex--;
            }
            count += (n - (currentIndex + 1));
        }
        return count;
    }
}