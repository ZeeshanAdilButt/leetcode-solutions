

public class Solution {
    public int LengthOfLIS(int[] nums) {
        List<int> sub = new List<int>();
        sub.Add(nums[0]);
        
        for (int i = 1; i < nums.Length; i++) {
            int num = nums[i];
            if (num > sub[sub.Count - 1]) {
                sub.Add(num);
            } else {
                int j = BinarySearch(sub, num);
                sub[j] = num;
            }
        }
        
        return sub.Count;
    }
    
    private int BinarySearch(List<int> sub, int num) {
        int left = 0;
        int right = sub.Count - 1;
        int mid = (left + right) / 2;
        
        while (left < right) {
            mid = (left + right) / 2;
            if (sub[mid] == num) {
                return mid;
            }
            
            if (sub[mid] < num) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        
        return left;
    }
}
