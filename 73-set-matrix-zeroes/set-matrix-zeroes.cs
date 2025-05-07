public class Solution {

   public void SetZeroes(int[][] matrix) {
    int m = matrix.Length;
    int n = matrix[0].Length;
    bool firstRow = false;
    bool firstCol = false;
    
    // Check if first row contains a zero
    for (int i = 0; i < n; i++) {
        if (matrix[0][i] == 0) {
            firstRow = true;
            break;
        }
    }
    
    // Check if first column contains a zero
    for (int i = 0; i < m; i++) {
        if (matrix[i][0] == 0) {
            firstCol = true;
            break;
        }
    }
    
    // Use first row and first column as flags to store information about zeros in the rest of the matrix
    for (int i = 1; i < m; i++) {

        for (int j = 1; j < n; j++) {
            
            if (matrix[i][j] == 0) {
                matrix[0][j] = 0;
                matrix[i][0] = 0;
            }
        }
    }
    
    // Set zeros in the rest of the matrix based on the flags in the first row and first column
    for (int i = 1; i < m; i++) {
        for (int j = 1; j < n; j++) {
            if (matrix[0][j] == 0 || matrix[i][0] == 0) {
                matrix[i][j] = 0;
            }
        }
    }
    
    // Set zeros in the first row if it contains a zero
    if (firstRow) {
        for (int i = 0; i < n; i++) {
            matrix[0][i] = 0;
        }
    }
    
    // Set zeros in the first column if it contains a zero
    if (firstCol) {
        for (int i = 0; i < m; i++) {
            matrix[i][0] = 0;
        }
    }
}

}