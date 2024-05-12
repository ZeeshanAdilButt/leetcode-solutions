public class Solution {
    public int MinSpeedOnTime(int[] dist, double hour) {
        int speed =-1;
        int left = 1;
        int right = 10000000;

        while(left <= right) {
            int mid = (left + right) / 2;
            double time = helper(dist, mid);
            if(time <= hour) {
                speed = mid;
                right = mid-1;
            } else {
                left = mid+1;
            }
        }

        return speed;
    }

    private double helper(int[] dist, int speed) {
        double time = 0;
        for(int i=0; i<dist.Length; i++) {
            double t = (double)dist[i] / speed;
            //because the time taken by last train need not be converted into Integer.
            time += (i == dist.Length-1 ? t : Math.Ceiling(t));
        }

        return time;
    }
}