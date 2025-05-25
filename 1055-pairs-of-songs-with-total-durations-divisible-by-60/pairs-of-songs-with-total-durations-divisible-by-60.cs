public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
       int[] remainders = new int[60];
        int count = 0;

        foreach (int t in time)
        {
            int remainder = t % 60;

            if (remainder == 0)
            {
                count += remainders[0];
            }
            else
            {
                count += remainders[60 - remainder];
            }

            remainders[remainder]++;
        }

        return count; 
    }
}