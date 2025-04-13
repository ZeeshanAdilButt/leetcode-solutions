public class Solution {
    public int KthSmallest(int[][] matrix, int k)
    {
        int n = matrix.Length;

        // PriorityQueue stores (value, row, col) with value as the priority
        var minHeap = new PriorityQueue<(int value, int row, int col), int>();

        // Initialize heap with first element of each row (up to k rows)
        for (int r = 0; r < Math.Min(n, k); r++)
        {
            minHeap.Enqueue((matrix[r][0], r, 0), matrix[r][0]);
        }

        (int value, int row, int col) element = (0, 0, 0);

        while (k-- > 0)
        {
            element = minHeap.Dequeue();
            int r = element.row, c = element.col;

            // Push next element in the same row
            if (c < n - 1)
            {
                minHeap.Enqueue((matrix[r][c + 1], r, c + 1), matrix[r][c + 1]);
            }
        }

        return element.value;
    }
}