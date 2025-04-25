public class Solution {
    public bool Exist(char[][] board, string word) {
        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[0].Length; j++) {
                if (board[i][j] == word[0] && DFS(board, i, j, word, 0)) {
                    return true;
                }
            }
        }
        return false;
    }
    
    private bool DFS(char[][] board, int i, int j, string word, int k) {
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[k]) {
            return false;
        }
        
        if (k == word.Length - 1) {
            return true;
        }
        
        char temp = board[i][j];
        board[i][j] = ' ';
        
        bool found = DFS(board, i + 1, j, word, k + 1) || 
                     DFS(board, i - 1, j, word, k + 1) ||
                     DFS(board, i, j + 1, word, k + 1) ||
                     DFS(board, i, j - 1, word, k + 1);
        
        board[i][j] = temp;
        
        return found;
    }
}
