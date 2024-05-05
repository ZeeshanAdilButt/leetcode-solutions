public class Solution {
   public string RemoveStars(string s) {
    
    int j = 0;
    char[] charArray = s.ToCharArray();
       
    for (int i = 0; i < s.Length; ++i) {
        
        if (s[i] == '*') {
            j--;
        } 
        else {
            charArray[j++] = s[i];
        }
    }
       
    return new string(charArray, 0, j);
}

}