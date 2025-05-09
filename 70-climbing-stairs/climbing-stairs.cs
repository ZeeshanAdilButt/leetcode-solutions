public class Solution {

  public int ClimbStairs(int n) {
    
    int[] memo = new int[n+1];
    
    return CountWays(n, memo);

  }

    private int CountWays(int n, int[] memo) {

        if (n == 1) {
            return 1;
        }
        if (n == 2) {
            return 2;
        }

        if (memo[n] != 0) {
            return memo[n];
        }

        memo[n] = CountWays(n-1, memo) + CountWays(n-2, memo);

        return   memo[n];
    }

}