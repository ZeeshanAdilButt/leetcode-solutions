public class Solution {
    public int MaxProduct(int[] nums) {
        List<List<int>> A = new List<List<int>>();
        List<int> cur = new List<int>();
        int res = int.MinValue;

        foreach (int num in nums) {
            res = Math.Max(res, num);
            if (num == 0) {
                if (cur.Count > 0) {
                    A.Add(new List<int>(cur));
                }
                cur.Clear();
            } else cur.Add(num);
        }
        if (cur.Count > 0) A.Add(new List<int>(cur));

        foreach (var sub in A) {
            int negs = 0;
            foreach (var i in sub) {
                if (i < 0) negs++;
            }

            int prod = 1;
            int need = (negs % 2 == 0) ? negs : (negs - 1);
            negs = 0;
            for (int i = 0, j = 0; i < sub.Count; i++) {
                prod *= sub[i];
                if (sub[i] < 0) {
                    negs++;
                    while (negs > need) {
                        prod /= sub[j];
                        if (sub[j] < 0) negs--;
                        j++;
                    }
                }
                if (j <= i) res = Math.Max(res, prod);
            }
        }
        return res;
    }
}