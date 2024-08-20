public class Solution {
    public int[] SortedSquares(int[] nums) {
        // Declare a new array to store the squared values.
        int[] newarr = new int[nums.Length];

        int i = 0;
        int j = nums.Length - 1;
        int writeindex = nums.Length - 1;

        while (i <= j) {
            if (Math.Abs(nums[i]) > Math.Abs(nums[j])) {
                newarr[writeindex--] = nums[i] * nums[i];
                i++;
            } else {
                newarr[writeindex--] = nums[j] * nums[j];
                j--;
            }
        }
        return newarr;
    }
}
