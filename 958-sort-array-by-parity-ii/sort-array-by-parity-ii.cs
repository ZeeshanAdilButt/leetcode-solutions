public class Solution {
    public int[] SortArrayByParityII(int[] a) {
        int i = 0; // pointer for even misplaced
        int j = 1; // pointer for odd misplaced
        int sz = a.Length;
        
        // invariant: for every misplaced odd there is misplaced even
        // since there is just enough space for odds and evens

        while (i < sz && j < sz) {
            if (a[i] % 2 == 0) {
                i += 2;
            } else if (a[j] % 2 == 1) {
                j += 2;
            } else {
                // a[i] % 2 == 1 AND a[j] % 2 == 0
                Swap(ref a[i], ref a[j]);
                i += 2;
                j += 2;
            }
        }

        return a;
    }

    private void Swap(ref int x, ref int y) {
        int temp = x;
        x = y;
        y = temp;
    }
}
