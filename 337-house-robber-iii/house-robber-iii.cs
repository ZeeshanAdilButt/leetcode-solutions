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
   private readonly Dictionary<TreeNode, int> _memo = new();

    public int Rob(TreeNode root) => Dfs(root);

    private int Dfs(TreeNode node)
    {
        if (node == null) return 0;                       // null ⇒ 0

        if (_memo.TryGetValue(node, out var cached))      // memoised?
            return cached;

        /* Choose the node: skip its children, add grandchildren */
        int take = node.val;
        if (node.left != null)
            take += Dfs(node.left.left) + Dfs(node.left.right);
        if (node.right != null)
            take += Dfs(node.right.left) + Dfs(node.right.right);

        /* Skip the node: consider its children */
        int skip = Dfs(node.left) + Dfs(node.right);

        int res = System.Math.Max(take, skip);
        _memo[node] = res;                                // cache result
        return res;
    }
}