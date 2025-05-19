
public class Solution {
    private static readonly int[][] directions = new int[][] {
        new int[] {1, 0},   // down
        new int[] {-1, 0},  // up
        new int[] {0, 1},   // right
        new int[] {0, -1}   // left
    };

    public int NumIslands(char[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int islandCount = 0;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == '1') {
                    Bfs(grid, r, c); // sink this island
                    islandCount++;
                }
            }
        }

        return islandCount;
    }

    private void Bfs(char[][] grid, int startRow, int startCol) {
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { startRow, startCol });
        grid[startRow][startCol] = '0'; // mark as visited

        while (queue.Count > 0) {
            var cell = queue.Dequeue();
            int r = cell[0], c = cell[1];

            foreach (var dir in directions) {
                int nr = r + dir[0];
                int nc = c + dir[1];

                if (nr >= 0 && nr < grid.Length &&
                    nc >= 0 && nc < grid[0].Length &&
                    grid[nr][nc] == '1') {

                    queue.Enqueue(new int[] { nr, nc });

                    grid[nr][nc] = '0';
                }
            }
        }
    }
}

// public class Solution {
//     public int NumIslands(char[][] grid) {
//         int rows = grid.Length;
//         if (rows == 0) return 0;

//         int cols = grid[0].Length;
//         int count = 0;

//         for (int i = 0; i < rows; i++) {

//             for (int j = 0; j < cols; j++) {

//                 if (grid[i][j] == '1') {
//                     DFS(grid, i, j);
//                     count++;
//                 }
//             }
//         }
//         return count;
//     }

//      private void DFS(char[][] grid, int i, int j) {

//         if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0') return;
        
//         grid[i][j] = '0';

//         DFS(grid, i + 1, j);
//         DFS(grid, i - 1, j);
//         DFS(grid, i, j + 1);
//         DFS(grid, i, j - 1);
//     }
// }