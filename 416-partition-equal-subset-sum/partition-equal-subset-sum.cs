public class Solution {
    private bool?[,] memo;

    public bool CanPartition(int[] nums) {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
        }
        if (sum % 2 != 0) {
            return false;
        }

        memo = new bool?[nums.Length + 1, sum / 2 + 1];
        return Dfs(nums, 0, sum / 2);
    }

    public bool Dfs(int[] nums, int i, int target) {
        if (target == 0) {
            return true;
        }
        if (i == nums.Length || target < 0) {
            return false;
        }
        if (memo[i, target] != null) {
            return memo[i, target] == true;
        }

        bool result = Dfs(nums, i + 1, target) || 
                      Dfs(nums, i + 1, target - nums[i]);

        memo[i, target] = result;
        return result;
    }
}