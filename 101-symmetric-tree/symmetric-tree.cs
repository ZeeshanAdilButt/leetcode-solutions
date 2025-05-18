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
   
   
    public bool IsSymmetric(TreeNode root) {
        return dfs(root.left, root.right);
    }

    private bool dfs(TreeNode left, TreeNode right) {
        
        if (left == null && right == null) {
            return true;
        }
        if (left == null || right == null) {
            return false;
        }
        return left.val == right.val && 
               dfs(left.left, right.right) && 
               dfs(left.right, right.left);
    }
}