public class Solution {
    public bool CanBeValid(string s, string locked) {
        int n = s.Length;
        if (n % 2 != 0) return false;
        
        int balance = 0;
        
        // First check balance from left to right for opening '(' brackets
        for (int i = 0; i < n; i++) {
            // If either char is '(' or it is unlocked, we can increment balance
            if (locked[i] == '0' || s[i] == '(') balance++;
            else balance--;  // otherwise decrement balance, since it is ')' and also locked
            
            // Since balance is negative, we have more ')'.
            // And there is no unlocked char available, so it is an invalid string for sure
            if (balance < 0) return false;
        }
        
        // Reset balance 
        balance = 0;
        
        // Then also check balance from right to left for closing ')' brackets
        for (int i = n - 1; i >= 0; i--) {
            // If either char is ')' or it is unlocked, we can increment balance
            if (locked[i] == '0' || s[i] == ')') balance++;
            else balance--;  // otherwise decrement balance, since it is '(' and also locked
            
            // Since balance is negative, we have more '('.
            // And there is no unlocked char available, so it is an invalid string for sure
            if (balance < 0) return false;
        }
        
        return true;
    }
}
