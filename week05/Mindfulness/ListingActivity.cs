using static Utility;

public class ListingActivity : Activity
{
    public override string GetActivityName() => "Listing Activity";

    public override string GetActivityDescription() => "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    string[] _prompts = ["Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"];
    
    List<string> _usedPrompts = new();
    List<string> GetUnusedPrompts() => _prompts.ToList().Where(x => !_usedPrompts.Contains(x)).ToList();

    protected override void OnRunActivity(float duration)
    {
        if (GetUnusedPrompts().Count == 0)
            _usedPrompts.Clear();
        List<string> unusedPrompts = GetUnusedPrompts();
        int promptId = Random().Next(0, unusedPrompts.Count);
        string prompt = unusedPrompts[promptId];
        _usedPrompts.Add(prompt);

        Print("List as many responses as you can to the following prompt:");
        Print($"--- {prompt} ---");
        DisplayCountdown(5, "You may begin in: ");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        int counter = 0;
        while (DateTime.Now < endTime)
        {
            Input();
            counter++;
        }

        Print($"You listed {counter} items!");
        Print();
        DisplayCountdown(5, "Continuing in ", "...");
    }
}