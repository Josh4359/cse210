using System;
using static Utility;

/*
~~Showing Creativity and Exceeding Requirements~~

In addition to the base requirements for this assignment, I also added the following:
- In the reflection and listing activities, after a random prompt is selected, it cannot be chosen again until all other prompts have been used and the list resets
- Lots of little things to make the program as clean and well-organized as I could make it
*/

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new();
        ReflectionActivity reflectionActivity = new();
        ListingActivity listingActivity = new();

        while (true)
        {
            Clear();

            Print("Menu Options:");
            Print("  1. Start breathing activity");
            Print("  2. Start reflecting activity");
            Print("  3. Start listing activity");
            Print("  4. Quit");

            string[] a = ["1", "breathe", "breath", "breathing", "breathing activity"];
            string[] b = ["2", "reflect", "reflecting", "reflecting activity"];
            string[] c = ["3", "list", "listing", "listing activity"];
            string[] d = ["4", "quit"];
            string[] responses = a.Concat(b).Concat(c).Concat(d).Concat(["test"]).ToArray();

            string response = InputList("Select a choice from the menu: ", responses);

            Activity activity;

            if (CompareResponse(response, a))
                activity = breathingActivity;
            else if (CompareResponse(response, b))
                activity = reflectionActivity;
            else if (CompareResponse(response, c))
                activity = listingActivity;
            else if (CompareResponse(response, d))
            {
                Clear();
                Print("Quitting...");
                return;
            }
            else
            {
                for (int i = 3; i > 0; i--)
                {
                    Clear();
                    Print($"Error! Trying again in {i}...");
                    Wait(1);
                }

                continue;
            }

            activity.RunActivity();
        }
    }
}