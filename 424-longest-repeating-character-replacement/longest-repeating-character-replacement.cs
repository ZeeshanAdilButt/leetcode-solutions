public class Solution {
   public int CharacterReplacement(string s, int k) {

    int maxLength = 0;
    int start = 0;
    
    int[] count = new int[26];
    
    int maxCount = 0;
    
    for (int end = 0; end < s.Length; end++) {

        maxCount = Math.Max(maxCount, ++count[s[end] - 'A']);

        while (end - start + 1 - maxCount > k) {

            count[s[start++] - 'A']--;
        }
        
        maxLength = Math.Max(maxLength, end - start + 1);
    }
    return maxLength;
}

}