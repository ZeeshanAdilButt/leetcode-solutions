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

    public ListNode ReverseEvenLengthGroups(ListNode head)
    {
        ListNode previousGroupEnd = head;
        ListNode lastNodeInCurrentGroup, nextGroupStart, currentNode, tempNext, originalFirstNodeInGroup = null;
        int targetGroupLength = 2;
        int nodesInCurrentGroup = 0;
        
        while (previousGroupEnd.next != null)
        {
            // Find the last node in current group
            lastNodeInCurrentGroup = previousGroupEnd;
            nodesInCurrentGroup = 0;
            
            // Count nodes in current group (up to targetGroupLength)
            for (int i = 0; i < targetGroupLength; i++)
            {
                if (lastNodeInCurrentGroup.next == null)
                    break;
                nodesInCurrentGroup++;
                lastNodeInCurrentGroup = lastNodeInCurrentGroup.next;
            }

            if (nodesInCurrentGroup % 2 != 0) // Odd length group - no reversal needed
            {
                previousGroupEnd = lastNodeInCurrentGroup;
            }
            else // Even length group - reverse it
            {
                nextGroupStart = lastNodeInCurrentGroup.next;
                currentNode = previousGroupEnd.next;
                
                // Reverse the nodes in the group
                for (int j = 0; j < nodesInCurrentGroup; j++)
                {
                    tempNext = currentNode.next;
                    currentNode.next = nextGroupStart;
                    nextGroupStart = currentNode;
                    currentNode = tempNext;
                }
                
                // Connect the reversed group
                originalFirstNodeInGroup = previousGroupEnd.next;
                previousGroupEnd.next = lastNodeInCurrentGroup;
                previousGroupEnd = originalFirstNodeInGroup;
            }
            
            targetGroupLength++;
        }
        
        return head;
    }
}