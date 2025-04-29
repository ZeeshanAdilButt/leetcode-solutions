public class Solution
{
    public int CountSubstrings(string s)
    {
        int n = s.Length;
        // t[i][j] = true means s[i..j] (inclusive) is a palindrome
        bool[,] t = new bool[n, n];

        int count = 0;

        // L = length of the substring
        for (int L = 1; L <= n; L++)
        {
            for (int i = 0; i + L <= n; i++)
            {
                int j = i + L - 1; // Ending index of the substring

                if (i == j)
                {
                    // Single characters are always palindromic
                    t[i, j] = true;
                }
                else if (i + 1 == j)
                {
                    // Two-character substrings are palindromic if both characters are same
                    t[i, j] = (s[i] == s[j]);
                }
                else
                {
                    // For longer substrings:
                    // First and last characters must match
                    // and the inner substring must also be a palindrome
                    t[i, j] = (s[i] == s[j]) && t[i + 1, j - 1];
                }

                // If s[i..j] is a palindrome, increment the count
                if (t[i, j])
                {
                    count++;
                }
            }
        }

        return count;
    }
}
