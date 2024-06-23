public class Solution {
   
    public IList<IList<int>> Combine(int n, int k)
    {
        var result = new List<IList<int>>();
        var combination = new List<int>();
        Backtrack(n, k, 1, combination, result);
        return result;
    }

    private void Backtrack(int n, int k, int start, List<int> combination, List<IList<int>> result)
    {
        if (combination.Count == k)
        {
            result.Add(new List<int>(combination));
            return;
        }

        for (int i = start; i <= n; i++)
        {
            combination.Add(i);
            Backtrack(n, k, i + 1, combination, result);
            combination.RemoveAt(combination.Count - 1);
        }
    }
}