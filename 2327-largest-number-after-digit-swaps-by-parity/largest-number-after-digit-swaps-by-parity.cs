public class Solution {
   public int LargestInteger(int num)
    {
        List<int> digits = new List<int>();
        foreach (char c in num.ToString())
        {
            digits.Add(c - '0');
        }

        // Use negative values to simulate a MaxHeap using PriorityQueue
        var oddHeap = new PriorityQueue<int, int>();
        var evenHeap = new PriorityQueue<int, int>();

        foreach (int d in digits)
        {
            if (d % 2 == 0)
                evenHeap.Enqueue(d, -d); 
            else
                oddHeap.Enqueue(d, -d);
        }

        List<int> result = new List<int>();
        foreach (int d in digits)
        {
            if (d % 2 == 0)
            {
                result.Add(evenHeap.Dequeue());
            }
            else
            {
                result.Add(oddHeap.Dequeue());
            }
        }

        int outputNumber = 0;
        foreach (int d in result)
        {
            outputNumber = outputNumber * 10 + d;
        }

        return outputNumber;
    }
}