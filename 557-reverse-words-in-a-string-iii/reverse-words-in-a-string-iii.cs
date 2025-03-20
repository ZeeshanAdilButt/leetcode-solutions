public class Solution {
    public string ReverseWords(string s) {

        int left = 0;
        int right = 0;

        s = s.Trim();

        char[] charArray = s.ToCharArray();

        for(int i = 0; i < charArray.Length; i++){

                if(charArray[i] ==' ' || i == charArray.Length -1 ){


                    right = i -1;

                    if( i == charArray.Length -1)
                    right ++;

                    while(left < right){

                        char temp = charArray[left];
                        charArray[left] = charArray[right];
                        charArray[right] = temp;

                        left++;
                        right--;

                    }

                    left = i +1;
                    right  = i +1 ;
                }


        }

        return new string(charArray);
        
    }
}