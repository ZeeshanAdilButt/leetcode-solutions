public class Solution 
{
    private long GetSum(int index, int value, int n) 
    {
        long count = 0;
        
        // On index's left:
        if (value > index) 
        {
            // n would be decreased by value  index => if value is 4 and index is 2. then 
            // 4 + 4 - 2
                // int leftnum = value - index;
                // count += (leftnum + value) * index + 1 / 2;
            // sum of sequence between 2 numbers is [left + right] * n / 2
            count += (long)( (value - index) + value ) * (index + 1) / 2;
        } 
        else 
        {
            // n (n + 1 ) / 2 + remaining 1s on the left 
            count += (long) value * (value + 1)  / 2 + index - value + 1;
        }
        
        // On index's right:
        // if there are less elements on the right as value is greater than the index
        if (value >= n - index) 
        {
             // sum of sequence between 2 numbers is [left + right] * n / 2
            count += (long) (n - index) * (value + (value - n + 1 + index)) / 2;
        } 
        else 
        {
            // n (n + 1 ) / 2 + remaining 1s on the right 
            count += (long)value * (value + 1)  / 2 + n - index - value;
        }   
        
        return count - value;
    }
    
    public int MaxValue(int n, int index, int maxSum) 
    {
        int left = 1, right = maxSum;
        while (left < right) 
        {
            int mid = (left + right + 1) / 2;
            if (GetSum(index, mid, n) <= maxSum) 
            {
                left = mid;
            } 
            else 
            {
                right = mid - 1;
            }
        }
        
        return left;
    }
}