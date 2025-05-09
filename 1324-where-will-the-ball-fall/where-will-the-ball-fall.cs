public class Solution {
    public int[] FindBall(int[][] grid) {
        int[] result = new int[grid[0].Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = -1;
        }

        for (int col = 0; col < grid[0].Length; col++)
        {
            int currentColumn = col;

            for (int row = 0; row < grid.Length; row++)
            {
                int nextColumn = currentColumn + grid[row][currentColumn];

                if (nextColumn < 0 || nextColumn > grid[0].Length - 1 || grid[row][currentColumn] != grid[row][nextColumn])
                {
                    break;
                }

                if (row == grid.Length - 1)
                {
                    result[col] = nextColumn;
                }
                currentColumn = nextColumn;
            }
        }
        return result;
    }
}