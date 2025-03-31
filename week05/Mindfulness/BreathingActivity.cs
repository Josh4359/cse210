using static Utility;

public class BreathingActivity : Activity
{
    public override string GetActivityName() => "Breathing Activity";

    public override string GetActivityDescription() => "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    int _breatheInTime = 4;

    int _breatheOutTime = 6;

    protected override void OnRunActivity(float duration)
    {
        float timer = duration;
        while (timer > 0)
        {
            DisplayCountdown(_breatheInTime, "Breathe in... ");
            DisplayCountdown(_breatheOutTime, "Now breathe out... ");
            Print();

            timer -= _breatheInTime + _breatheOutTime;
        }
    }
}