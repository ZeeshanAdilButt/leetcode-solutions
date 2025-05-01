public class Solution {
    public string AlienOrder(string[] words) {
        // Use HashSet for fast lookup and to avoid duplicate edges
        Dictionary<char, HashSet<char>> adjList = new Dictionary<char, HashSet<char>>();
        Dictionary<char, int> count = new Dictionary<char, int>(); // in-degree count

        // Step 1: Initialize count for all unique characters
        foreach (string word in words) {
            foreach (char c in word) {
                if (!count.ContainsKey(c)) {
                    count[c] = 0;
                }
            }
        }

        // Step 2: Build the graph
        for (int i = 0; i < words.Length - 1; i++) {
            string word1 = words[i];
            string word2 = words[i + 1];

            int minLen = Math.Min(word1.Length, word2.Length);
         
            int j;
            for (j = 0; j < minLen; j++) {
                
                char c = word1[j], d = word2[j];

                if (c != d) {
                    
                    if (!adjList.ContainsKey(c)) adjList[c] = new HashSet<char>();

                    if (!adjList.ContainsKey(d)) adjList[d] = new HashSet<char>();

                    if (!adjList[c].Contains(d)) {
                        adjList[c].Add(d);
                        count[d]++; // Increase in-degree
                    }
                    break;
                }
            }

            // Invalid case: j reached end and word 1 is bigger than word 2 (against lexicographic order)
            if (j == minLen && word1.Length > word2.Length) {
                return "";
            }
        }

        // Step 3: Topological Sort (Kahn's Algorithm)
        Queue<char> queue = new Queue<char>();
        foreach (var pair in count) {
            if (pair.Value == 0) {
                queue.Enqueue(pair.Key);
            }
        }

        List<char> result = new List<char>();
        while (queue.Count > 0) {

            char c = queue.Dequeue();
            result.Add(c);

            if (!adjList.ContainsKey(c)) continue;

            foreach (char neighbor in adjList[c]) {

                count[neighbor]--;

                if (count[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Step 4: If not all nodes are in result, there's a cycle
        if (result.Count < count.Count) {
            return "";
        }

        return new string(result.ToArray());
    }
}
