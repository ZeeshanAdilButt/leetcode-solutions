public class Solution {


      // Maps the index of the element in 2-D matrix to an index of the 1-D array (reps)
    public static int FindIndex(int currentRow, int currentCol, int cols)
    {
        return currentRow * cols + (currentCol + 1);
    }

    // Checks whether the water cells to be connected are within the bounds of the matrix as per given dimensions
    public static bool WithinBounds(int row, int col, int rows, int cols)
    {
        return col >= 0 && col < cols && row >= 0 && row < rows;
    }


    public int LatestDayToCross(int rows, int cols, int[][] waterCells) {
        int day = 0;
        
        int[][] matrix = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[cols];
        }

        int leftNode = 0;
        int rightNode = rows * cols + 1;

        int[][] waterDirections = {
            new int[] { 1, 0 }, new int[] { 0, 1 },
            new int[] { -1, 0 }, new int[] { 0, -1 },
            new int[] { 1, 1 }, new int[] { 1, -1 },
            new int[] { -1, 1 }, new int[] { -1, -1 }
        };


        int[][] convertedWaterCells = new int[waterCells.Length][];

        for (int i = 0; i < waterCells.Length; i++)
        {
            convertedWaterCells[i] = new int[] { waterCells[i][0] - 1, waterCells[i][1] - 1 };
        }

        UnionFind uf = new UnionFind(rows * cols + 2);

        for (int i = 0; i < convertedWaterCells.Length; i++)
        {
            int row = convertedWaterCells[i][0];
            int col = convertedWaterCells[i][1];

            matrix[row][col] = 1;

            foreach (int[] direction in waterDirections)
            {
                int newRow = row + direction[0];
                int newCol = col + direction[1];

                if (WithinBounds(newRow, newCol, rows, cols) && matrix[newRow][newCol] == 1)
                {
                    uf.Union(FindIndex(row, col, cols), FindIndex(newRow, newCol, cols));
                }
            }

            if (col == 0)
            {
                uf.Union(FindIndex(row, col, cols), leftNode);
            }
            if (col == cols - 1)
            {
                uf.Union(FindIndex(row, col, cols), rightNode);
            }
            if (uf.Find(leftNode) == uf.Find(rightNode))
            {
                break;
            }

            day++;
        }

        return day;
    }
}


public class UnionFind
{
    private int[] reps;

    public UnionFind(int n)
    {
        reps = new int[n];

        for (int i = 0; i < n; i++)
        {
            reps[i] = i;
        }
    }

    public int Find(int x)
    {
        if (reps[x] != x)
        {
            reps[x] = Find(reps[x]);
        }
        return reps[x];
    }

    public void Union(int v1, int v2)
    {
        reps[Find(v1)] = Find(v2);
    }
}