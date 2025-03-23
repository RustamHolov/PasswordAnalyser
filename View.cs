using PasswordAnalyser;

public class View
{

    public void DisplayPassword(Password pass) => Console.Write(pass.ToString());
    public void DisplayContent(Analyzer analyser)
    {
        Console.Write($"Your password [     "); DisplayPassword(analyser.GetPassword()); Console.WriteLine("     ]");
        Console.WriteLine($"{analyser.ContentAnalyze()}");
    }

    public void DisplayStrength(Analyzer analyser)
    {
        Console.WriteLine($"\n{analyser.PasswordInfo()}");
    }

    public void IsUpToDate(Analyzer analyzer) => Console.WriteLine(analyzer.DefaultStrongPassword() ? "\nThe password is relevant" : "\nPassword can be hacked");
    public void DisplayStatus(Analyzer analyzer) {
        Console.WriteLine("─────────────────────────────");
        Console.WriteLine(analyzer.PasswordExists() ? "*** Password set ***": "*** No password provided ***");
    }
    public void DisplayMenu(Dictionary<int, string> options)
    {
        Console.WriteLine("─────────────────────────────");
        foreach (var option in options)
        {
            Console.WriteLine($"{option.Key}. {option.Value}");
        }
        Console.WriteLine("─────────────────────────────");
        Console.WriteLine("Choose your option:");
    }

}