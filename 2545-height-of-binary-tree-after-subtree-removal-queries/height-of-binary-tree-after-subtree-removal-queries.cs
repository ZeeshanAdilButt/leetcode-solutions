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
    Dictionary<int, int> depth = new();
    Dictionary<int, int> height = new();
    Dictionary<int, List<int>> levelMaxHeights = new();

    public int[] TreeQueries(TreeNode root, int[] queries) {
        DFS(root, 0);
        List<int> result = new();

        foreach (var query in queries) {

            int d = depth[query];
            int h = height[query];
            
            var list = levelMaxHeights[d];

            if (list[0] != h) {
                result.Add(list[0] + d);
            } else if (list.Count > 1) {
                result.Add(list[1] + d);
            } else {
                result.Add(d - 1);
            }
        }

        return result.ToArray();
    }

    private int DFS(TreeNode node, int d) {
        if (node == null) return -1;

        depth[node.val] = d;

        int leftH = DFS(node.left, d + 1);
        int rightH = DFS(node.right, d + 1);
        int currH = 1 + Math.Max(leftH, rightH);
        height[node.val] = currH;

        if (!levelMaxHeights.ContainsKey(d))
            levelMaxHeights[d] = new List<int>();

        var list = levelMaxHeights[d];

        if (list.Count == 0) {
            list.Add(currH);
        } else if (list.Count == 1) {
            if (currH >= list[0])
                list.Insert(0, currH);
            else
                list.Add(currH);
        } else {
            if (currH > list[0]) {
                list[1] = list[0];
                list[0] = currH;
            } else if (currH > list[1]) {
                list[1] = currH;
            }
        }

        return currH;
    }
}