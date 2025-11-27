public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override int RecordEvent()
    {
        _completed = true;
        return Points;
    }

    public override bool IsComplete() => _completed;

    public override string GetStatus()
    {
        return IsComplete() ? $"[X] {Name}" : $"[ ] {Name}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_completed}";
    }
}
