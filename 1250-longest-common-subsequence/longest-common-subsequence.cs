public class Solution {

     public int LongestCommonSubsequence(string text1, string text2) {
        
        int[,] dp = new int[text1.Length+1,text2.Length+1];
        
        for (int i=0; i <= text1.Length; i++){
            
              for (int j=0; j <= text2.Length; j++){
                  
                  dp[i,j] = 0;
              }
            
        }
        
        for (int i= text1.Length -1; i >= 0; i--){
        
            for (int j= text2.Length -1; j >= 0; j--){

                if(text1[i] == text2[j]){
                  dp[i,j] =  1 + dp[i+1,j+1];
                }
                else{
                    dp[i,j] = Math.Max(dp[i+1,j], dp[i,j+1]);
                }

            }

        }
        
        return dp[0,0];
        
    }

    // public static int LongestCommonSubsequenceHelper(string str1, string str2, int i, int j, int[,] dp)
    // {
    //     if (i == str1.Length || j == str2.Length)
    //     {
    //         return 0;
    //     }
    //     else if (dp[i, j] == -1)
    //     {
    //         if (str1[i] == str2[j])
    //         {
    //             dp[i, j] = 1 + LongestCommonSubsequenceHelper(str1, str2, i + 1, j + 1, dp);
    //         }
    //         else
    //         {
    //             dp[i, j] = Math.Max(LongestCommonSubsequenceHelper(str1, str2, i + 1, j, dp),
    //                                 LongestCommonSubsequenceHelper(str1, str2, i, j + 1, dp));
    //         }
    //     }
    //     return dp[i, j];
    // }

    // public int LongestCommonSubsequence(string str1, string str2)
    // {
    //     int n = str1.Length;
    //     int m = str2.Length;
    //     int[,] dp = new int[n, m];
    //     for (int i = 0; i < n; i++)
    //     {
    //         for (int j = 0; j < m; j++)
    //         {
    //             dp[i, j] = -1;
    //         }
    //     }
    //     return LongestCommonSubsequenceHelper(str1, str2, 0, 0, dp);
    // }

   
}