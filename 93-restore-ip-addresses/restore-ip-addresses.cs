public class Solution {
    public IList<string> RestoreIpAddresses(string s) {
        List<string> res = new List<string>();
        if (s.Length > 12) return res;

        backtrack(0, 0, "", s, res);
        return res;
    }

    private void backtrack(int i, int dots, string curIP, string s, List<string> res) {
        if (dots == 4 && i == s.Length) {
            res.Add(curIP.Substring(0, curIP.Length - 1));
            return;
        }
        if (dots > 4) return;

        for (int j = i; j < Math.Min(i + 3, s.Length); j++) {
            if (i != j && s[i] == '0') continue;
            string segment = s.Substring(i, j - i + 1);
            if (int.Parse(segment) <= 255) {
                backtrack(j + 1, dots + 1, curIP + segment + ".", s, res);
            }
        }
    }
}