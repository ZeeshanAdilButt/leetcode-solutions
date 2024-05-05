public class Solution {
    
    public string AddSpaces(string s, int[] spaces) {
        
    StringBuilder res = new StringBuilder();
        
    for (int i = 0, j = 0; i < s.Length; ++i) {
        if (j < spaces.Length && i == spaces[j]) {
            res.Append(" ");
            ++j;
        }
        res.Append(s[i]);
    }
        
    return res.ToString();  
    }
}