
public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        int left = 1;
        int right = quantities.Max();
        int result = right;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (CanDistribute(n, quantities, mid)) {
                result = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        return result;
    }

    private bool CanDistribute(int n, int[] quantities, int maxProducts) {
        int requiredStores = 0;
        foreach (int quantity in quantities) {
            //The expression quantity + maxProducts - 1 is a common trick used to round up when dividing integers in programming. This trick ensures that any remainder from the division is properly accounted for by adding one more to the integer division result when there is a remainder.
            requiredStores += (quantity + maxProducts - 1) / maxProducts;
            if (requiredStores > n) {
                return false;
            }
        }
        return true;
    }
}