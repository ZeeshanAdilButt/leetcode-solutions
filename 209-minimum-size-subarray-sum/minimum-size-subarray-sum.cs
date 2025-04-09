public class Solution {
   
public int MinSubArrayLen(int target, int[] nums)
{
	int WindowSize = int.MaxValue;
	int CurrSubArrSize = 0;
	int start = 0;
	int sum = 0;

    for (int end = 0; end < nums.Length; end++)
    {
        sum += nums[end];
        while (sum >= target)
        {
            CurrSubArrSize = (end + 1) - start;
            WindowSize = Math.Min(WindowSize, CurrSubArrSize);
            sum -= nums[start];
            start += 1;
        }
    }

    if (WindowSize != int.MaxValue)
    {
        return WindowSize;
    }
    return 0;
}

}