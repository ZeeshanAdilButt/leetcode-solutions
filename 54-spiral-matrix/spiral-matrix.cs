public class Solution {

    
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int row = 0;
        int col = -1;

        int direction = 1;

        List<int> result = new List<int>();

        // Traverse the matrix in a spiral order
        while (rows > 0 && cols > 0)
        {
            for (int i = 0; i < cols; i++)
            {
                col += direction;
                result.Add(matrix[row][col]);
            }
            rows--;

            for (int i = 0; i < rows; i++)
            {
                row += direction;
                result.Add(matrix[row][col]);
            }
            cols--;

            direction *= -1;
        }

        return result;
    }
}