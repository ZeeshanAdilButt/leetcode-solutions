public class Solution {
       public long MaximumHappinessSum(int[] happiness, int k) {
        var pq = new PriorityQueue<int, int>(); 
        
        foreach (var hap in happiness)
        {
            pq.Enqueue(hap, -hap);
        }
        
        long result = 0; 
        long count = 0;
        while ( k > 0  && pq.Count > 0)
        {
            var curr = pq.Dequeue();
            if ( (curr - count)   > 0)  // making sure the queue element is not negative after decrementing the counter
            {
                 result +=  (curr  - count);
                 count++;  // this would be total decrement we would have to do, 
            }
            k--; 
            
        }
        
        return result;
    }
}