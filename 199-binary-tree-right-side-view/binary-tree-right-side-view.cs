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

        List<int> res = new List<int>();
        
        if (root == null) return res;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count > 0) {
            int qLen = q.Count;
            TreeNode rightSide = null;

            for (int i = 0; i < qLen; i++) {
                TreeNode node = q.Dequeue();
                rightSide = node;

                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }

            res.Add(rightSide.val); // No need to check for null
        }

        return res;
    }
}

