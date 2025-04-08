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
    // public bool IsPalindrome(ListNode head) {
    //     List<int> arr = new List<int>();
    //     ListNode cur = head;
    //     while (cur != null) {
    //         arr.Add(cur.val);
    //         cur = cur.next;
    //     }

    //     int l = 0, r = arr.Count - 1;
    //     while (l < r) {
    //         if (arr[l] != arr[r]) {
    //             return false;
    //         }
    //         l++;
    //         r--;
    //     }

    //     return true;
    // }

    // Function to check if a linked list is a palindrome
    public bool IsPalindrome(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        
        while (fast != null && fast.next != null)
        {            
            slow = slow.next;           
            fast = fast.next.next;
        }
        
        ListNode revertData = ReverseLinkedList(slow);     
        bool check = CompareTwoHalves(head, revertData);
        // LinkedListReversal.ReverseLinkedList(revertData);

        return check;
    }

    // Function to compare two halves of a linked list
    public static bool CompareTwoHalves(ListNode firstHalf, ListNode secondHalf)
    {        
        while (firstHalf != null && secondHalf != null)
        {
            if (firstHalf.val != secondHalf.val)
            {
                return false;
            }
            else
            {
                firstHalf = firstHalf.next;
                secondHalf = secondHalf.next;
            }
        }
        return true;
    }

     public static ListNode ReverseLinkedList(ListNode slowPtr)
    {
        ListNode prev = null;
        ListNode next = null;
        ListNode curr = slowPtr;

        while (curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }
}