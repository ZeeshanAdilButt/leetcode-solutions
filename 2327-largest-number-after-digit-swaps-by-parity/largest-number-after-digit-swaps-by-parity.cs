public class Solution {
 public int LargestInteger(int num) {
        
        var evens = new List<int>();
        var odds = new List<int>();
        var order = new List<bool>();
        
        while(num > 0){
            int digit = num % 10;
            num /= 10;
            if(1 == (digit & 1)){
                odds.Add(digit);
                order.Add(true);
            }else{
                evens.Add(digit);
                order.Add(false);
            }
        }
        
        odds.Sort((a, b) => b - a);
        evens.Sort((a, b) => b - a);
        
        int oddIndex = 0;
        int evenIndex = 0;
        
        var answer = 0;
        for(int i = order.Count - 1; i >= 0; i--){
            answer *= 10;
            if(order[i]){
                answer += odds[oddIndex++];
            }else{
                answer += evens[evenIndex++];
            }
        }
        return answer;
    }
}