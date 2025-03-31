using static Utility;

public class ReflectionActivity : Activity
{
    public override string GetActivityName() => "Reflection Activity";

    public override string GetActivityDescription() => "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

    string[] _prompts = ["Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."];
    
    List<string> _usedPrompts = new();
    List<string> GetUnusedPrompts() => _prompts.ToList().Where(x => !_usedPrompts.Contains(x)).ToList();

    string[] _questions = ["Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"];

    List<string> _usedQuestions = new();
    List<string> GetUnusedQuestions() => _questions.ToList().Where(x => !_usedQuestions.Contains(x)).ToList();

    float _questionTime = 10;

    protected override void OnRunActivity(float duration)
    {
        if (GetUnusedPrompts().Count == 0)
            _usedPrompts.Clear();
        List<string> unusedPrompts = GetUnusedPrompts();
        int promptId = Random().Next(0, unusedPrompts.Count);
        string prompt = unusedPrompts[promptId];
        _usedPrompts.Add(prompt);

        Print("Consider the following prompt:");
        Print();
        Print($"--- {prompt} ---");
        Print();
        WaitForConfirm("When you have something in mind, press enter to continue.");
        Print();
        Print("Now ponder on each of the following questions as they related to this experience.");
        DisplayCountdown(5, "You may begin in: ");
        Clear();

        float timer = duration;
        while (timer > 0)
        {
            if (GetUnusedQuestions().Count == 0)
                _usedQuestions.Clear();
            List<string> unusedQuestions = GetUnusedQuestions();
            int questionId = Random().Next(0, unusedQuestions.Count);
            string question = unusedQuestions[questionId];
            _usedQuestions.Add(question);

            Write($"{question} ");
            AnimateText(_questionTime);
            Print();

            timer -= _questionTime;
        }
    }
}