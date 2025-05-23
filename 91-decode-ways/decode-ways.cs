public class Solution {
    public int NumDecodings(string s) {
        // Initialize the dynamic programming array
        // dp[i] represents the number of ways to decode the substring ending at index i
        int n = s.Length;
        int[] dp = new int[n+1];
        
        // Base case: there is one way to decode an empty string
        dp[n] = 1;
        
        // Base case: check if the last digit is '0'
        // If it is '0', there is no way to decode it
        // If it is not '0', there is one way to decode it
        dp[n-1] = s[n-1] == '0' ? 0 : 1;
        
        // Iterate from n-2 to 0
        for (int i = n - 2; i >= 0; i--) {
            // If the current digit is '0', there is no way to decode it
            if (s[i] == '0') {
                dp[i] = 0;
            } else {
                // get 2 characteres starting at index i
                int num = int.Parse(s.Substring(i, 2));
                
                // If the number is less than or equal to 26,
                // add the number of ways to decode the substring ending at index i+1 and i+2
                if(num <= 26) {
                    dp[i] = dp[i + 1] + dp[i + 2];
                } else {
                    // If the number is greater than 26, 
                    // add the number of ways to decode the substring ending at index i+1
                    dp[i] = dp[i + 1];
                }
            }
        }
        // Return the number of ways to decode the entire string
        return dp[0];
    }
}