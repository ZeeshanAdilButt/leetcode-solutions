public class Solution {
   static bool CanPlaceBalls(int x, int[] position, int m)
    {
        int prev = position[0];
        
        int balls = 1;

        for (int i = 1; i < position.Length && balls < m; ++i)
        {
            int curr = position[i];
            
            if (curr - prev >= x)
            {
                balls += 1;
                prev = curr;
            }
        }
        
        return balls == m;
    }

    public int MaxDistance(int[] position, int m)
    {
        Array.Sort(position);
        
        int force = 0;
        
        int low = 1;
        
        int high = (position[position.Length - 1] - position[0]) / (m - 1);
        
        while (low <= high)
        {
            int mid = (low + high) / 2;
            
            if (CanPlaceBalls(mid, position, m))
            {
                force = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        
        return force;
    }
}