// using System;

// public class Solution {
//     public int MaxCount(int[] banned, int n, int maxSum) {
//         Array.Sort(banned);  // Sort for binary search
//         int count = 0;

//         for (int num = 1; num <= n; num++) {
//             if (IsBanned(banned, num)) continue;

//             maxSum -= num;

//             if (maxSum < 0) break;

//             count++;
//         }

//         return count;
//     }

//     private bool IsBanned(int[] arr, int target) {
//         int left = 0, right = arr.Length - 1;

//         while (left <= right) {
//             int mid = left + (right - left) / 2;

//             if (arr[mid] == target) return true;

//             if (arr[mid] > target) {
//                 right = mid - 1;
//             } else {
//                 left = mid + 1;
//             }
//         }

//         return false;
//     }
// }

using System;
using System.Collections.Generic;

public class Solution {
    public int MaxCount(int[] banned, int n, int maxSum) {
        var bannedSet = new HashSet<int>(banned);
        int sum = 0, count = 0;

        for (int i = 1; i <= n; i++) {
            if (bannedSet.Contains(i)) continue;

            if (sum + i > maxSum) break;

            sum += i;
            count++;
        }

        return count;
    }
}
