public class Solution {
    public string RemoveDuplicates(string s) {
        StringBuilder ans = new StringBuilder();
        ans.Append(s[0]);

        for (int i = 1; i < s.Length; i++) {
            if (ans.Length > 0 && s[i] == ans[ans.Length - 1]) {
                ans.Remove(ans.Length - 1, 1);
            } else {
                ans.Append(s[i]);
            }
        }

        return ans.ToString();
    }
}
