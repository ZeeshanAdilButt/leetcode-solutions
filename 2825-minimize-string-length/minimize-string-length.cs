public class Solution {
    public int MinimizedStringLength(string s) {
        HashSet<char> uniqueChars = new HashSet<char>(s);
        return uniqueChars.Count;
    }
}
