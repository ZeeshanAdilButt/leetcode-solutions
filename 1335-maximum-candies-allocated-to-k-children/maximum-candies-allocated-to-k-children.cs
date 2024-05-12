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

}