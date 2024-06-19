
public class Solution {
    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity) {
        int numberOfBuses = buses.Length;
        int numberOfPassengers = passengers.Length;
       
        int passengerIndex = 0;
        int latestTime = -1;
        
        HashSet<int> occupiedTimes = new HashSet<int>();

        Array.Sort(buses);
        Array.Sort(passengers);

        for (int busIndex = 0; busIndex < numberOfBuses; busIndex++) {
            
            int currentCapacity = 0;

            while (currentCapacity < capacity && passengerIndex < numberOfPassengers && passengers[passengerIndex] <= buses[busIndex]) 
            
            {
                if (!occupiedTimes.Contains(passengers[passengerIndex] - 1)) {
                    latestTime = passengers[passengerIndex] - 1;
                }
                occupiedTimes.Add(passengers[passengerIndex]);
                currentCapacity++;
                passengerIndex++;
            }

            if (currentCapacity < capacity && !occupiedTimes.Contains(buses[busIndex])) {
                latestTime = buses[busIndex];
            }
        }

        return latestTime;
    }
}