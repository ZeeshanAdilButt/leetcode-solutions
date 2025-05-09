public class Solution {

    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        
        Dictionary<string, int> frequencies = new Dictionary<string, int>();

        foreach (var row in matrix)
        {
            string pattern = "";

            for (int col = 0; col < row.Length; col++)
            {
                if (row[0] == row[col])
                    pattern += "T";
                else
                    pattern += "F";
            }

            if (frequencies.ContainsKey(pattern))
                frequencies[pattern]++;
            else
                frequencies[pattern] = 1;
        }

        int res = 0;

        foreach (var entry in frequencies)
            res = Math.Max(entry.Value, res);

        return res;
    }

}