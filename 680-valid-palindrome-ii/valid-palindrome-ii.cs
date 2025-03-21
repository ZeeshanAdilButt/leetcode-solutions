public class Solution {
    public bool ValidPalindrome(string s) {

        int moves = 1;
        int left = 0;
        int right = s.Length-1;

         while (left < right){
            
            if(s[left] != s[right])
            {
                moves--;

                if(moves < 0)
                return false;

                bool l = isPalindrome(s, left + 1, right);
                bool r = isPalindrome(s, left, right - 1 );

                return l || r; 
            }

            left++;
            right--;
            
        }        
    
        return true;

    }

    public bool isPalindrome(string s, int left, int right)
    {
        while (left < right){                
            if(s[left] != s[right]){
                return false;            
            }

            left++;
            right--;            
        }

        return true;
    }
}