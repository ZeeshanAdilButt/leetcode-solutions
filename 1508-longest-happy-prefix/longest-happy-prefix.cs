public class Solution {
    public string LongestPrefix(string s) {
        int n = s.Length;
        int[] lps = new int[n];

        int len = 0; // length of the previous longest prefix suffix

        // Build the LPS array
        for (int i = 1; i < n; i++) {

            while (len > 0 && s[i] != s[len]) {
                len = lps[len - 1]; // fallback to previous LPS length
            }

            if (s[i] == s[len]) {
                
                len++;
                lps[i] = len;
            } 
            else {
                lps[i] = 0;
            }
        }

        // The last value in LPS tells us the length of the longest prefix which is also a suffix
        return s.Substring(0, lps[n - 1]);
    }
}
