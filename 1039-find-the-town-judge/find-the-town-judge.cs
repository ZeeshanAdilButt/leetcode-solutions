public class Solution {

    public int FindJudge(int n, int[][] trust)
    {
        int[] delta = new int[n + 1];

        foreach (var t in trust)
        {
            delta[t[0]]--; // the person who trusts loses score
            delta[t[1]]++; // the person being trusted gains score
        }

        for (int i = 1; i <= n; i++)
        {
            if (delta[i] == n - 1)
                return i;
        }

        return -1;
    }

    // public int FindJudge(int n, int[][] trust) {

    //     if (trust.Length < n - 1)
    //     {
    //         return -1;
    //     }

    //     int[] indegree = new int[n + 1];
    //     int[] outdegree = new int[n + 1];

    //     foreach (int[] relation in trust)
    //     {
    //         int a = relation[0];
    //         int b = relation[1];

    //         outdegree[a]++;
    //         indegree[b]++;
    //     }

    //     for (int i = 1; i <= n; i++)
    //     {
    //         if (indegree[i] == n - 1 && outdegree[i] == 0)
    //         {
    //             return i;
    //         }
    //     }

    //     return -1;
    // }
}