public class Solution {

    public IList<int> SpiralOrder(int[][] matrix)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        int row = 0;
        int col = 0;
        int direction = 1;

        List<int> result = new List<int>();

        while (rows > 0 && cols > 0)
        {
            // Move horizontally (left → right OR right → left)
            for (int i = 0; i < cols; i++)
            {
                result.Add(matrix[row][col]);
                col += direction;
            }

            col -= direction; // Step back to valid col
            row += direction; // Step into next row
            rows--;

            // Move vertically (top → bottom OR bottom → top)
            for (int i = 0; i < rows; i++)
            {
                result.Add(matrix[row][col]);
                row += direction;
            }

            row -= direction; // Step back to valid row
            col -= direction; // Step into next col
            
            cols--;

            direction *= -1; // Reverse direction
        }


        return result;
    }
}