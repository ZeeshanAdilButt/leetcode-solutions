public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0])
            {
                return b[1] - a[1];
            }
            else
            {
                return a[0] - b[0];
            }
        });

        int count = 0;
        int prevEnd = 0; 

        foreach (var interval in intervals)
        {
            int end = interval[1];
            if (end > prevEnd)
            {
                count++;
                prevEnd = end;
            }
        }

        return count;
    }
}