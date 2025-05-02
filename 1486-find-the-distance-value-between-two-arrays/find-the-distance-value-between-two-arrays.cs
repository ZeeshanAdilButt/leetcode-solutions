public class Solution {
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d) {

        // Array.Sort(arr1);
        Array.Sort(arr2);

        int count =0;

        //[4,5,8]
        // ^
        //[1,8,9,10]
        // ^

        int prevDistance = int.MinValue;

        for (int i = 0; i < arr1.Length; i++){

            int left = 0; int right = arr2.Length - 1;

            bool targetExist = true;

            //need to find any element which has smaller difference than d

            while (left <= right){

                int mid = left + (right -left) / 2;

                int difference = Math.Abs(arr1[i] - arr2[mid]);

                if (difference <= d)
                {

                    targetExist = false;
                    break;
                }
                else if ( arr2[mid] < arr1[i])
                {
                     left = mid +1;
                }
                else{

                   right = mid - 1;
                }
            }

            if(targetExist)
                count++;
        }

        return count;
        
    }
}