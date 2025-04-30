public class Solution {

    // public int FirstMissingPositive(int[] nums)
    // {
    //     int i = 0;

    //     while (i < nums.Length)
    //     {
    //         int correctSpot = nums[i] - 1;
    //         if (correctSpot >= 0 && correctSpot < nums.Length && nums[i] != nums[correctSpot])
    //         {
    //             int temp = nums[i];
    //             nums[i] = nums[correctSpot];
    //             nums[correctSpot] = temp;
    //         }
    //         else
    //         {
    //             i++;
    //         }
    //     }

    //     for (int j = 0; j < nums.Length; j++)
    //     {
    //         if (j + 1 != nums[j])
    //         {
    //             return j + 1;
    //         }
    //     }

    //     return nums.Length + 1;
    // }

    public int FirstMissingPositive(int[] nums) {
         int n = nums.Length;
        
        // Step 1: Replace(remove) negative numbers and zeros with n+1
        for (int i = 0; i < n; i++) {
            if (nums[i] <= 0)
                nums[i] = n + 1;
        }
        
        // Step 2: Mark elements as visited by negating the value at corresponding index
        for (int i = 0; i < n; i++) {
            
            int num = Math.Abs(nums[i]);

            if (num <= n && nums[num - 1] > 0)
                nums[num - 1] = -nums[num - 1];
        }
        
        // Step 3: Find the first positive number's index, as all the seen elements at index will be negative
        for (int i = 0; i < n; i++) {
            if (nums[i] > 0)
                return i + 1;
        }
        
        // Step 4: If all numbers are present from 1 to n, return n+1
        return n + 1;
    }
}
