public class Solution {
    public int[] FindErrorNums(int[] nums) {
        int duplicated = 0;
        int missing = 0;
        int[] pair = new int[2];
        
        int i = 0;
        while (i < nums.Length)
        {
            int correct = nums[i] - 1;
            if (nums[i] != nums[correct])
            {
                Swap(nums, i, correct);
            }
            else
            {
                i = i + 1;
            }
        }
        
        for (int j = 0; j < nums.Length; j++)
        {
            if (nums[j] != j + 1)
            {
                duplicated = nums[j];
                missing = j + 1;
            }
        }
        
        pair[0] = duplicated;
        pair[1] = missing;

        return pair;
    }

    // Function for swapping
    public static void Swap(int[] arr, int first, int second)
    {
        int temp = arr[first];
        arr[first] = arr[second];
        arr[second] = temp;
    }
}