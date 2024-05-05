public class Solution {
    public string RemoveDuplicates(string s, int k) {
        Stack<(char, int)> stack = new Stack<(char, int)>();
        
        foreach (char c in s) {
            if (stack.Count > 0 && stack.Peek().Item1 == c) {
                (char ch, int count) = stack.Pop();
                if (count + 1 < k) {
                    stack.Push((ch, count + 1));
                }
            } else {
                stack.Push((c, 1));
            }
        }
        
        StringBuilder sb = new StringBuilder();
        while (stack.Count > 0) {
            (char c, int count) = stack.Pop();
            sb.Insert(0, new string(c, count));
        }
        
        return sb.ToString();
    }
}
