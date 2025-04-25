public class Solution {
    
     public int MaxUniqueSplit(string s) {
        HashSet<string> seen = new HashSet<string>();
        return Backtrack(s, 0, seen);
    }

    private static int Backtrack(string s, int start, HashSet<string> seen) {
        if (start == s.Length) {
            return 0;
        }

        int maxCount = 0;

        for (int end = start + 1; end <= s.Length; end++) {
            string subString = s.Substring(start, end - start);

            if (!seen.Contains(subString)) {
                seen.Add(subString);
                maxCount = Math.Max(maxCount, 1 + Backtrack(s, end, seen));
                seen.Remove(subString);
            }
        }

        return maxCount;
    }
}