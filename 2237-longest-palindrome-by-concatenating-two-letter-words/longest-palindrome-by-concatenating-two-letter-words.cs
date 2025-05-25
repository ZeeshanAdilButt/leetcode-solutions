public class Solution {
    public int LongestPalindrome(string[] words)
    {
        Dictionary<string, int> frequencies = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (frequencies.ContainsKey(word))
            {
                frequencies[word]++;
            }
            else
            {
                frequencies[word] = 1;
            }
        }

        int count = 0;
        bool central = false;

        foreach (var entry in frequencies)
        {
            string word = entry.Key;
            int frequency = entry.Value;


            if (word[0] == word[1])
            {
    
                if (frequency % 2 == 0)
                {
                    count += frequency;
                }
    
                else
                {
                    count += frequency - 1;
                    central = true;
                }
            }

            else if (word[1] > word[0] && frequencies.ContainsKey(word[1] + "" + word[0]))
            {
    
                count += 2 * Math.Min(frequency, frequencies[word[1] + "" + word[0]]);
            }
        }

        if (central)
        {
            count += 1;
        }

        return 2 * count;
    }


}