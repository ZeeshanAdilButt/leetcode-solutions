

using System;

public class Solution {
    private int[] memo;

    public int LengthOfLIS(int[] nums) {
        int n = nums.Length;
        memo = new int[n];
        Array.Fill(memo, -1);

        int maxLIS = 1;
        for (int i = 0; i < n; i++) {
            maxLIS = Math.Max(maxLIS, Dfs(nums, i));
        }
        return maxLIS;
    }

    private int Dfs(int[] nums, int i) {
        // If already calculated, return the memoized result
        if (memo[i] != -1) {
            return memo[i];
        }

        int LIS = 1;  // Each element is at least a subsequence of length 1
        for (int j = i + 1; j < nums.Length; j++) {
            if (nums[i] < nums[j]) {
                LIS = Math.Max(LIS, 1 + Dfs(nums, j));  // Recurse and find the maximum LIS
            }
        }

        memo[i] = LIS;  // Memoize the result for the current index
        return LIS;
    }
}


// public class Solution {
//     public int LengthOfLIS(int[] nums) {
//         List<int> sub = new List<int>();
//         sub.Add(nums[0]);
        
//         for (int i = 1; i < nums.Length; i++) {

//             int num = nums[i];

//             if (num > sub[sub.Count - 1]) {
//                 sub.Add(num);
//             }
//              else {
//                 int j = BinarySearch(sub, num);
//                 sub[j] = num;
//             }
//         }
        
//         return sub.Count;
//     }
    
//     private int BinarySearch(List<int> sub, int num) {
//         int left = 0;
//         int right = sub.Count - 1;
//         int mid = (left + right) / 2;
        
//         while (left < right) {
//             mid = (left + right) / 2;
//             if (sub[mid] == num) {
//                 return mid;
//             }
            
//             if (sub[mid] < num) {
//                 left = mid + 1;
//             } else {
//                 right = mid;
//             }
//         }
        
//         return left;
//     }
// }
