public class Solution {
    public int FindBestValue(int[] arr, int target) {
        Array.Sort(arr);
        int n = arr.Length;
        int index = 0;

        // Reduce the target by subtracting fixed values until remaining elements may need to be capped
        while (index < n && target > arr[index] * (n - index)) {
            target -= arr[index];
            index++;
        }

        // If all elements are used as-is and target not exceeded, return max element
        if (index == n) return arr[n - 1];

        // Now determine the best cap value for remaining elements
        int candidate = target / (n - index);

        // Compare candidate vs candidate + 1 to see which gives a sum closer to target
        int sumWithCandidate = candidate * (n - index);
        int sumWithNext = (candidate + 1) * (n - index);

        // If rounding up gives closer result, choose that
        if (Math.Abs(target - sumWithCandidate) > Math.Abs(sumWithNext - target)) {
            candidate++;
        }

        return candidate;
    }
}
