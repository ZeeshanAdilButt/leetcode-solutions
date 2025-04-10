public class Solution {

    public int[][] IntervalIntersection(int[][] intervalLista, int[][] intervalListb)
    {
        List<int[]> intersections = new List<int[]>();
        int i = 0, j = 0;

        while (i < intervalLista.Length && j < intervalListb.Length)
        {
            int start = Math.Max(intervalLista[i][0], intervalListb[j][0]);
            int end = Math.Min(intervalLista[i][1], intervalListb[j][1]);

            if (start <= end)
                intersections.Add(new int[] { start, end });
            if (intervalLista[i][1] < intervalListb[j][1])
                i += 1;
            else
                j += 1;
        }

        return intersections.ToArray();
    }
   
}