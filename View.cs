using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Reflection;
using System.Reflection.Emit;

public class View
{

    public void DisplayContent(Analyzer analyser)
    {
        Console.WriteLine($"Your password consist of :\n{analyser.ContentAnalyze()}");
    }

    public void DisplayStrength(Analyzer analyser)
    {
        Console.WriteLine($"Your password rated as {analyser.StrengthAnalyze()}");
    }

    public void DisplayTips(Analyzer analyser, Person person)
    {
        foreach (var tip in analyser.GenerateTips(person))
        {
            Console.WriteLine(tip);
        }
    }

    public void DisplayPassword(Analyzer analyser)
    {
        Console.WriteLine(analyser.GeneratePassword());
    }

    public void DisplayRandomPassword(Analyzer analyser)
    {
        Console.WriteLine(analyser.GenerateRandomPassword());
    }

    public void DisplayPersonalizedPassword(Analyzer analyser, Person p)
    {
        Console.WriteLine(analyser.GeneratePersonalizedPassword(p));
    }

    public void DisplayFinalResult(string password)
    {
        Console.WriteLine($"Your password is: {password} and it's Strong");
    }

    public void DisplayAllOptions(Dictionary<int, string> options)
    {
        foreach (var option in options)
        {
            Console.WriteLine($"{option.Key}. {option.Value}");
        }
    }


}