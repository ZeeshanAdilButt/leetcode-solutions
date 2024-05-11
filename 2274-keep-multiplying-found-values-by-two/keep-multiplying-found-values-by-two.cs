public class Solution {
    public int FindFinalValue(int[] nums, int original) {
         int n = 1;
        for (int i = 0; i < n; ++i)
        {
            if (nums.Contains(original))
            {
                original *= 2;
                n += 1; // n is incremented by one because the question wants us to perform the operation again if the element is found again after its double.
            }
        }
        return original;
    }
    }


