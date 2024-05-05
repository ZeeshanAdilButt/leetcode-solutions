public class Solution {
    public bool CheckString(string s) {
        
        int maxaindex =0;
        int minbindex = s.Length-1;
        
        
        
        for (int i = 0; i < s.Length;  i++){
            
            
            if(s[i] == 'a')
                maxaindex = i;
            
            
             if(s[i] == 'b')
                minbindex = i;
            
            
            if(maxaindex > minbindex  )
                return false;
                
                
            
        }
        
        
        return true;
        
    }
}