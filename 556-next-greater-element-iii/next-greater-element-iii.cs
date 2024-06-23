public class Solution {
    public int NextGreaterElement(int n) {
        char[] digits = n.ToString().ToCharArray();
        
        // Find the first digit from right to left that is smaller than the digit next to it
        int i = digits.Length - 2;
        while (i >= 0 && digits[i] >= digits[i + 1]) {
            i--;
        }
        
        if (i == -1) {
            return -1; // No such permutation possible
        }
        
        // Find the smallest digit greater than digits[i] to the right of digits[i]
        int j = digits.Length - 1;
        while (j >= 0 && digits[j] <= digits[i]) {
            j--;
        }
        
        // Swap digits[i] and digits[j]
        Swap(digits, i, j);
        
        // Reverse the digits to the right of digits[i]
        Reverse(digits, i + 1, digits.Length - 1);
        
        try {
            return int.Parse(new string(digits));
        } catch {
            return -1; // Overflow
        }
    }
    
    private void Swap(char[] arr, int i, int j) {
        char temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    
    private void Reverse(char[] arr, int start, int end) {
        while (start < end) {
            Swap(arr, start++, end--);
        }
    }
}
