public class Solution {
    public int MinMovesToMakePalindrome(string s) {
      
        List<char> chars = new List<char>(s);
        int res = 0;
        
        while (chars.Count > 0) {

            // Find first index of the last character
            int i = chars.IndexOf(chars[chars.Count - 1]);
            
            // If first index is already the last index of character, that means there is only one such char.
            if (i == chars.Count - 1) {
                // If only one character left, we're done
                // Otherwise, the character must be in the middle of the palindrome
                // Move it appropriately by half the length of the remaining string
                res += chars.Count / 2;
            } 
            //else just add the index to total 
            else {
                // Add the cost of removing the matching character from position i
                res += i;
                // Remove the character at position i
                chars.RemoveAt(i);
            }
            
            // Remove the last character
            chars.RemoveAt(chars.Count - 1);
        }
        return res;
    }
}