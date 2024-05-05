public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        
        Array.Sort(people);
        
        
        int i = 0, j = people.Length - 1;
        
        int boats = 0;
        
        while (i <= j) {
            
            int sum = people[i] + people[j];
            
            if (sum <= limit) {
                ++i;
            }
            --j;
            ++boats;
        }
        
        return boats;
    }
}
