public class Solution {
    public bool IsAnagram(string s, string t) {
        
        if (s.Length != t.Length) {
            return false;
        }
        
        var sCounts = new int[26];
        
        
        for (int i = 0; i < s.Length; i++) {
            sCounts[s[i] - 'a']++;
            sCounts[t[i] - 'a']--;
        }
        
        for (int i = 0; i < 26; i++) {
            if (sCounts[i] != 0) {
                return false;
            }
        }
        
        return true;
    }
}
