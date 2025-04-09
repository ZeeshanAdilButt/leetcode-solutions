public class Solution {

public string MinWindow(string s, string t)
{

    if (s== "" || t == "" || s.Length < t.Length)
        return "";


    //take count of both characters

    Dictionary<char, int> targetCount = new Dictionary<char, int>();
    Dictionary<char, int> sourceCount = new Dictionary<char, int>();

    int requiredMatches = 0; // let's say 3. 
    int foundMatches = 0; // we will only increment if source count of char is equals to targetCount of char

   

    foreach(char c in t){
        if(targetCount.ContainsKey(c)){
            targetCount[c]++;
        }
        else{

            requiredMatches++;
            targetCount.Add(c, 1);
        }
    }

    //min answer
    int foundleft =0;
    int foundright =0;
    int minWindowLength = Int32.MaxValue;

    int left =0;

    for(int right = 0; right < s.Length; right++){

        if(!targetCount.ContainsKey(s[right]))
            continue;

        if(sourceCount.ContainsKey(s[right])){
            sourceCount[s[right]]++;
        }
        else{            
            sourceCount.Add(s[right], 1);
        }

        if(targetCount[s[right]] == sourceCount[s[right]] )
            foundMatches++;

        if(foundMatches == requiredMatches){

            if( (right - left + 1) < minWindowLength)
            {

                foundleft =  left;
                foundright = right;
                minWindowLength = right - left  + 1;
            }

            while(foundMatches == requiredMatches){

                if(targetCount.ContainsKey(s[left]) && targetCount[s[left]] == sourceCount[s[left]])
                {
                    foundMatches--;
                    
                }

                if(sourceCount.ContainsKey(s[left]))
                    sourceCount[s[left]]--;
                
                left++;

                if(foundMatches == requiredMatches && ( right - left + 1 ) < minWindowLength )
                {
                    foundleft =  left;
                    foundright = right;
                    minWindowLength = right - left  + 1;
                }

            }    
        }

    }

   

   return minWindowLength == Int32.MaxValue ? "" : s.Substring(foundleft, minWindowLength);


    }


}