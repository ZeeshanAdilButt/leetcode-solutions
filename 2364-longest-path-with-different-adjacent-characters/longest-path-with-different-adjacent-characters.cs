public class Solution {
    private int maxPath = 1;

    public int LongestPath(int[] parent, string s) {
        int n = parent.Length;
        var tree = new List<int>[n];
        for (int i = 0; i < n; i++) tree[i] = new List<int>();

        for (int i = 1; i < n; i++) {
            tree[parent[i]].Add(i);
        }

        Dfs(0, tree, s);
        return maxPath;
    }

    private int Dfs(int node, List<int>[] tree, string s) {
        int longest = 0, secondLongest = 0;

        foreach (int child in tree[node]) {
            int childLen = Dfs(child, tree, s);

            if (s[child] == s[node]) continue;

            if (childLen > longest) {
                secondLongest = longest;
                longest = childLen;
            } else if (childLen > secondLongest) {
                secondLongest = childLen;
            }
        }

        maxPath = Math.Max(maxPath, longest + secondLongest + 1);
        return longest + 1;
    }
}



// public class Solution {
//     public int LongestPath(int[] parent, string s) {
//         int n = parent.Length;
//         int[] childrenCount = new int[n];

//         // Count number of children for each node
//         for (int node = 1; node < n; node++) {
//             childrenCount[parent[node]]++;
//         }

//         Queue<int> queue = new Queue<int>();
//         int longestPath = 1;
//         int[,] longestChains = new int[n, 2]; // [node, {longest, secondLongest}]

//         // Start from the leaf nodes
//         for (int node = 1; node < n; node++) {
//             if (childrenCount[node] == 0) {
//                 longestChains[node, 0] = 1;
//                 queue.Enqueue(node);
//             }
//         }

//         while (queue.Count > 0) {
//             int currentNode = queue.Dequeue();
//             int par = parent[currentNode];

//             int longestFromCurrent = longestChains[currentNode, 0];

//             if (s[currentNode] != s[par]) {

//                 if (longestFromCurrent > longestChains[par, 0]) {
//                     longestChains[par, 1] = longestChains[par, 0];
//                     longestChains[par, 0] = longestFromCurrent;
//                 }
//                 else if (longestFromCurrent > longestChains[par, 1]) {
//                     longestChains[par, 1] = longestFromCurrent;
//                 }
//             }

//             longestPath = Math.Max(longestPath, longestChains[par, 0] + longestChains[par, 1] + 1);
//             childrenCount[par]--;

//             if (childrenCount[par] == 0 && par != 0) {
//                 longestChains[par, 0]++;
//                 queue.Enqueue(par);
//             }
//         }

//         return longestPath;
//     }
// }
