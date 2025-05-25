public class FreqStack {

   // Declare frequency and group dictionaries and maxFrequency integer
    Dictionary<int, int> frequency;
    Dictionary<int, Stack<int>> group;
    int maxFrequency;

    // Constructor to initialize the FreqStack object
    public FreqStack()
    {
        frequency = new Dictionary<int, int>();
        group = new Dictionary<int, Stack<int>>();
        maxFrequency = 0;
    }

    // Push function to push the value into the FreqStack
    public void Push(int value)
    {   
        int freq = frequency.GetValueOrDefault(value, 0) + 1;

        frequency[value] = freq;       
        
        if (freq > maxFrequency)
            maxFrequency = freq;
        
        if (!group.ContainsKey(freq))
            group[freq] = new Stack<int>();
        
        group[freq].Push(value);
    }

    // Pop function to pop the value from the FreqStack
    public int Pop()
    {
        int show = 0;
        if (maxFrequency > 0)
        {            
            show = group[maxFrequency].Pop();
            
            frequency[show]--;

            if (group[maxFrequency].Count == 0)
                maxFrequency--;

            return show;    
        }
        
            return -1;
        
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */