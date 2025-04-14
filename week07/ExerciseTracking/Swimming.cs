public class Swimming : Activity
{
    int _laps;

    public Swimming(float minutes, int laps) : base(minutes)
    {
        _laps = laps;
    }

    public override float GetDistance() => (float)_laps * 50 / 1000 * 0.62f;
}