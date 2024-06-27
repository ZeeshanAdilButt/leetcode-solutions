
public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        
        List<KeyValuePair<int, int>> jobs = new List<KeyValuePair<int, int>>();
        
        int N = profit.Length, res = 0, i = 0, best = 0;
        

        for (int j = 0; j < N; ++j) {
            jobs.Add(new KeyValuePair<int, int>(difficulty[j], profit[j]));
        }

        jobs.Sort((a, b) => a.Key.CompareTo(b.Key));
        Array.Sort(worker);

        foreach (int ability in worker) {
            while (i < N && ability >= jobs[i].Key) {
                best = Math.Max(jobs[i].Value, best);
                i++;
            }
            res += best;
        }

        return res;
    }
}
