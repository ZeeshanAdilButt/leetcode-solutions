public class Solution {
    public string MinWindow(string s1, string s2) {
        int n = s1.Length;
        int m = s2.Length;
        
        // If s2 is longer than s1, it cannot be a subsequence
        if (m > n) return "";
        
        // Track the best window found so far
        int minWindowLength = int.MaxValue;
        int minWindowStart = 0;
        
        // Iterate through s1 as potential starting points
        for (int left = 0; left < n; left++) {
            // Skip if the first character doesn't match
            if (s1[left] != s2[0]) continue;
            
            // Try to match s2 from this starting point
            int s1Index = left;
            int s2Index = 0;
            
            // Find the ending point where s2 is fully matched
            while (s1Index < n && s2Index < m) {
                if (s1[s1Index] == s2[s2Index]) {
                    s2Index++;  // Move to next character in s2
                }
                s1Index++;  // Always move to next character in s1
                
                // If we've matched all of s2
                if (s2Index == m) {
                    int windowLength = s1Index - left;
                    
                    // Update minimum window if this is better
                    if (windowLength < minWindowLength) {
                        minWindowLength = windowLength;
                        minWindowStart = left;
                    }
                    break;
                }
            }
        }
        
        // If no valid window was found
        if (minWindowLength == int.MaxValue) {
            return "";
        }
        
        // Return the minimum window substring
        return s1.Substring(minWindowStart, minWindowLength);
    }
}