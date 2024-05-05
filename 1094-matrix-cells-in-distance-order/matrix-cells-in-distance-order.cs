public class Solution {
    public int[][] AllCellsDistOrder(int R, int C, int r0, int c0) {
        List<int[]> result = new List<int[]>();
        
        
        int maxDistance = Math.Max(r0, R - 1 - r0) + Math.Max(c0, C - 1 - c0);
        
        
        for (int distance = 0; distance <= maxDistance; distance++) {
            for (int i = 0; i <= distance; i++) {
                int j = distance - i;
                if (IsValidCell(r0 + i, c0 + j, R, C))
                    result.Add(new int[] { r0 + i, c0 + j });
                if (IsValidCell(r0 + i, c0 - j, R, C) && j != 0)
                    result.Add(new int[] { r0 + i, c0 - j });
                if (IsValidCell(r0 - i, c0 + j, R, C) && i != 0)
                    result.Add(new int[] { r0 - i, c0 + j });
                if (IsValidCell(r0 - i, c0 - j, R, C) && i != 0 && j != 0)
                    result.Add(new int[] { r0 - i, c0 - j });
            }
        }
        
        
        return result.ToArray();
    }
    
    
    private bool IsValidCell(int r, int c, int R, int C) {
        return r >= 0 && r < R && c >= 0 && c < C;
    }
}
