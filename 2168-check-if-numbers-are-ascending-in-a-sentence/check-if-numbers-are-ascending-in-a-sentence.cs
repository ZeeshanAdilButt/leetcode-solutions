public class Solution {
    public bool AreNumbersAscending(string s) {
        int prev = 0, cur = 0;
        foreach (char ch in s)
        {
            if (Char.IsDigit(ch))
                cur = cur * 10 + (ch - '0');
            else if (cur != 0)
            {
                if (prev >= cur)
                    return false;
                prev = cur;
                cur = 0;
            }
        }
        return cur == 0 || prev < cur;
    }
}