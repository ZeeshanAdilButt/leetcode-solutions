public class Solution {
    public int MinimumPushes(string word) {
        int[] frequencies = new int[26];

        foreach (char c in word)
        {
            frequencies[c - 'a']++;
        }

        Array.Sort(frequencies, (x, y) => y.CompareTo(x));
        
        int pushes = 0;

        for (int i = 0; i < 26; i++)
        {
            if (frequencies[i] == 0)
                break;
            pushes += (i / 8 + 1) * frequencies[i];
        }

        return pushes;
    }
}