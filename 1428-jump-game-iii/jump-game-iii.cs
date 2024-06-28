public class Solution {
    public bool CanReach(int[] arr, int st) {
        
        if (st >= 0 && st < arr.Length && arr[st] < arr.Length) {
            
            int jump = arr[st];
            
            arr[st] += arr.Length;
            
            return jump == 0 || CanReach(arr, st + jump) || CanReach(arr, st - jump);
        }
        
        return false;
    }
}
