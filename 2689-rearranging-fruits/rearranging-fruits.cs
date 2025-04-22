public class Solution {
    public long MinCost(int[] basket1, int[] basket2) {
        Dictionary<int, int> count = new Dictionary<int, int>();
        
        // Count frequencies of all elements in both baskets
        foreach (int num in basket1) {
            if (!count.ContainsKey(num)) {
                count[num] = 0;
            }
            count[num]++;
        }
        
        foreach (int num in basket2) {
            if (!count.ContainsKey(num)) {
                count[num] = 0;
            }
            count[num]--;
        }
        
        // Check if rearrangement is possible
        foreach (var entry in count) {
            if (entry.Value % 2 != 0) {
                return -1; // Odd count means equal distribution is impossible
            }
        }
        
        // Collect elements to move (half of the differences)
        List<int> toMove = new List<int>();
        foreach (var entry in count) {
            int val = entry.Key;
            int freq = Math.Abs(entry.Value) / 2;
            
            for (int i = 0; i < freq; i++) {
                toMove.Add(val);
            }
        }
        
        // Sort elements to move
        toMove.Sort();
        
        // Find minimum value across both baskets for potential swaps
        int minVal = int.MaxValue;
        foreach (int num in basket1) {
            minVal = Math.Min(minVal, num);
        }
        foreach (int num in basket2) {
            minVal = Math.Min(minVal, num);
        }
        
        // Calculate minimum cost
        long result = 0;
        for (int i = 0; i < toMove.Count / 2; i++) {
            // For each element to move, we can either:
            // 1. Move it directly (costs value of the element)
            // 2. Swap via minVal (costs 2 * minVal)
            result += Math.Min(toMove[i], 2 * minVal);
        }
        
        return result;
    }
}