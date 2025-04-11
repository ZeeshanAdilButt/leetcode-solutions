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
      public ListNode RemoveElements(ListNode head, int val) {

    ListNode dummy = new ListNode(0);

        dummy.next = head;

        ListNode curr = dummy;

        while (curr != null && curr.next != null)
        {
            if (curr.next.val == val)
            {
                curr.next = curr.next.next;
            }
            else
            {
                // prev = curr;
                curr = curr.next;
            }
        }

        return dummy.next;


// recursive
        // if (head == null) {
        //     return null; // Base case: If the list is empty, return null.
        // }
        
        // // Recursively remove elements from the rest of the list.
        // head.next = RemoveElements(head.next, val);
        
        // // Check if the current node should be removed.
        // if (head.val == val) {
        //     return head.next; // Skip the current node by returning the next node.
        // }
        
        // return head; // Keep the current node in the list.
    }


}