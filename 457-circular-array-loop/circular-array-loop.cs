public class Solution {
    public bool CircularArrayLoop(int[] nums) {
       int n = nums.Length;
        
        // Try each position as a potential starting point
        for (int start = 0; start < n; start++) {
            int slow = start;
            int fast = start;
            // Determine direction: positive = forward, negative = backward
            bool isForward = nums[start] > 0;
            
            do {
                // Move slow pointer one step
                slow = GetNextPosition(nums, slow, isForward);
                if (slow == -1) break; // Invalid path detected
                
                // Move fast pointer two steps
                fast = GetNextPosition(nums, fast, isForward);
                if (fast == -1) break; // Invalid path detected
                
                fast = GetNextPosition(nums, fast, isForward);
                if (fast == -1) break; // Invalid path detected
                
                // If cycle is found (slow and fast pointers meet)
                if (slow == fast) return true;
                
            } while (true);
        }
        
        // No valid cycle found after checking all starting positions
        return false; 
    }

      private static int GetNextPosition(int[] nums, int current, bool isForward) {
        // Check if direction changed (must be consistent)
        bool currentDirection = nums[current] > 0;
        if (isForward != currentDirection) return -1;
        
        // Check if it's a one-element cycle (not allowed)
        if (nums[current] % nums.Length == 0) return -1;
        
        // Calculate next position with proper modulo handling for negative numbers
        int next = (current + nums[current]) % nums.Length;
        if (next < 0) next += nums.Length; // Handle negative wrap-around
        
        // If we've circled back to same element, it's not a valid cycle (needs multiple elements)
        if (next == current) return -1;
        
        return next;
    }
}