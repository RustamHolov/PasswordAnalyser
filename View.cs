using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class View
{

    public void DisplayContent(Analyser analyser, string password)
    {
        Console.WriteLine($"Your password consist of :\n{analyser.ContentAnalyse(password)}");
    }
    
    public void DisplayStrength(Analyser analyser)
    {
        Console.WriteLine(analyser.StrengthAnalyse());
    }

    public void DisplayTips(Analyser analyser, Person person)
    {
        foreach (var tip in analyser.GenerateTips(person))
        {
            Console.WriteLine(tip);
        }
    }

    public void DisplayPassword(Analyser analyser)
    {
        Console.WriteLine(analyser.GeneratePassword());
    }

    public void DisplayRandomPassword(Analyser analyser)
    {
        Console.WriteLine(analyser.GenerateRandomPassword());
    }

    public void DisplayPersonalizedPassword(Analyser analyser, Person p)
    {
        Console.WriteLine(analyser.GeneratePersonalizedPassword(p));
    }

    public void DisplayFinalResult(Analyser analyser) {
        Console.WriteLine($"Your password is: {analyser.password} and it's {analyser.StrengthAnalyse()}");
    }

    public static List<string> DisplayAllOptions() => new List<string> { "All methods from View" }; 

    public static string FormateOptionsForConsole(List<string> options) => string.Join("\n", options);

}