

public class Solution {
    public bool Makesquare(int[] nums) {
        
        if (nums == null || nums.Length < 4) return false;
        
        int sum = 0;
        foreach (int num in nums) sum += num;
        if (sum % 4 != 0) return false;
        
        Array.Sort(nums);
        Array.Reverse(nums);
        
        return Dfs(nums, new int[4], 0, sum / 4);
    }
    
    private bool Dfs(int[] nums, int[] sums, int index, int target) {
        if (index == nums.Length) {
            return sums[0] == target && sums[1] == target && sums[2] == target;
        }
        
        for (int i = 0; i < 4; i++) {
            if (sums[i] + nums[index] > target) continue;
            sums[i] += nums[index];
            if (Dfs(nums, sums, index + 1, target)) return true;
            sums[i] -= nums[index];
        }
        
        return false;
    }
}
