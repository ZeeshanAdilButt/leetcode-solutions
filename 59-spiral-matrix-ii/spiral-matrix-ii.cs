public class Solution {
    public int[][] GenerateMatrix(int n) {

        int[][] result = new int[n][];

        for (int i = 0; i < n; i++) {
            result[i] = new int[n];
        }

        int num = 1;

        int rows = n, cols = n;

        int row = 0, col = 0;
        int direction = 1;

        while (rows > 0 && cols > 0) {

            // Horizontal move
            for (int i = 0; i < cols; i++) {
                
                result[row][col] = num++;
                
                if (i < cols - 1) 
                    col += direction;
            }

            rows--;
            row += direction;

            // Vertical move
            for (int i = 0; i < rows; i++) {
            
                result[row][col] = num++;
            
                if (i < rows - 1) row += direction;
            }

            cols--;
            col -= direction;

            // Flip direction
            direction *= -1;
        }

        return result;
    }
}
