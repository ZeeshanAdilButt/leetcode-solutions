

public class Solution {
    
    
    public bool Makesquare(int[] nums) {
        if (nums.Length < 4) return false;
        
        int sum = nums.Sum();
        
        
        if (sum % 4 != 0) return false;
        
        Array.Sort(nums, (l, r) => r.CompareTo(l)); // Sort in descending order
        
        int[] sidesLength = new int[4];
        return Dfs(sidesLength, nums, 0, sum / 4);
    }
    
    private bool Dfs(int[] sidesLength, int[] matches, int index, int target) {
        if (index == matches.Length)
            return sidesLength[0] == sidesLength[1] && sidesLength[1] == sidesLength[2] && sidesLength[2] == sidesLength[3];
        
        for (int i = 0; i < 4; ++i) {
            if (sidesLength[i] + matches[index] > target) // First condition
                continue;
            
            int j = i;
            while (--j >= 0) // Third condition
                if (sidesLength[i] == sidesLength[j])
                    break;
            
            if (j != -1) continue;
            
            sidesLength[i] += matches[index];
            if (Dfs(sidesLength, matches, index + 1, target))
                return true;
            
            sidesLength[i] -= matches[index];
        }
        
        return false;
    }

}
