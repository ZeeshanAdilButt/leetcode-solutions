public class Solution {
    public bool IsIsomorphic(string string1, string string2) {

         Dictionary<char, char> mapStr1Str2 = new Dictionary<char, char>();
        Dictionary<char, char> mapStr2Str1 = new Dictionary<char, char>();

        int i = 0, j = 0;

        while (i < string1.Length)
        {
            char char1 = string1[i++];
            char char2 = string2[j++];

            if (mapStr1Str2.ContainsKey(char1) && mapStr1Str2[char1] != char2)
                return false;

            if (mapStr2Str1.ContainsKey(char2) && mapStr2Str1[char2] != char1)
                return false;

            mapStr1Str2[char1] = char2;
            mapStr2Str1[char2] = char1;
        }

        return true;
    }
}