public class Solution {
    public int DominantIndex(int[] nums) {
        if (nums.Length == 0) return -1;

        int highest = -1;
        int secondHighest = -1;
        int highestIndex = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] >= highest) {
                secondHighest = highest;
                highest = nums[i];
                highestIndex = i;
            } else if (nums[i] > secondHighest) {
                secondHighest = nums[i];
            }
        }

        if (highest < secondHighest * 2) {
            highestIndex = -1;
        }
        
        return highestIndex;
    }
}
