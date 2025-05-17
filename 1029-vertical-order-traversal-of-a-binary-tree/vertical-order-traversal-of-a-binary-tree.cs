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

   public IList<IList<int>> VerticalTraversal(TreeNode root) {
      
       var result = new List<IList<int>>();
        if (root == null) return result;

        // (col, row, val)
        var list = new List<(int col, int row, int val)>();
        
        var queue = new Queue<(TreeNode node, int col, int row)>();

        queue.Enqueue((root, 0, 0));

        while (queue.Count > 0) {

            var (node, col, row) = queue.Dequeue();
            
            list.Add((col, row, node.val));

            if (node.left != null) queue.Enqueue((node.left, col - 1, row + 1));
            if (node.right != null) queue.Enqueue((node.right, col + 1, row + 1));
        }

        // Sort by col, then row, then val
        list.Sort((a, b) => (a.col, a.row, a.val).CompareTo((b.col, b.row, b.val)));

     
        int? prevCol = null;
        List<int> current = null;

        foreach (var (col, row, val) in list) {
            if (prevCol == null || col != prevCol) {
                current = new List<int>();
                result.Add(current);
                prevCol = col;
            }
            current.Add(val);
        }

        return result;
    }
}