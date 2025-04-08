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
    public ListNode[] SplitCircularLinkedList(ListNode list) {

        ListNode slow = list;
        ListNode fast = list;

        // ListNode prev= null;
        // ListNode next= null;

        while (fast.next != list && fast.next.next != list) 
        {

            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode head1 = list;
        ListNode head2= slow.next;

        slow.next = head1;

        ListNode current = head2;

        while(current.next != list){

            current = current.next;
        }

        current.next = head2;

        

        return new ListNode[] { head1, head2 };
        
    }

    
}