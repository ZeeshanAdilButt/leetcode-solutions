// public class Solution {
//     public bool JudgeSquareSum(int c) {
        
//         HashSet<int> set = new HashSet<int>();
        
//         for (int i = 0; i<= Math.Sqrt(c); i++){
            
            
//             set.Add(i*i);
            
//             if (set.Contains( c - (i * i)))
//                 return true;
            
            
//         }
        
//         return false;
        
//     }
// }

//two pointer

public class Solution {
    public bool JudgeSquareSum(int c) {
        
        int left = 0;
        long right =  (int)Math.Sqrt(c);
        
        while (left<=right){
            
           long current = left*left + (long)right*right;
            
            if (current > c){
                right--;
            }
            else if (current < c){
                left++;
            }
            else{
                return true;
            }
            
        }
        
        return false;
        
    }
}