public class Solution {
  public int SmallestChair(int[][] times, int targetFriend)
    {
        List<(int FriendId, int Arrival, int Leaving)> sortedFriends = new();

        for (int i = 0; i < times.Length; i++)
        {
            sortedFriends.Add((i, times[i][0], times[i][1]));
        }

        // Sort by arrival time
        sortedFriends.Sort((a, b) => a.Arrival.CompareTo(b.Arrival));

        // PQ of (leaveTime, chairNumber) - chairs that are currently occupied
        var occupiedChairs = new PriorityQueue<(int Leave, int Chair), int>();

        // PQ of available chairs - keeps the smallest free chair number at the top
        var availableChairs = new PriorityQueue<int, int>();

        int nextChair = 0;

        foreach (var (friendId, arrival, leaving) in sortedFriends)
        {
            // Free up chairs where leaveTime <= arrival time
            while (occupiedChairs.Count > 0 && occupiedChairs.Peek().Leave <= arrival)
            {
                var (_, freedChair) = occupiedChairs.Dequeue();
                availableChairs.Enqueue(freedChair, freedChair);
            }

            // Assign the smallest available chair or create a new one
            int assignedChair;
            if (availableChairs.Count > 0)
            {
                assignedChair = availableChairs.Dequeue();
            }
            else
            {
                assignedChair = nextChair++;
            }

            // Mark the chair as occupied until `leaving`
            occupiedChairs.Enqueue((leaving, assignedChair), leaving);

            if (friendId == targetFriend)
            {
                return assignedChair;
            }
        }

        return -1; // Should never hit
    }
}