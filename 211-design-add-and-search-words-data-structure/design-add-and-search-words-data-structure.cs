public class WordDictionary {
    private TrieNode root;

    /** Initialize your data structure here. */
    public WordDictionary() {
        root = new TrieNode();
    }

    /** Adds a word into the data structure. */
    public void AddWord(string word) {
        
        TrieNode node = root;

        foreach (char c in word) {
            if (!node.children.ContainsKey(c)) {
                node.children[c] = new TrieNode();
            }
            node = node.children[c];
        }
        node.isEndOfWord = true;
    }

    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search(string word) {
        return Search(word, root, 0);
    }

    private bool Search(string word, TrieNode node, int index) {

        if (index == word.Length) {
            return node.isEndOfWord;
        }

        char c = word[index];
        if (c != '.') {
            if (!node.children.ContainsKey(c)) {
                return false;
            }
            return Search(word, node.children[c], index + 1);
        } else {
            foreach (TrieNode child in node.children.Values) {
                if (Search(word, child, index + 1)) {
                    return true;
                }
            }
            return false;
        }
    }

    private class TrieNode {
        public Dictionary<char, TrieNode> children;
        public bool isEndOfWord;

        public TrieNode() {
            children = new Dictionary<char, TrieNode>();
            isEndOfWord = false;
        }
    }
}


/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */