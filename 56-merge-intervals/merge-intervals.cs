public class Solution {
        public int[][] Merge(int[][] intervals) {
        // edge case: if the input array is null or empty, return it as is
        if (intervals == null || intervals.Length == 0) return intervals;
        
        // sort the intervals by their start times
        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        
        // create a list to store the merged intervals
        List<int[]> result = new List<int[]>();
        
        // initialize the current interval as the first interval in the sorted array
        int[] lastaddedInterval = intervals[0];
        
        // iterate through the rest of the intervals
        for (int current = 1; current < intervals.Length; current++) {
            
            // if the current interval overlaps with the next interval
            if (lastaddedInterval[1] >= intervals[current][0]) {
                // merge the two intervals by updating the end time of the current interval
                lastaddedInterval[1] = Math.Max(lastaddedInterval[1], intervals[current][1]);
            } else {
                // if there is no overlap, add the current interval to the result list and update the current interval
                result.Add(lastaddedInterval);
                lastaddedInterval = intervals[current];
            }
        }
        
        // add the last current interval to the result list
        result.Add(lastaddedInterval);
        
        // convert the result list to a 2D array and return it
        return result.ToArray();
    }

}