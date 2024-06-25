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
    public IList<int> RightSideView(TreeNode root) {
        List<int> result = new List<int>();
        RightView(root, result, 0);
        return result;
    }
    
    public void RightView(TreeNode curr, List<int> result, int currDepth) {
        if (curr == null) {
            return;
        }
        if (currDepth == result.Count) {
            result.Add(curr.val);
        }
        
        RightView(curr.right, result, currDepth + 1);
        RightView(curr.left, result, currDepth + 1);
    }
}

