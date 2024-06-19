public class Solution {
    public bool JudgeSquareSum(int c) {
        
        HashSet<int> set = new HashSet<int>();
        
        for (int i = 0; i<= Math.Sqrt(c); i++){
            
            
            set.Add(i*i);
            
            if (set.Contains( c - (i * i)))
                return true;
            
            
        }
        
        return false;
        
    }
}