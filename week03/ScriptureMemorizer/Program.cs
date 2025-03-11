using System;
using static Utility;

/*
~~Showing Creativity and Exceeding Requirements~~

In addition to the base requirements for this assignment, I also added the following:
- On start, the program asks the user to input a number of words for it to hide each time they press enter.
- When selecting random words to hide, the program excludes words that are already hidden.
- After finishing the program, the user can press enter to start over or type "quit" to quit
*/

class Program
{
    static string _scriptureString = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

    static Scripture _scripture = new(new("Proverbs", 3, 5, 6), Word.FromString(_scriptureString));

    static void Main(string[] args)
    {
        while (true)
        {
            Clear();

            int wordsToHide;

            while (true)
            {
                wordsToHide = InputType<int>("Enter the increment of words to hide: ");

                if (wordsToHide <= 0)
                    Print("Increment must be a positive number!");
                else
                    break;
            }

            while (true)
            {
                Clear();

                Print(_scripture.GetScriptureString());

                Print();

                if (_scripture.GetVisibleWordCount() == 0)
                    break;

                if (Input("Press enter to continue or type \"quit\" to quit. ").ToLower() == "quit")
                    goto Quit;
                
                _scripture.HideRandomWords(wordsToHide);
            }

            Clear();

            Print(_scripture.GetScriptureString());

            Print();

            if (Input("Press enter to start over or type \"quit\" to quit. ").ToLower() == "quit")
                goto Quit;
            
            _scripture.ResetHidden();
        }

        Quit:

        Clear();

        _scripture.ResetHidden();

        Print(_scripture.GetScriptureString());

        Print();

        Print("Quit program. Click \"Run\" to try again.");
    }
}