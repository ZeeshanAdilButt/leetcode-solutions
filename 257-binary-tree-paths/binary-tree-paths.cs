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
    public IList<string> BinaryTreePaths(TreeNode root) {
        IList<string> paths = new List<string>();
        if (root == null) {
            return paths;
        }
        DFS(root, "", paths);
        return paths;
    }
    
    private void DFS(TreeNode node, string path, IList<string> paths) {
        
        if (node.left == null && node.right == null) {
            paths.Add(path + node.val);
            return;
        }
        if (node.left != null) {
            DFS(node.left, path + node.val + "->", paths);
        }
        if (node.right != null) {
            DFS(node.right, path + node.val + "->", paths);
        }
    }
}
