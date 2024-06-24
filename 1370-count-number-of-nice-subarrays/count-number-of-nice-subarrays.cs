public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        int j = 0, odd = 0, count = 0, total = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            
            if (nums[i] % 2 == 1) {
                odd++;
                if (odd >= k) {
                    
                    count = 1;
                    
                    while (nums[j++] % 2 == 0) 
                        count++;
                    
                    total += count;
                }
            } 
            else if (odd >= k) {
                total += count;
            }
        }
        return total;
    }
}
