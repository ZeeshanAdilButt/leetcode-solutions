public class Solution {
    public int FindCenter(int[][] edges) {
        
        int[] first = edges[0];
        
        int[] second = edges[1];

        if (second.Contains(first[0]))
        {
            return first[0];
        }
        else
        {
            return first[1];
        }
    }
}