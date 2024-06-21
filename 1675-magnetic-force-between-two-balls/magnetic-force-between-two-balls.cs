public class Solution {
    public int MaxDistance(int[] positions, int m) {
        
        Array.Sort(positions);
        
        
        int low = 1, high = positions[positions.Length - 1] ;
        
        
        while (low <= high) {
            int mid = (low + high) / 2;
            
            if (CanPlaceBalls(positions, m, mid)) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }
        return high;
    }

    private bool CanPlaceBalls(int[] positions, int m, int minDist) {
        
        int count = 1;
        int lastPos = positions[0];
        
        for (int i = 1; i < positions.Length; i++) {
            if (positions[i] - lastPos >= minDist) {
                count++;
                lastPos = positions[i];
                if (count == m) {
                    return true;
                }
            }
        }
        return false;
    }
}
