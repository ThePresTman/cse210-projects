public class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        int total = Points;

        if (_currentCount == _targetCount)
        {
            total += _bonus;
        }

        return total;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        return $"{check} {Name} — Completed {_currentCount}/{_targetCount}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}
