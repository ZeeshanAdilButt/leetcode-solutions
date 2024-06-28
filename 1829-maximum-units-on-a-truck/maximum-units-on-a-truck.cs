public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) {
        int[] count = new int[1001]; // Array to count units
        foreach (int[] box in boxTypes) {
            count[box[1]] += box[0]; // Accumulate units per box type
        }
        
        int boxes = 0;
        for (int units = 1000; units > 0; --units) {
            if (count[units] > 0) {
                int fitIn = Math.Min(count[units], truckSize); // Determine how many boxes can fit in the truck
                boxes += units * fitIn; // Add units to total
                truckSize -= fitIn; // Update remaining truck capacity
                if (truckSize == 0) {
                    return boxes; // Return total units if truck is full
                }
            }
        }
        
        return boxes; // Return total units
    }
}
