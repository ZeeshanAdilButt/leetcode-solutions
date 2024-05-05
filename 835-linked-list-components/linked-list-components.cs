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
// public class Solution {
//     public int NumComponents(ListNode head, int[] nums) {
        
//     }
// }

public class Solution {
    public int NumComponents(ListNode head, int[] G) {
        HashSet<int> set = new HashSet<int>(G);
        int count = 0;
        bool connected = false;
        
        while (head != null) {
            if (set.Contains(head.val)) {
                if (!connected) {
                    count++;
                    connected = true;
                }
            } else {
                connected = false;
            }
            head = head.next;
        }
        
        return count;
    }
}
