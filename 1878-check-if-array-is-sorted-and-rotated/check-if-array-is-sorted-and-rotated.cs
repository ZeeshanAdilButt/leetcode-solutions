public class Solution {
    public bool Check(int[] A) {
        
    int k = 0, n = A.Length;
        
        
    for (int i = 0; i < n; ++i) {
        if (A[i] > A[(i + 1) % n]) {
            k++;
        }
        if (k > 1) {
            return false;
        }
    }
    return true;
        
            
        
    }
}