public class Solution {
    public void SortColors(int[] nums) {
        int left = 0;        // pointer for 0s (red)
        int right = nums.Length - 1;  // pointer for 2s (blue)
        int current = 0; 
        
        while (current <= right) {
            if (nums[current] == 0) {
               
                Swap(nums, left, current);
                left++;
                current++;
            }
            else if (nums[current] == 2) {
            
                Swap(nums, current, right);
                right--;
            
            }
            else {
            
                current++;
            }
        }
    }
    
    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}