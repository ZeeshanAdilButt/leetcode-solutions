public class Solution {
   public char FindTheDifference(string s, string t) {
    
        int result = 0;
        
        foreach (char c in s) {
            result ^= c;
        }
        
        foreach (char c in t) {
            result ^= c;
        }
        
        return (char)result;

    // int[] freq = new int[26];

    // foreach (char c in s) {
    //     freq[c - 'a']++;
    // }

    // foreach (char c in t) {
    //     freq[c - 'a']--;
    // }

    // for (int i = 0; i < freq.Length; i++) {
    //     if (freq[i] != 0) {
    //         return (char)(i + 'a');
    //     }
    // }

    // return ' ';
}

}