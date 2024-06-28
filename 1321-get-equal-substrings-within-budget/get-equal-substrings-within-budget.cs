public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        int n = s.Length;
        int start = 0;
        int currentCost = 0;
        int maxLength = 0;

        for (int end = 0; end < n; ++end) {
            currentCost += Math.Abs(s[end] - t[end]);

            while (currentCost > maxCost) {
                currentCost -= Math.Abs(s[start] - t[start]);
                ++start;
            }

            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}
