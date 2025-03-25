public class Solution {
    public int CountPairs(IList<int> nums, int target) {

           nums = nums.OrderBy(x => x).ToList();

        int total =0;

        int left = 0;
        int right = nums.Count-1;

        while (left < right){

            if((nums[left] + nums[right]) < target){

                total+= (right - left);
                left++;
            }
            else{

                right--;
            }
        }
            
return total;
        
    }
}