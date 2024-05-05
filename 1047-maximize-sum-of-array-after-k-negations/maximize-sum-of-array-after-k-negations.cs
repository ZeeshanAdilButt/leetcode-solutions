public class Solution {
    public int LargestSumAfterKNegations(int[] A, int K) {
        Array.Sort(A);
        int i = 0;
        
        while (K > 0 && i < A.Length && A[i] < 0) {
            A[i] = -A[i];
            K--;
            i++;
        }
        
        Array.Sort(A);
        
        if (K % 2 != 0)
            A[0] = -A[0];
        
        int sum = 0;
        foreach (int num in A)
            sum += num;
        
        return sum;
    }
}
