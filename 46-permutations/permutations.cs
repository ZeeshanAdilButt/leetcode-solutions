public class Solution {
   public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> list = new List<IList<int>>();
        Backtrack(list, new List<int>(), nums);
        return list;
    }

    private void Backtrack(IList<IList<int>> list, List<int> tempList, int[] nums)
    {
        if (tempList.Count == nums.Length)
        {
            list.Add(new List<int>(tempList));
        }
        else
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (tempList.Contains(nums[i])) continue; // element already exists, skip
                tempList.Add(nums[i]);
                Backtrack(list, tempList, nums);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}