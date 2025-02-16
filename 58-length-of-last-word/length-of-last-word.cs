public class Solution {
    public int LengthOfLastWord(string s) {
        // Initialize length counter
        int length = 0;
        
        // Start from end of string
        int i = s.Length - 1;
        
        // Skip trailing spaces
        while (i >= 0 && s[i] == ' ') {
            i--;
        }
        
        // Count characters until we hit a space or beginning of string
        while (i >= 0 && s[i] != ' ') {
            length++;
            i--;
        }
        
        return length;
    }
}