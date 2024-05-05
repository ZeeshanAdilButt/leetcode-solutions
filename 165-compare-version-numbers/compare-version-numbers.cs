public class Solution {
    public int CompareVersion(string version1, string version2) 
    {
        var left = version1.Split(".");
        var leftCount = left.Count();

        var right = version2.Split(".");
        var rightCount = right.Count();

        var count = Math.Max(leftCount, rightCount);

        for(int i = 0; i < count; ++i)
        {
            var first = i < leftCount ? int.Parse(left[i]) : 0;
            var second = i < rightCount ? int.Parse(right[i]) : 0;

            if(first < second)
            {
                return -1;
            }
            if(first > second)
            {
                return 1;
            }
        }

        return 0;
    }
}