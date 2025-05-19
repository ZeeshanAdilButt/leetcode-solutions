public class Solution
{
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
    {
        UnionFind uf = new UnionFind(accounts.Count);
        Dictionary<string, int> emailToIndex = new Dictionary<string, int>();

        for (int i = 0; i < accounts.Count; i++)
        {
            for (int j = 1; j < accounts[i].Count; j++)
            {
                string email = accounts[i][j];

                if (emailToIndex.ContainsKey(email))
                {
                    uf.Union(i, emailToIndex[email]);
                    continue;
                }
                else
                {
                    emailToIndex[email] = i;
                }
            }
        }

        // Map root index to list of emails
        Dictionary<int, List<string>> merged = new Dictionary<int, List<string>>();
        foreach (var kvp in emailToIndex)
        {
            string email = kvp.Key;
            int index = uf.Find(kvp.Value);

            if (!merged.ContainsKey(index))
            {
                merged[index] = new List<string>();
            }

            merged[index].Add(email);
        }

        // Build final result
        IList<IList<string>> result = new List<IList<string>>();
        foreach (var kvp in merged)
        {
            int idx = kvp.Key;
            List<string> emails = kvp.Value;
            emails.Sort(StringComparer.Ordinal);

            List<string> account = new List<string> { accounts[idx][0] }; // account name
            account.AddRange(emails);
            result.Add(account);
        }

        return result;
    }

    public class UnionFind
    {
        private int[] parent;

        public UnionFind(int size)
        {
            parent = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); // path compression
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                parent[rootX] = rootY;
            }
        }
    }
}
