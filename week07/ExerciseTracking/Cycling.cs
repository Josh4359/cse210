public class Cycling : Activity
{
    float _speed;

    public Cycling(float minutes, float speed) : base(minutes)
    {
        _speed = speed;
    }

    public override float GetDistance() => 0;
    public override float GetSpeed() => _speed;
    public override float GetPace() => 60 / GetSpeed();
}