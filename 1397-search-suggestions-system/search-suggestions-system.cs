public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {
        Array.Sort(products); // Sort lexicographically
        var result = new List<IList<string>>();
        string prefix = "";

        foreach (char c in searchWord) {
            prefix += c;

            int start = LowerBound(products, prefix);
            var suggestions = new List<string>();

            for (int i = start; i < Math.Min(start + 3, products.Length); i++) {
                if (products[i].StartsWith(prefix))
                    suggestions.Add(products[i]);
                else
                    break;
            }

            result.Add(suggestions);
        }

        return result;
    }

    private int LowerBound(string[] products, string prefix) {
        int low = 0, high = products.Length;

        while (low < high) {
            int mid = (low + high) / 2;
            if (String.Compare(products[mid], prefix) < 0)
                low = mid + 1;
            else
                high = mid;
        }

        return low;
    }
}


// public class TrieNode {
//     public SortedSet<string> Words = new SortedSet<string>();
//     public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
// }

// public class Trie {
//     private TrieNode root = new TrieNode();

//     public void Insert(string word) {
//         TrieNode node = root;

//         foreach (char c in word) {
        
//             if (!node.Children.ContainsKey(c))
//                 node.Children[c] = new TrieNode();

//             node = node.Children[c];

//             if (node.Words.Count < 3)
//                 node.Words.Add(word);
//         }
//     }

//     public IList<IList<string>> Search(string prefix) {
        
//         var result = new List<IList<string>>();
        
//         TrieNode node = root;

//         foreach (char c in prefix) {

//             if (node == null || !node.Children.ContainsKey(c)) {
//                 node = null;
//                 result.Add(new List<string>());
//             }
//             else {
//                 node = node.Children[c];
//                 result.Add(node.Words.ToList());
//             }
//         }

//         return result;
//     }
// }

// public class Solution {
//     public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) {

//         Array.Sort(products);
//         Trie trie = new Trie();

//         foreach (var word in products)
//             trie.Insert(word);
        
//         return trie.Search(searchWord);
//     }
// }
