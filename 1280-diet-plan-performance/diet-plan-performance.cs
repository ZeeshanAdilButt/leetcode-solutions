public class Solution {
    public int DietPlanPerformance(int[] calories, int k, int lower, int upper) {

        int totalGained = 0;

        int left = 0;

        int currentSum = 0;

        for (int right = 0; right < calories.Length; right++){

            currentSum += calories[right];

            if(right - left + 1 == k){

               if(currentSum < lower) {
                
               totalGained -=1;
               }
               else if(currentSum > upper)  {

                totalGained +=1;
               }

            currentSum -= calories[left];

            left++;
            }

        }

        return totalGained;
        
    }
}