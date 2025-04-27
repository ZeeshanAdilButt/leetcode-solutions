public class Solution {
    public int Tribonacci(int n) {

        int[] memo = new int[n + 1];

        // if(n==0)
        //     return 0;

        // if(n <= 2)
        //     return 1;

        return  Tribonacci(n, memo);
    
        
    }

    public int Tribonacci(int n, int[] memo ) {

       

        if(n==0)
            return 0;

        if(n <= 2)
            return 1;

             if(memo[n] != 0 )
                return memo[n];

        int res = 0;

         res+= Tribonacci(n -3, memo) ;
         res+=  Tribonacci(n -2, memo) ;
        res+=   Tribonacci(n -1, memo );

        memo[n] = res;

        return res;
        
    }
}