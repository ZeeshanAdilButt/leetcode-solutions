public class Solution {
    public string SortSentence(string s) {
    
        string[] str = s.Split(' ');                
        string[] res = new string[str.Length];   
        
        StringBuilder sb = new StringBuilder();     
        
        int i = 0;

        foreach (string word in str)
        {
            i = (int)(word[word.Length - 1] - '0');
            res[i - 1] = word.Substring(0, word.Length - 1);
        }

        for (i = 0; i < res.Length - 1; i++)
            sb.Append(res[i]).Append(" ");
        
        sb.Append(res[i]);
        return sb.ToString();
    }
}