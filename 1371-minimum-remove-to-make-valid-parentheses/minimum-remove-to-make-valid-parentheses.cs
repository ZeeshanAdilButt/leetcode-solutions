public class Solution {
    public string MinRemoveToMakeValid(string s) {
        char[] arr = s.ToCharArray();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == '(') {
                stack.Push(i);
            } else if (arr[i] == ')') {
                if (stack.Count > 0) {
                    stack.Pop();
                } else {
                    arr[i] = '\0';
                }
            }
        }

        while (stack.Count > 0) {
            arr[stack.Pop()] = '\0';
        }

        StringBuilder result = new StringBuilder();
        foreach (char c in arr) {
            if (c != '\0') {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}

// public class Solution {
//     public string MinRemoveToMakeValid(string s) {

//         int openCnt = 0, closeCnt = 0;

//         foreach (char c in s) {
//             if (c == ')') closeCnt++;
//         }

//         StringBuilder res = new StringBuilder();

//         foreach (char c in s) {

//             if (c == '(') {
                
//                 if (openCnt == closeCnt) continue;
//                 openCnt++;

//             } 
//             else if (c == ')') {
            
//                 closeCnt--;
//                 if (openCnt == 0) continue;
//                 openCnt--;

//             }
            
//             res.Append(c);
//         }

//         return res.ToString();
//     }
// }