

public class Solution {

    private Dictionary<int, bool> memo;

    public bool WordBreak(string s, IList<string> wordDict) {
        memo = new Dictionary<int, bool> { { s.Length, true } };
        return Dfs(s, wordDict, 0);
    }

    private bool Dfs(string s, IList<string> wordDict, int i) {
        if (memo.ContainsKey(i)) {
            return memo[i];
        }

        foreach (var w in wordDict) {
            if (i + w.Length <= s.Length && 
                s.Substring(i, w.Length) == w) {
                if (Dfs(s, wordDict, i + w.Length)) {
                    memo[i] = true;
                    return true;
                }
            }
        }
        memo[i] = false;
        return false;
    }


    // public bool WordBreak(string s, IList<string> wordDict) {

    //     bool[] dp = new bool[s.Length+1];

    //     for(int i=0; i<dp.Length; i++){
    //         dp[i]= false;
    //     }
        
    //     dp[s.Length]=true;

    //     for (int i = s.Length -1; i>=0; i--){

    //         foreach(string word in wordDict){
                
    //            string currentRemaining = s.Substring(i);

    //             if(word.Length <= currentRemaining.Length && currentRemaining.StartsWith(word)){
                    
    //                 dp[i]= dp[i + word.Length];
                    
    //             }

    //             //if any match found break for other words
    //             if(dp[i])
    //             break;
    //         }
    //     }

    //     return dp[0];
        
    // }
}
