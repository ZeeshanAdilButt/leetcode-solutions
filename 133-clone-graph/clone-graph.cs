/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
     public Node CloneGraph(Node node) {

        if (node == null) 
            return null;

        //old to new dict
        var visited = new Dictionary<Node, Node>();

        return DFS(node, visited);
    }
    
    private Node DFS(Node node, Dictionary<Node, Node> visited) {

        if (visited.ContainsKey(node)) return visited[node];
        
        var newNode = new Node { val = node.val, neighbors = new List<Node>() };
        
        visited.Add(node, newNode);
        
        foreach (var neighbor in node.neighbors) {
            newNode.neighbors.Add(DFS(neighbor, visited));
        }
        
        return newNode;
    }
}
