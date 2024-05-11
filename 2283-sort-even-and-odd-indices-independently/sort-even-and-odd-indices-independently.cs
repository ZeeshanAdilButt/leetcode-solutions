public class Solution
{
    public int[] SortEvenOdd(int[] nums)
    {
        PriorityQueue<int, int> odd = new();
        PriorityQueue<int, int> even = new();

        for (int index = 0; index < nums.Length; index++)
        {
            int num = nums[index];
            if (index % 2 == 0)
            {
                even.Enqueue(num, num);
            }
            else
            {
                odd.Enqueue(num, -num);
            }
        }

        for (int index = 0; index < nums.Length; index++)
        {
            nums[index] = index % 2 == 0 ? even.Dequeue() : odd.Dequeue();
        }

        return nums;
    }
}