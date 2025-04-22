public class Solution {
    public int MaximumSwap(int num) {
        char[] numString = num.ToString().ToCharArray();
        int n = numString.Length;
        int maxDigitIndex = -1, index1 = -1, index2 = -1;

        for (int i = n - 1; i >= 0; i--)
        {
            if (maxDigitIndex == -1 || numString[i] > numString[maxDigitIndex])
            {
                maxDigitIndex = i;
            } else if (numString[i] < numString[maxDigitIndex])
            {
                index1 = i;
                index2 = maxDigitIndex;
            }
        }

        if (index1 != -1 && index2 != -1)
        {
            char temp = numString[index1];
            numString[index1] = numString[index2];
            numString[index2] = temp;
        }
        
        return int.Parse(new string(numString));
    }
}