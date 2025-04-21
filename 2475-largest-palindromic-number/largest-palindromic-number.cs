public class Solution {
    public string LargestPalindromic(string num) {
        // Count the frequency of each digit
        int[] counts = new int[10];
        foreach (char c in num) {
            counts[c - '0']++;
        }
        
        // Build the first half of the palindrome (from highest to lowest digit)
        StringBuilder firstHalf = new StringBuilder();
        for (int i = 9; i >= 0; i--) {
            // Skip leading zeros for the first half
            if (firstHalf.Length == 0 && i == 0) {
                continue;
            }
            
            // Add as many pairs as possible
            int pairs = counts[i] / 2;
            for (int j = 0; j < pairs; j++) {
                firstHalf.Append(i);
            }
            
            // Update the remaining count
            counts[i] -= pairs * 2;
        }
        
        // Find the largest digit for the middle (if any)
        char middle = ' ';
        for (int i = 9; i >= 0; i--) {
            if (counts[i] > 0) {
                middle = (char)(i + '0');
                break;
            }
        }
        
        // Build the second half of the palindrome (mirror of the first half)
        StringBuilder result = new StringBuilder(firstHalf.ToString());
        
        // Add the middle digit if applicable
        if (middle != ' ') {
            result.Append(middle);
        }
        
        // Add the reverse of the first half
        for (int i = firstHalf.Length - 1; i >= 0; i--) {
            result.Append(firstHalf[i]);
        }
        
        // Handle the case where the result would be just "0"
        if (result.Length == 0) {
            return "0";
        }
        
        return result.ToString();
    }
}