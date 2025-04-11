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

    public ListNode DeleteNodes(ListNode head, int m, int n)
    {
        ListNode current = head;
        ListNode prev = null;

        while (current != null)
        {
            int mCount = m;
            while (current != null && mCount > 0)
            {
                prev = current;

                current = current.next;
                mCount--;
            }

           

            int nCount = n;
            while (prev != null && prev.next != null && nCount > 0)
            {
                prev.next = prev.next.next;
                nCount--;
            }

            current = prev.next;

            // if (lastMNode != null)
            // {
            //     lastMNode.next = current;
            // }
        }

        return head;
    }
}