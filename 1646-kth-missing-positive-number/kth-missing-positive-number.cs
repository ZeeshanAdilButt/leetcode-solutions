public class Solution {
    public int FindKthPositive(int[] arr, int k) {

        int left = 0, right = arr.Length - 1;
        
        while (left <= right) {

            int mid = left + (right - left) / 2;

            //need a way to check on how many positive integers are missing before the given array element to use binary search.
            int missingCount = arr[mid] - (mid + 1);
            
            if (missingCount < k) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        
        return left + k;
    }
}
