public class Solution {
    public int MaxSubArray(int[] nums) {
        
        
        int maxSum = nums[0];
        int currentMax = nums[0];
        
        
        for (int i =1; i < nums.Length; i++){
            
            currentMax= Math.Max(nums[i], currentMax+nums[i]);
            
            if(currentMax>maxSum)
                maxSum = currentMax;
        }
        
        return maxSum;
        
    }
}