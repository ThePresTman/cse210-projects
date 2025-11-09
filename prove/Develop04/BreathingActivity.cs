using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by guiding you through slow breathing. Focus on your breath."
    ) { }

    public void Run()
    {
        StartActivity();
        int duration = GetDuration();
        int elapsed = 0;
        while (elapsed < duration)
        {
            Console.WriteLine("\nBreathe in...");
            Countdown(4);
            elapsed += 4;
            if (elapsed >= duration) break;
            Console.WriteLine("Breathe out...");
            Countdown(6);
            elapsed += 6;
        }
        EndActivity();
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
