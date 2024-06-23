public class Solution {
    public int[] NextGreaterElements(int[] nums) {
            
        int[] arr = new int[nums.Length];
        
        for (int i =0; i < nums.Length; i++){
            arr[i] = -1;
        }
        
        for (int i =0; i < nums.Length; i++){
            
            for (int j = 1; j < nums.Length; j++){
                if(nums [(i + j) % nums.Length] > nums [i] ){
                    arr[i] = nums [(i + j) % nums.Length];
                    break;
                }    
            }             
        }
        
        return arr;        
    }
}