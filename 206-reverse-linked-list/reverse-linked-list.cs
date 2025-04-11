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



    public ListNode ReverseList(ListNode head) {
                      
        ListNode prev = null;
        ListNode next = null;
        ListNode curr = head;
        
        while (curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        head = prev;
        
        return head;

        //recursive
        // if(head == null || head.next == null)
        //     return head;

        //  ListNode p = ReverseList(head.next);

        //  head.next.next = head;
        //  head.next = null;

        //  return p;
    }


}