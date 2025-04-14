public class Running : Activity
{
    float _distance;

    public Running(float minutes, float distance) : base(minutes)
    {
        _distance = distance;
    }

    public override float GetDistance() => _distance;
}