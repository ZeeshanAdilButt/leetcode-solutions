public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }

        UnionFind ds = new UnionFind(nums);

        foreach (int num in nums)
        {
            if (ds.parent.ContainsKey(num + 1))
            {
                ds.Union(num, num + 1);
            }
        }

        return ds.maxLength;
    }

    public class UnionFind
    {
        public Dictionary<int, int> parent;
        public Dictionary<int, int> size;
        public int maxLength;

        public UnionFind(int[] nums)
        {
            parent = new Dictionary<int, int>();
            size = new Dictionary<int, int>();
            maxLength = 1;

            foreach (int num in nums)
            {
                if (!parent.ContainsKey(num)) // handle duplicates
                {
                    parent[num] = num;
                    size[num] = 1;
                }
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX == rootY) return;

            parent[rootX] = rootY;
            size[rootY] += size[rootX];
            maxLength = Math.Max(maxLength, size[rootY]);
        }
    }
}



// public class Solution {
//     public int LongestConsecutive(int[] nums) {
        
//         if (nums == null || nums.Length == 0) return 0;
        
//         HashSet<int> set = new HashSet<int>();
//         foreach (int num in nums) 
//         set.Add(num);
        
//         int maxLength = 0;

//         for (int i = 0; i < nums.Length; i++) {

//             int currentNum = nums[i];
            
//             if (!set.Contains(currentNum-1)) {
            
//                 int currentLength = 1;
//                 int nextNum = currentNum + 1;
            
//                 while (set.Contains(nextNum)) {
//                     currentLength++;
//                     nextNum++;
//                 }
            
//                 maxLength = Math.Max(maxLength, currentLength);
//             }
//         }
        
//         return maxLength;
        
//     }
// }