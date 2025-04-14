public abstract class Activity
{
    float _minutes; // length in minutes
    protected float GetMinutes() => _minutes;

    public Activity(float minutes)
    {
        _minutes = minutes;
    }

    public abstract float GetDistance();
    public virtual float GetSpeed() => GetDistance() / GetMinutes() * 60;
    public virtual float GetPace() => GetMinutes() / GetDistance();

    public string GetSummary() => $"{DateTime.Now.ToString("dd MMM yyyy")} {GetType()} (30 min)- Distance: {Math.Round(GetDistance(), 2)} miles; Speed: {Math.Round(GetSpeed(), 2)} mph; Pace: {Math.Round(GetPace(), 2)} min per mile";
}