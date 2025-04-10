/*
// Definition for an Interval.
public class Interval {
    public int start;
    public int end;

    public Interval(){}
    public Interval(int _start, int _end) {
        start = _start;
        end = _end;
    }
}
*/

// public class Solution {

//     public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule)
//     {
//         // Flatten the schedule and sort intervals by start time
//         List<Interval> intervals = schedule
//             .SelectMany(s => s)
//             .OrderBy(x => x.start)
//             .ToList();
        
//         // Handle edge case of empty schedule
//         if (intervals.Count == 0) {
//             return new List<Interval>();
//         }
        
//         List<Interval> ans = new List<Interval>();
//         int end = intervals[0].end;
        
//         // Iterate through intervals starting from the second one
//         for (int i = 1; i < intervals.Count; i++)
//         {
//             Interval interval = intervals[i];
            
//             // If there's a gap between the end of previous interval and start of current
//             if (interval.start > end)
//             {
//                 ans.Add(new Interval(end, interval.start));
//             }
            
//             // Update end to be the maximum of current end and previous end
//             end = Math.Max(end, interval.end);
//         }
        
//         return ans;
//     }
// }

public class Solution {
    public IList<Interval> EmployeeFreeTime(IList<IList<Interval>> schedule) {
        // Create a min-heap sorted by interval start time
        var minHeap = new PriorityQueue<Interval, int>();
        
        // Push all intervals into the heap
        foreach (var employeeSchedule in schedule) {
            foreach (var interval in employeeSchedule) {
                minHeap.Enqueue(interval, interval.start);
            }
        }
        
        // Handle edge case of empty schedule
        if (minHeap.Count == 0) {
            return new List<Interval>();
        }
        
        List<Interval> ans = new List<Interval>();
        Interval prev = minHeap.Dequeue();
        int end = prev.end;
        
        while (minHeap.Count > 0) {
            Interval current = minHeap.Dequeue();
            
            // If there's a gap between the end of previous interval and start of current
            if (current.start > end) {
                ans.Add(new Interval(end, current.start));
            }
            
            // Update end to be the maximum of current end and previous end
            end = Math.Max(end, current.end);
        }
        
        return ans;
    }
}