public class Solution {
    public string DecodeString(string s) {
        Stack<int> countStack = new Stack<int>();
        Stack<string> strStack = new Stack<string>();
        string currString = "";
        int k = 0;

        foreach (char c in s) {
            if (char.IsDigit(c)) {
                k = k * 10 + (c - '0');
            } 
            else if (c == '[') {
                countStack.Push(k);
                strStack.Push(currString);
                k = 0;
                currString = "";
            } 
            else if (char.IsLetter(c)) {
                currString += c;
            } 
            else if (c == ']') {
                int repeat = countStack.Pop();
                string prev = strStack.Pop();
                currString = prev + string.Concat(Enumerable.Repeat(currString, repeat));
            }
        }

        return currString;
    }
}
