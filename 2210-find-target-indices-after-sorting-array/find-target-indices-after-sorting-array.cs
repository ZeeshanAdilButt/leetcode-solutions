public class Solution {
    public IList<int> TargetIndices(int[] nums, int target) {

        Array.Sort(nums);


        List<int> result = new  List<int>();

        int left = 0; int right = nums.Length;

        while (left < right)
        {
            int mid = left + (right - left) /2;

            if (nums[mid] < target)
                left = mid +1;
            else{
                right = mid;
            }

        }

        for (int i = left; i < nums.Length; i++){

            if(nums[i] == target)
                result.Add(i);
        }

        return result;
        
    }
}