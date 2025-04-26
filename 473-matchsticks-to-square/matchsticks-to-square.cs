public class Solution {
    public bool Makesquare(int[] matchsticks)
    {
        int totalLength = matchsticks.Sum();
        if (totalLength % 4 != 0)
            return false;

        int target = totalLength / 4;
        int[] sides = new int[4];

        Array.Sort(matchsticks);
        Array.Reverse(matchsticks); // largest sticks first to optimize

        return Dfs(matchsticks, sides, 0, target);
    }

    private bool Dfs(int[] matchsticks, int[] sides, int index, int target)
    {
        if (index == matchsticks.Length)
            return true;

        for (int i = 0; i < 4; i++)
        {
            if (sides[i] + matchsticks[index] <= target)
            {
                sides[i] += matchsticks[index];

                if (Dfs(matchsticks, sides, index + 1, target))
                    return true;

                sides[i] -= matchsticks[index]; // backtrack
            }

            // If this side is still zero after trying, no need to try same for other sides
            if (sides[i] == 0)
                break;
        }

        return false;
    }
}