public class Solution {
    public IList<int>  FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        if (s.Length < p.Length) return result;

        // Frequency maps
        int[] pCount = new int[26];
        int[] windowCount = new int[26];

        foreach (char c in p)
            pCount[c - 'a']++;

        // Initialize window
        for (int i = 0; i < p.Length; i++)
            windowCount[s[i] - 'a']++;

        // Compare first window
        if (AreEqual(pCount, windowCount))
            result.Add(0);

        // Slide the window
        for (int i = p.Length; i < s.Length; i++)
        {
            // Add new char to window
            windowCount[s[i] - 'a']++;

            // Remove old char from window
            windowCount[s[i - p.Length] - 'a']--;

            // Compare
            if (AreEqual(pCount, windowCount))
                result.Add(i - p.Length + 1);
        }

        return result;
    }

    
    private static bool AreEqual(int[] a, int[] b)
    {
        for (int i = 0; i < 26; i++)
            if (a[i] != b[i]) return false;
        return true;
    }
}