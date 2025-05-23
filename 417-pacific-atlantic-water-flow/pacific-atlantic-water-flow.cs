public class Solution {
   public IList<IList<int>> PacificAtlantic(int[][] heights)
        {

            int rows = heights.Length;
            int cols = heights[0].Length;

            int[,] atlantic = new int[rows, cols];
            int[,] pacific = new int[rows, cols];

            List<IList<int>> result = new List<IList<int>>();

            void DFS(int row, int col, int prevValue, int[,] visited)
            {

                //if already added to pacific or 
                if (row == rows || col == cols || row < 0 || col < 0 || visited[row, col] == 1 || heights[row][col] < prevValue)
                    return;

                
                visited[row, col] = 1;
                
                //bottom
                DFS(row + 1, col, heights[row][col], visited); 
                //top
                DFS(row - 1, col, heights[row][col], visited);
                 //right
                DFS(row, col + 1, heights[row][col], visited);
        
                //left
                DFS(row, col - 1, heights[row][col], visited);          

            }

            
            for (int i = 0; i < cols; i++)
            {
                //pacific ocean
                //let's do dfs on first row and all of its columns, as 1st row will always be in 
                DFS(0, i, heights[0][i], pacific);

                //atlantic ocean
                // as last row and all of it's column will be in atlantic ocean
                DFS(rows-1, i, heights[rows-1][i], atlantic);
            }

             for (int i = 0; i < rows; i++)
            {
                //pacific ocean
                //let's do dfs on first col and all of its rows, as 1st col will always be in 
                DFS(i, 0, heights[i][0], pacific);
                
                //atlantic connection
                //and vice versa
                //let's do dfs on last col and all of its rows, as 1st col will always be in 
                DFS(i, cols-1, heights[i][cols-1],atlantic );
            }

        

            //merge the atlantic and pacific
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (atlantic[i,j] == 1 && pacific[i,j] == 1)
                        result.Add(new List<int> { i, j });
                }
            }

            return result;

        }
}