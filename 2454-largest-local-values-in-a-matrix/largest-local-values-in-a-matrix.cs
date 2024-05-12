using System;

public class Solution {
    // Return the maximum values in the 3 x 3 matrix with top-left as (x, y).
    private int FindMax(int[][] grid, int x, int y) {
        int maxElement = 0;
        for (int i = x; i < x + 3; i++) {
            for (int j = y; j < y + 3; j++) {
                maxElement = Math.Max(maxElement, grid[i][j]);
            }
        }
        
        return maxElement;
    }
    
    public int[][] LargestLocal(int[][] grid) {
        int N = grid.Length;
        
        int[][] maxLocal = new int[N - 2][];
        for (int i = 0; i < N - 2; i++) {
            maxLocal[i] = new int[N - 2];
            for (int j = 0; j < N - 2; j++) {
                maxLocal[i][j] = FindMax(grid, i, j);
            }
        }
        
        return maxLocal;
    }
}
