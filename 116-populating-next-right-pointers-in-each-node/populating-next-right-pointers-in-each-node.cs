/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {

    //DFS
    public Node Connect(Node root) {
        if (root == null) return root;

        if (root.left != null) {
            root.left.next = root.right;
            if (root.next != null) {
                root.right.next = root.next.left;
            }

            Connect(root.left);
            Connect(root.right);
        }

        return root;
    }

    // public Node Connect(Node root) {
    //      if (root == null) return null;

    //     Queue<Node> q = new Queue<Node>();
    //     q.Enqueue(root);

    //     while (q.Count > 0) {

    //         int levelSize = q.Count;
            
    //         for (int i = 0; i < levelSize; i++) {
    //             Node node = q.Dequeue();
            
    //             if (i < levelSize - 1) {
    //                 node.next = q.Peek();
    //             }

    //             if (node.left != null) q.Enqueue(node.left);
    //             if (node.right != null) q.Enqueue(node.right);
    //         }
    //     }

    //     return root;
    // }
}