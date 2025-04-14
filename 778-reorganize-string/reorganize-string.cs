public class Solution {
    
 public string ReorganizeString(string s)
    {
        int[] freq = new int[26];

        // Count character frequencies
        foreach (char c in s)
        {
            freq[c - 'a']++;
        }

        // Max-heap using negative frequencies as priority
        var maxHeap = new PriorityQueue<(int freq, char ch), int>();

        for (int i = 0; i < 26; i++)
        {
            if (freq[i] > 0)
            {
                char ch = (char)(i + 'a');
                maxHeap.Enqueue((freq[i], ch), -freq[i]); // negative freq = max-heap
            }
        }

        StringBuilder res = new StringBuilder();
        (int freq, char ch)? prev = null;

        while (maxHeap.Count > 0 || prev != null)
        {
            if (prev != null && maxHeap.Count == 0)
            {
                return ""; // impossible to rearrange
            }

            var (currFreq, currChar) = maxHeap.Dequeue();
            res.Append(currChar);
            currFreq--;

            if (prev != null)
            {
                maxHeap.Enqueue(prev.Value, -prev.Value.freq);
                prev = null;
            }

            if (currFreq > 0)
            {
                prev = (currFreq, currChar);
            }
        }

        return res.ToString();
    }
}