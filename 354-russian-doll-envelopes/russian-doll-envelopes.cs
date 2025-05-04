using System;
using System.Collections.Generic;

public class Solution
{
    private int FindPosition(List<int> lis, int height)
    {
        int left = 0, right = lis.Count - 1;
    
        while (left <= right)
        {
            int mid = (left + right) / 2;
            
            if (lis[mid] < height)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
    
        return left;
    }

    public int MaxEnvelopes(int[][] envelopes)
    {
        Array.Sort(envelopes, (a, b) => a[0] == b[0] ? b[1].CompareTo(a[1]) : a[0].CompareTo(b[0]));
        List<int> lis = new List<int>();
  
        foreach (var envelope in envelopes)
        {
            int width = envelope[0], height = envelope[1];
            int position = FindPosition(lis, height);
      
            if (position == lis.Count)
            {
                lis.Add(height);
            }
            else
            {
                lis[position] = height;
            }
        }
  
        return lis.Count;
    }


}