public class Solution {
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        
        Array.Sort(nums);
        
        Backtrack(list, new List<int>(), nums, 0);
        
        return list;
    }

    private void Backtrack(IList<IList<int>> list, List<int> tempList, int[] nums, int start)
    {
        list.Add(new List<int>(tempList));
        for (int i = start; i < nums.Length; i++)
        {
            tempList.Add(nums[i]);
            Backtrack(list, tempList, nums, i + 1);
            tempList.RemoveAt(tempList.Count - 1);
        }
    }
}