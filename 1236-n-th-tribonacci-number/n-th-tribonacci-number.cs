public class Solution {
    public int Tribonacci(int n) {


        if(n==0)
            return 0;

        if(n <= 2)
            return 1;

        int[] memo = new int[n + 1];

        memo[0]= 0;
        memo[1]=1;
        memo[2]=1;

        for (int i = 3; i < n +1; i++){

            memo[i] = memo[i-1] +  memo[i-2] +  memo[i-3];
        }

    

        return memo[n];
    
        
    }

    // public int Tribonacci(int n, int[] memo ) {

       

    //     if(n==0)
    //         return 0;

    //     if(n <= 2)
    //         return 1;

    //          if(memo[n] != 0 )
    //             return memo[n];

    //     int res = 0;

    //     res+=   Tribonacci(n -1, memo );
    //      res+=  Tribonacci(n -2, memo) ;
    //      res+= Tribonacci(n -3, memo) ;

    //     memo[n] = res;

    //     return res;
        
    // }
}