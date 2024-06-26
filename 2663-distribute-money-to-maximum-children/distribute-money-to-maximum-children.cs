public class Solution {
    public int DistMoney(int money, int children) {
        int ans = 0;
        if (money < children) return -1;
        if (money > children * 8) return children - 1;
        
        while (money > 0 && money - 8 >= children - 1) {
            ans++;
            money -= 8;
            children--;
        }
        
        if (money == 4 && children == 1) ans--;
        
        return ans;
    }
}
