public class Solution {
    public IList<IList<string>> Partition(string s)
    {
        IList<IList<string>> result = new List<IList<string>>();
        Backtrack(result, new List<string>(), s, 0);
        return result;
    }

    private void Backtrack(IList<IList<string>> result, List<string> tempList, string s, int start)
    {
        if (start == s.Length)
        {
            result.Add(new List<string>(tempList));
        }
        else
        {
            for (int i = start; i < s.Length; i++)
            {
                if (IsPalindrome(s, start, i))
                {
                    tempList.Add(s.Substring(start, i - start + 1));
                    Backtrack(result, tempList, s, i + 1);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }
    }

    private bool IsPalindrome(string s, int low, int high)
    {
        while (low < high)
        {
            if (s[low] != s[high])
            {
                return false;
            }
            low++;
            high--;
        }
        return true;
    }
}