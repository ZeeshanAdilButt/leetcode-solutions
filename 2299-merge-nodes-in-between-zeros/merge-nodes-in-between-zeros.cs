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
    
    
//     public ListNode MergeNodes(ListNode head) {
//         // BASE CASE -> if we have a single zero, simply return null
//         if (head.next == null) return null;

//         // fetch sum from current 0 to next 0
//         ListNode ptr = head.next;
//         int sum = 0;
//         while (ptr.val != 0) {
//             sum += ptr.val;
//             ptr = ptr.next;
//         }

//         // assign sum on the first node between nodes having value 0.
//         head.next.val = sum;

//         // call and get the answer and connect the answer to next of head->next
//         head.next.next = MergeNodes(ptr);

//         // return head->next..=> new head
//         return head.next;
//     }
    
    public ListNode MergeNodes(ListNode head) {
        head = head.next;
        ListNode start = head;
        while (start != null) {
            ListNode end = start;   // Point to first node of current part for getting sum
            int sum = 0;
            while (end.val != 0) {
                sum += end.val;
                end = end.next;
            }
            start.val = sum;   // assign sum to first node between two 0
            start.next = end.next;   // make this connect to first node of next part
            start = start.next;    // go to next part
        }
        return head;
    }


}