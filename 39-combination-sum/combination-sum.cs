public class Solution {

    List<IList<int>> res;

    public IList<IList<int>> CombinationSum(int[] nums, int target) {
        res = new List<IList<int>>();

        Array.Sort(nums);
        dfs(0, new List<int>(), 0, nums, target);
        return res;
    }

    private void dfs(int i, List<int> cur, int total, int[] nums, int target) {
        if (total == target) {
            res.Add(new List<int>(cur));
            return;
        }
        
        for (int j = i; j < nums.Length; j++) {
            if (total + nums[j] > target) {
                return;
            }
            cur.Add(nums[j]);
            dfs(j, cur, total + nums[j], nums, target);
            cur.RemoveAt(cur.Count - 1);
        }
    }

    // public IList<IList<int>> CombinationSum(int[] candidates, int target) {

    //     var resultArray = new List<IList<int>>();

    //     DFS(0, new List<int>(), target, candidates, resultArray);

    //     return resultArray;
        
    // }

    // public void DFS(int index, List<int> currArray,int target, int[] candidates, IList<IList<int>> resultArray){

    //    if (target == currArray.Sum())
    //     {
    //         resultArray.Add(new List<int>(currArray));
    //         return;
    //     }
            
    //     if(index>=candidates.Length ||  currArray.Sum() > target)
    //       return;

    //     currArray.Add(candidates[index]);
    //     DFS(index, currArray, target , candidates, resultArray);

    //     currArray.RemoveAt(currArray.Count()-1);
    //     DFS(index + 1, currArray, target , candidates, resultArray);

    // }
}