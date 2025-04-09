public class Solution {
   public string MinWindow(string s, string t)
{
	if (string.IsNullOrEmpty(t))
	{
	return "";
	}

    Dictionary<char, int> reqCount = new Dictionary<char, int>();
    Dictionary<char, int> window = new Dictionary<char, int>();

    foreach (char c in t)
    {
        if (!reqCount.ContainsKey(c))
            reqCount[c] = 0;
        reqCount[c]++;
    }

    int current = 0;
    int required = reqCount.Count;

    int[] res = { -1, -1 };
    int resLen = int.MaxValue;

    int left = 0;
    for (int right = 0; right < s.Length; right++)
    {
        char c = s[right];

        if (reqCount.ContainsKey(c))
        {
            if (!window.ContainsKey(c))
                window[c] = 0;
            window[c]++;

            if (window[c] == reqCount[c])
            {
                current++;
            }
        }

        while (current == required)
        {
            if ((right - left + 1) < resLen)
            {
                res[0] = left;
                res[1] = right;
                resLen = (right - left + 1);
            }

            char leftChar = s[left];
            if (reqCount.ContainsKey(leftChar))
            {
                window[leftChar]--;
                if (window[leftChar] < reqCount[leftChar])
                {
                    current--;
                }
            }
            left++;
        }
    }

    int leftIndex = res[0];
    return resLen != int.MaxValue ? s.Substring(leftIndex, resLen) : "";
}


}