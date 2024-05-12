public class Solution {
    
public int MaximumCandies(int[] candies, long k) {
        if (candies.Sum(x => (long)x) < k)
            return 0;
        int left = 1;
        int right = candies.Max();
        while (left < right) {
            int mid = (left+right)/2 + 1;
            if (candies.Sum(c => (long)c/mid) >= k) // try to get k piles with mid candies
                left = mid;
            else
                right = mid-1;
        }
        return left;
    }
    
// public int MaximumCandies(int[] candies, long numChildren) {
//     // Define the search space
//     int left = 1; // Minimum candies allocated to each child
//     int total = candies.Sum(); // Maximum candies allocated to each child
//     int right  = total; 
    
//     // Binary search to find the maximum candies
//     while (left < right) {
//         int mid = left + (right - left) / 2;
        
//         // Check if it's possible to allocate candies to K children
//         if (CanAllocateCandies(total, mid, numChildren)) {
//             right = mid; // Search in the lower half
//         } else {
//             left = mid + 1; // Search in the upper half
//         }
//     }
    
//     // The maximum candies found is 'left' as 'left' will be the smallest value that satisfies the condition
//     return left;
// }

// // Helper function to check if it's possible to allocate candies to K children
// private bool CanAllocateCandies(int totalcandies, int candiestoAllocate, long numChildren) {
    
//     if((totalcandies/candiestoAllocate) >= numChildren)
//         return true;
    
    
//     return false;
// }


}