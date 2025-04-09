public class Solution {

   public int LengthOfLongestSubstring(string str) {
        if (str.Length == 0) {
            return 0;
        }
        
        int n = str.Length;
        int left = 0;           // Start of the current window
        int maxLength = 0;      // Length of the longest substring found
        Dictionary<char, int> lastSeenAt = new Dictionary<char, int>();
        
        for (int right = 0; right < n; right++) {
            char currentChar = str[right];
            
            // If character was seen before and is within the current window
            if (lastSeenAt.ContainsKey(currentChar) && lastSeenAt[currentChar] >= left) {
                // Calculate current window length before updating
                int currentLength = right - left;
                if (currentLength > maxLength) {
                    maxLength = currentLength;
                }
                
                // Move left pointer to position after the last occurrence
                left = lastSeenAt[currentChar] + 1;
            }
            
            // Update the last position of current character
            lastSeenAt[currentChar] = right;
        }
        
        // Check one more time after the loop ends
        int finalLength = n - left;
        if (finalLength > maxLength) {
            maxLength = finalLength;
        }
        
        return maxLength;
    }

}