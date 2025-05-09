/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */

 public class NestedIterator {
    private List<int> flatList;
    private int index;

    public NestedIterator(IList<NestedInteger> nestedList) {
        flatList = new List<int>();
        index = 0;
        Flatten(nestedList);
    }

    private void Flatten(IList<NestedInteger> nestedList) {
        foreach (var ni in nestedList) {
            if (ni.IsInteger()) {
                flatList.Add(ni.GetInteger());
            } else {
                Flatten(ni.GetList());
            }
        }
    }

    public bool HasNext() {
        return index < flatList.Count;
    }

    public int Next() {
        return flatList[index++];
    }
}



// public class NestedIterator {
    
//     private Stack<NestedInteger> stack;

//     public NestedIterator(IList<NestedInteger> nestedList) {
//         stack = new Stack<NestedInteger>();
    
//         // Push in reverse so the first element is on top
//         for (int i = nestedList.Count - 1; i >= 0; i--) {
//             stack.Push(nestedList[i]);
//         }

//     }

//     public bool HasNext() {

//         while (stack.Count > 0) {

//             var top = stack.Peek();

//             if (top.IsInteger()) {
//                 return true;
//             }

//             // It's a list, unpack it
//             stack.Pop();

//             var list = top.GetList();
            
//             for (int i = list.Count - 1; i >= 0; i--) {
//                 stack.Push(list[i]);
//             }
//         }

//         return false;
//     }

//     public int Next() {
//         return stack.Pop().GetInteger();
//     }
// }


/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */