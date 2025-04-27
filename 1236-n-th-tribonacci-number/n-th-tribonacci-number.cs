public class Solution {
    public int Tribonacci(int n) {


        if(n==0)
            return 0;

        if(n <= 2)
            return 1;

        int[] memo = new int[n + 1];

        int firstNum = 0;
        int secondNum =1;
        int thirdNum =1;

        int res  = 0;

        for (int i = 3; i < n +1; i++){

            res = firstNum + secondNum + thirdNum;
            firstNum = secondNum;
            secondNum = thirdNum;
            thirdNum = res;
        }

        return res;
    
        
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