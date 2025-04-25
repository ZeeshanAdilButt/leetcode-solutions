public class Solution {
   
     public IList<string> ReadBinaryWatch(int ledsOn)
    {
        var result = new List<string>();
        BinaryWatchRec(0, 0, 0, ledsOn, result);
        return result;
    }

    private static void BinaryWatchRec(int position, int hours, int minutes, int ledsLeft, List<string> result)
    {
        if (ledsLeft == 0)
        {
            if (hours < 12 && minutes < 60)
            {
                result.Add($"{hours}:{minutes:D2}");
            }
            return;
        }

        // 10 total LEDs
        for (int i = position; i < 10; i++)
        {
            int newHours = hours;
            int newMinutes = minutes;

            //4 LEDs on the top to represent the hours
            if (i < 4)
                newHours += 1 << i;  // LED i controls hours, same as 2 power x (here x is 1) > means total number of hours
            // 6 bottom LEDS    
            else
                // newMinutes += 1 << (i - 4); // LED i controls minutes
                newMinutes += (int)Math.Pow(2,i-4);  // LED i controls minutes


            BinaryWatchRec(i + 1, newHours, newMinutes, ledsLeft - 1, result);
        }
    }

  
}