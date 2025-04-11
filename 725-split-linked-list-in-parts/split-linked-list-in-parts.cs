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
      public ListNode[] SplitListToParts(ListNode head, int k)
    {
        ListNode[] ans = new ListNode[k];

        int size = 0;
        ListNode current = head;
        while (current != null)
        {
            size++;
            current = current.next;
        }

        int split = size / k;

        int remaining = size % k;

        current = head;
        ListNode prev = null;

        for (int i = 0; i < k; i++)
        {
            ans[i] = current;

            int currentSize = split + (remaining > 0 ? 1 : 0);
            if (remaining > 0) remaining--;

            for (int j = 0; j < currentSize; j++)
            {
                prev = current;
                if (current != null)
                {
                    current = current.next;
                }
            }

            if (prev != null)
            {
                prev.next = null;
            }
        }

        return ans;
    }
}