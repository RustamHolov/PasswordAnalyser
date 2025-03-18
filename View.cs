using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Reflection;
using System.Reflection.Emit;

public class View
{
    
    public void DisplayContent(Analyser analyser, Password pass)
    {
        Console.WriteLine($"Your password consist of :\n{analyser.ContentAnalyse(pass)}");
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

    public void DisplayFinalResult(string password) {
        Console.WriteLine($"Your password is: {password} and it's Strong");
    }

    public void DisplayAllOptions(Dictionary<int, string> options){
        foreach (var option in options){
            Console.WriteLine($"{option.Key}. {option.Value}");
        }
    }


}