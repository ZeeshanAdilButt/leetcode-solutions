public class Solution {

    public int Jump(int[] nums) {

        // The starting range of the first jump is [0, 0]
        int answer = 0, n = nums.Length;
        int curEnd = 0, curFar = 0;

        for (int i = 0; i < n - 1; ++i) {
            // Update the farthest reachable index of this jump.
            curFar = Math.Max(curFar, i + nums[i]);
        
            // If we finish the starting range of this jump,
            // Move on to the starting range of the next jump.
            if (i == curEnd) {
                answer++;
                curEnd = curFar;
            }
        }

        return answer;
    }
    
}