public class Solution {
    public string ReplaceWords(IList<string> dictionary, string sentence) {
        
        Trie trie = new Trie();
        trie.root = new TrieNode();

        foreach (string prefix in dictionary)
        {
            trie.Insert(prefix);
        }

        List<string> sentenceList = sentence.Split(' ').ToList();
        List<string> newList = new List<string>();

        foreach (string str in sentenceList)
        {
            newList.Add(trie.Replace(str));
        }

        return string.Join(" ", newList);
    }
}


public class Trie
{
    public TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode current = root;

        foreach (char c in word)
        {
            if (!current.Children.ContainsKey(c))
            {
                current.Children[c] = new TrieNode();
            }

            current = current.Children[c];
        }

        current.IsEndOfWord = true;
    }

    public string Replace(string word)
    {
        TrieNode current = root;

        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            if (!current.Children.ContainsKey(c))
            {
                return word;
            }

            current = current.Children[c];

            if (current.IsEndOfWord)
            {
                return word.Substring(0, i + 1);
            }
        }

        return word;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; private set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}