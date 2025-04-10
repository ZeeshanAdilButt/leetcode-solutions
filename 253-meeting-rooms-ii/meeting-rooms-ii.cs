// public class Solution {
//     public int MinMeetingRooms(int[][] intervals) {
        
//     }

    public class Solution {
        public int MinMeetingRooms(int[][] intervals) {

            Array.Sort(intervals, (a, b) => {
        return a[0] == b[0] ? a[1] - b[1] : a[0] - b[0];
    });
            var minHeap = new PriorityQueue<int, int>();
            
            foreach (var interval in intervals) {
                if (minHeap.Count > 0 && minHeap.Peek() <= interval[0]) {
                    minHeap.Dequeue();
                }
                minHeap.Enqueue(interval[1], interval[1]);
            }
            
            return minHeap.Count;
        }
    }
// }
// public class Solution {
//    public int MinMeetingRooms(int[][] intervals) {
//     if (intervals == null || intervals.Length == 0) return 0;
    
//     // Sort intervals by start time
//     Array.Sort(intervals, (a, b) => {
//     return a[0] == b[0] ? a[1] - b[1] : a[0] - b[0];
// });
    
//     int rooms = 1;
//     int[] previousMeeting = intervals[0];
    
//     for (int i = 1; i < intervals.Length; i++) {
//         int[] currentMeeting = intervals[i];
        
//         // If the current meeting starts before the previous meeting ends
//         // we need another room
//         if (currentMeeting[0] < previousMeeting[1]) {
//             rooms++;
//             // We need to consider the appropriate meeting as "previous" for next comparison
//             // If the current meeting ends before the previous meeting, it becomes the new reference
//             // if (currentMeeting[1] < previousMeeting[1]) {
//                 previousMeeting = currentMeeting;
//             // }
//         } else {
//             // No overlap, update previous meeting
//             previousMeeting = currentMeeting;
//         }
//     }
    
//     return rooms;
// }
// }
