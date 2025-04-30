public class Solution {
    public int MissingNumber(int[] nums) {

        int lenNums = nums.Length;
        int index = 0;
        int value = 0;

        //cyclic sort
        while (index < lenNums)
        {
            value = nums[index];

            if (value < lenNums && value != nums[value])
            {
                int temp = nums[index];
                nums[index] = nums[value];
                nums[value] = temp;
            }
            else
            {
                index += 1;
            }
        }

        for (int x = 0; x < lenNums; x++)
        {
            if (x != nums[x])
            {
                return x;
            }
        }
        
        return lenNums;
        
    }
}