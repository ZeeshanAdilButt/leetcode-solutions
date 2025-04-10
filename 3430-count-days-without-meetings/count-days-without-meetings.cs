public class Solution {
   public int CountDays(int days, int[][] meetings)
    {
        // Sort the meetings based on their start time to process them in order
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        
        // Initialize a variable with 0 to count the number of days when the employee has meetings scheduled
        int occupied = 0;
        
        // Initialize two variables with the first meeting’s start and end times
        int start = meetings[0][0], end = meetings[0][1];
        
        // Iterate through the remaining meetings
        for (int i = 1; i < meetings.Length; i++)
        {
            // If a meeting overlaps with the current merged meeting
            if (meetings[i][0] <= end)
            {
                // Extend the end time to merge it
                end = Math.Max(end, meetings[i][1]);
            }
            else
            {
                // Add the days of the merged meeting
                occupied += (end - start + 1);
                
                // Update start and end for the next interval
                start = meetings[i][0];
                end = meetings[i][1];
            }
        }
        
        // Add the days of the last merged meeting
        occupied += (end - start + 1);
        
        // Return the free days
        return days - occupied;
    }
}