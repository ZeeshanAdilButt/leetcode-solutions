public class Solution {
     public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        // Priority queue with inline comparer for max-heap based on gain
        var maxHeap = new PriorityQueue<(double gain, int pass, int total), double>(
            Comparer<double>.Create((a, b) => b.CompareTo(a)) // max-heap: higher gain first
        );

        // Populate the priority queue with initial gains
        foreach (var cls in classes)
        {
            int pass = cls[0];
            int total = cls[1];
            double gain = CalculateGain(pass, total);
            maxHeap.Enqueue((gain, pass, total), gain);
        }

        // Add extra students to the classes with max gain
        while (extraStudents > 0)
        {
            var (gain, pass, total) = maxHeap.Dequeue();
            pass++;
            total++;
            double newGain = CalculateGain(pass, total);
            maxHeap.Enqueue((newGain, pass, total), newGain);

            extraStudents--;
        }

        // Calculate the final average pass ratio
        double totalPassRatio = 0;
        while (maxHeap.Count > 0)
        {
            var (_, pass, total) = maxHeap.Dequeue();
            totalPassRatio += (double)pass / total;
        }

        return totalPassRatio / classes.Length;
    }

    private double CalculateGain(int pass, int total)
    {
        return (double)(pass + 1) / (total + 1) - (double)pass / total;
    }
}