using static Utility;

public abstract class Activity
{
    public virtual string GetActivityName() => "Unnamed";

    public virtual string GetActivityDescription() => "Description";

    public void RunActivity()
    {
        Clear();
        StartActivity(out float duration);
        Clear();
        Print("Get ready...");
        AnimateText(5);
        Print();
        OnRunActivity(duration);
        Clear();
        EndActivity(duration);
        WaitForConfirm("Press any button to continue...");
    }

    void StartActivity(out float duration)
    {
        Print($"Wecome to the {GetActivityName()}.");
        Print();
        Print(GetActivityDescription());
        Print();
        duration = InputType<float>("How long, in seconds, would you like for your session? ");
    }

    protected virtual void OnRunActivity(float duration) { }

    void EndActivity(float duration)
    {
        Print("Well done!");
        AnimateText(5);
        Print();
        Print($"You have completed another {duration} seconds of the {GetActivityName()}");
        AnimateText(5);
        Print();
    }
}