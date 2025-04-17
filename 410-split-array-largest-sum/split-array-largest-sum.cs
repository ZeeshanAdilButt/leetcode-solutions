public class Solution {
   
  public int SplitArray(int[] nums, int k) {
    int left = int.MinValue, right = 0;
    
    foreach (int num in nums)
    {
      left = Math.Max(left, num);
      right += num;
    }

    while (left < right) {
      int mid = (left + right) / 2;

      if (CanSplit(nums, k, mid))
      {
        right = mid;
      }
      else
      {
        left = mid + 1;
      }
    }

    return left;
  }

   public bool CanSplit(int[] nums, int k, int mid) {
    int subarrays = 1;
    int currentSum = 0;

    foreach (int num in nums)
    {
      if (currentSum + num > mid) {
        subarrays += 1;
        currentSum = num;

        if (subarrays > k) {
          return false;
        }
      } else {
        currentSum += num;
      }
    }
    
    return true;
  }
  
}
