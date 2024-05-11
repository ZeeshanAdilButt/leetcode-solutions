public class Solution {
    public int[] DistributeCandies(int candies, int num_people) {
        
        int[] people = new int[num_people];
        int give = 0;
        
        while (candies > 0) {
            people[give % num_people] += Math.Min(candies, give + 1);
            give++;
            candies -= give;
        }
        
        return people;
        
    }
}