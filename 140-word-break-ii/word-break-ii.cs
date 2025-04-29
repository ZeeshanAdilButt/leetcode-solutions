using System;
using System.Collections.Generic;

public class Solution {
    private HashSet<string> dict;
    private Dictionary<string, List<string>> memo;

    private List<string> Solve(string s) {
        if (string.IsNullOrEmpty(s)) {
            return new List<string> { "" };
        }
        
        if (memo.ContainsKey(s)) {
            return memo[s];
        }

        var result = new List<string>();
        for (int l = 1; l <= s.Length; l++) {
            string currWord = s.Substring(0, l);
            if (dict.Contains(currWord)) {
                string remainWord = s.Substring(l);
                List<string> remainResult = Solve(remainWord);
                foreach (string w in remainResult) {
                    string toAdd = currWord + (string.IsNullOrEmpty(w) ? "" : " ") + w;
                    result.Add(toAdd);
                }
            }
        }

        memo[s] = result;
        return result;
    }

    public IList<string> WordBreak(string s, IList<string> wordDict) {
        dict = new HashSet<string>(wordDict);
        memo = new Dictionary<string, List<string>>();

        return Solve(s);
    }
}