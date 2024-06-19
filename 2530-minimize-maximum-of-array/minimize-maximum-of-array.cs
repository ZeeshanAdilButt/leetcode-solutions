public class Solution {
    public int MinimizeArrayValue(int[] A) {
        long sum = 0, res = 0;
        for (int i = 0; i < A.Length; ++i) {
            sum += A[i];
            res = Math.Max(res, (sum + i) / (i + 1));
        }
        return (int)res;
    }
}
