
public class Solution {
    public int MaxSum(int[] nums1, int[] nums2) {
        int mod = 1000000007;
        long ans = 0, sum1 = 0, sum2 = 0;
        int i = 0, j = 0;

        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] < nums2[j])
                sum1 += nums1[i++];
            else if (nums1[i] > nums2[j])
                sum2 += nums2[j++];
            else {
                ans += nums1[i] + Math.Max(sum1, sum2);
                i++;
                j++;
                sum1 = 0;
                sum2 = 0;
            }
        }

        while (i < nums1.Length)
            sum1 += nums1[i++];
        while (j < nums2.Length)
            sum2 += nums2[j++];

        ans += Math.Max(sum1, sum2);
        ans = ans % mod;
        return (int)ans;
    }
}
