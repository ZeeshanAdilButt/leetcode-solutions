public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var freqMap = new Dictionary<string, int>();

        // 1. Build frequency map
        foreach (var word in words) {
            if (!freqMap.ContainsKey(word))
                freqMap[word] = 0;
            freqMap[word]++;
        }

        // 2. Build buckets by frequency
        List<string>[] buckets = new List<string>[words.Length + 1];
        foreach (var pair in freqMap) {
            int freq = pair.Value;
            if (buckets[freq] == null)
                buckets[freq] = new List<string>();
            buckets[freq].Add(pair.Key);
        }

        // 3. Collect result from highest frequency to lowest
        var result = new List<string>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--) {
            if (buckets[i] != null) {
                buckets[i].Sort(); // Lexicographical order
                foreach (var word in buckets[i]) {
                    result.Add(word);
                    if (result.Count == k)
                        return result;
                }
            }
        }

        return result;
    }
}


// public class Solution {
//     public IList<string> TopKFrequent(string[] words, int k) {

//         Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

//         Trie[] buckets = new Trie[words.Length + 1];

//         List<string> topK = new List<string>();

//         foreach (string word in words) {
//             if (!frequencyMap.ContainsKey(word)) {
//                 frequencyMap[word] = 0;
//             }
//             frequencyMap[word]++;
//         }


//         foreach (var entry in frequencyMap) {


//             string word = entry.Key;
//             int frequency = entry.Value;
            
//             if (buckets[frequency] == null) {
//                 buckets[frequency] = new Trie();
//             }
            
//             buckets[frequency].AddWord(word);

//         }

//         for (int i = buckets.Length - 1; i >= 0 && topK.Count < k; i--) {

//             if (buckets[i] != null) {

//                 List<string> retrieveWords = new List<string>();

//                 buckets[i].GetWords(buckets[i].Root, retrieveWords);
                
//                 if (retrieveWords.Count < k - topK.Count) {
//                     topK.AddRange(retrieveWords);
//                 } else {
//                     topK.AddRange(retrieveWords.GetRange(0, k - topK.Count));
//                 }
//             }
//         }

//         return topK;
//     }
// }


// class TrieNode {
//     public TrieNode[] Children;
//     public string Word;

//     public TrieNode() {
//         Children = new TrieNode[26];
//         Word = null;
//     }
// }

// class Trie {
//     public TrieNode Root;

//     public Trie() {
//         Root = new TrieNode();
//     }

//     public void AddWord(string word) {

//         TrieNode cur = Root;

//         foreach (char c in word) {
//             if (cur.Children[c - 'a'] == null) {
//                 cur.Children[c - 'a'] = new TrieNode();
//             }
//             cur = cur.Children[c - 'a'];
//         }
//         cur.Word = word;
//     }

//     public void GetWords(TrieNode node, List<string> ans) {
//         if (node == null) {
//             return;
//         }
//         if (node.Word != null) {
//             ans.Add(node.Word);
//         }
//         for (int i = 0; i < 26; i++) {
//             if (node.Children[i] != null) {
//                 GetWords(node.Children[i], ans);
//             }
//         }
//     }
// }