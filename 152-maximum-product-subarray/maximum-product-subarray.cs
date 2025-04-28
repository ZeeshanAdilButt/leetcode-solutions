public class Solution {
    public int MaxProduct(int[] nums) {
        
        int actualMax = nums.Max();
        
        int currentMax =  nums[0];
        int currentMin =  nums[0];
        
        for(int i=1; i < nums.Length; i++){
            
           if (nums[i] == 0) { 
                currentMax = 1;
                currentMin = 1;
                continue;
            }
                     
            var temp = currentMax * nums[i];
            currentMax = Math.Max(nums[i],Math.Max(nums[i] * currentMax, nums[i] * currentMin ));
            currentMin = Math.Min(temp, Math.Min( nums[i], nums[i] * currentMin ));
            
            actualMax = Math.Max(actualMax,currentMax);
        }
        
        
        return actualMax;
        
    }
}