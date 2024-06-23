public class Solution {
    public int[] NextGreaterElements(int[] nums) {
            
        int[] res = new int[nums.Length];
        
        for (int i =0; i < nums.Length; i++){
            res[i] = -1;
        }
        
        Stack<int> stack = new Stack<int>();
        
        for (int i =0; i < nums.Length * 2 ; i++){
            
            
            while(stack.Count!=0 && nums[stack.Peek()] < nums[i% nums.Length]){
                
                res[stack.Pop()] = nums[i % nums.Length];
            }
            
            stack.Push(i % nums.Length);
        }
        
        return res;        
    }
    
//     public int[] NextGreaterElements(int[] A)
//     {
//         int n = A.Length;
//         int[] res = new int[n];
//         Array.Fill(res, -1);
//         Stack<int> stack = new Stack<int>();
        
//         for (int i = 0; i < n * 2; i++)
//         {
//             while (stack.Count > 0 && A[stack.Peek()] < A[i % n])
//             {
//                 res[stack.Pop()] = A[i % n];
//             }
//             stack.Push(i % n);
//         }
        
//         return res;
//     }
}

