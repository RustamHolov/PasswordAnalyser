using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Reflection;
using System.Reflection.Emit;

public class View
{

    public void DisplayPassword(Password pass) => Console.Write(pass.ToString());
    public void DisplayContent(Analyzer analyser, Password pass)
    {
        Console.Write($"Your password ["); DisplayPassword(pass); Console.WriteLine ("]");
        Console.WriteLine(analyser.ContentAnalyze());
    }

    public void DisplayStrength(Analyzer analyser)
    {
        Console.WriteLine(analyser.PasswordInfo());
    }

    public void DisplayUpToDate(Analyzer analyzer) => Console.WriteLine(analyzer.DefaultStrongPassword() ? "Password is strong for current time" : "Password can be cracked");
    public void DisplayAllOptions(Dictionary<int, string> options)
    {
        foreach (var option in options)
        {
            Console.WriteLine($"{option.Key}. {option.Value}");
        }
    }


    public void DisplayTips(Generator gen, Person person)
    {
        foreach (var tip in gen.GenerateTips(person))
        {
            Console.WriteLine(tip);
        }
    }

    public void DisplayPassword(Generator gen)
    {
        Console.WriteLine(gen.GeneratePassword());
    }

    public void DisplayRandomPassword(Generator gen)
    {
        Console.WriteLine(gen.GenerateRandomPassword());
    }

    public void DisplayPersonalizedPassword(Generator gen, Person p)
    {
        Console.WriteLine(gen.GeneratePersonalizedPassword(p));
    }

}