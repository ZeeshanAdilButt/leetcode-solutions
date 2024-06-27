/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    private int matchingSubtreeCount = 0; // Initialize the count of subtrees with matching averages.

    // A Depth-First Search (DFS) function that returns an array of two values:
    // - The sum of values within the current subtree.
    // - The number of nodes within the current subtree.
    private int[] CalculateSubtreeValues(TreeNode currentNode) {
        if (currentNode == null)
            return new int[] { 0, 0 }; // Base case: Return 0 for both sum and number of nodes if the node is null.

        // Recursively calculate values for the left and right subtrees.
        int[] leftSubtree = CalculateSubtreeValues(currentNode.left);
        int[] rightSubtree = CalculateSubtreeValues(currentNode.right);

        // Calculate the sum of values and the number of nodes in the current subtree.
        int sumOfValues = leftSubtree[0] + rightSubtree[0] + currentNode.val;
        int numberOfNodes = leftSubtree[1] + rightSubtree[1] + 1;

        // Check if the current node's value matches the average of its subtree.
        if (sumOfValues / numberOfNodes == currentNode.val)
            matchingSubtreeCount++;

        return new int[] { sumOfValues, numberOfNodes }; // Return the calculated values for the current subtree.
    }

    public int AverageOfSubtree(TreeNode root) {
        CalculateSubtreeValues(root); // Start the DFS from the root node.
        return matchingSubtreeCount; 
    }
}
