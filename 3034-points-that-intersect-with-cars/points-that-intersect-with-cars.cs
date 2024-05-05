public class Solution {
    public int NumberOfPoints(IList<IList<int>> nums) {
         HashSet<int> result = new HashSet<int>();
        
    foreach (var pair in nums) {
        
        int first = pair[0];
        int last = pair[1];
        
        for (int i = first; i <= last; i++) {
            result.Add(i);
        }
    }
    
    return result.Count;
    }
    


}