/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */


public class Solution {
    private ListNode head;
    private Random rand;

    public Solution(ListNode head) {
        this.head = head;
        this.rand = new Random();
    }

    public int GetRandom() {
        ListNode curr = head;
        int result = curr.val;
        int count = 1;

        while (curr != null) {
            if (rand.Next(count) == 0)
                result = curr.val;
            curr = curr.next;
            count++;
        }

        return result;
    }
}




/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */