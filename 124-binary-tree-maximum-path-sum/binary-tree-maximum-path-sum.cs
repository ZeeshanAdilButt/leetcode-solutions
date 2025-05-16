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
      int maxSum = int.MinValue;
    
    public int MaxPathSum(TreeNode root) {
        DFS(root);
        return maxSum;
    }
    
    int DFS(TreeNode node) {
        
        if (node == null) return 0;

        int left = Math.Max(0, DFS(node.left));
        int right = Math.Max(0, DFS(node.right));

        maxSum = Math.Max(maxSum, left + right + node.val);
        
        return Math.Max(left, right) + node.val;
    }
}