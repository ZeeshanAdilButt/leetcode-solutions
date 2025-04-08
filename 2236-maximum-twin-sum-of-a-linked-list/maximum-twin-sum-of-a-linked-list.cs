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
    public int PairSum(ListNode head) {
        
        ListNode slow = head;
        ListNode fast = head;
        
        ListNode prev = null;
        ListNode next = null;
        
        while(fast != null && fast.next != null){
            
            fast = fast.next.next;

            next = slow.next; // + reverse
            slow.next = prev;
            prev = slow;
            slow = next;
        
           
        }
        
        // save the slow.next as the comparer to head
        ListNode slow2 = next;
        
        int sum = Int32.MinValue;
        
        while(slow2 != null){
            
            sum = Math.Max(sum, prev.val + slow2.val);
            
            prev=prev.next;
            slow2= slow2.next;
        }
        
        return sum;
    }
}