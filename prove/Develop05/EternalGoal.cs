public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points; // never completed, keep earning
    }

    public override bool IsComplete() => false;

    public override string GetStatus()
    {
        return $"[∞] {Name}";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}
