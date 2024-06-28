public class Solution {
    public int SingleNumber(int[] nums) {
        
        int num =0;
        
        for (int i=0; i < nums.Length; i++){
            
            num ^= nums[i];
        }
        
        return num;
        
    }
}