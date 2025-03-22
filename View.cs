using PasswordAnalyser;

public class View
{

    public void DisplayPassword(Password pass) => Console.Write(pass.ToString());
    public void DisplayContent(Analyzer analyser)
    {
        Console.Write($"\nYour password ["); DisplayPassword(analyser.GetPassword()); Console.WriteLine("]");
        Console.WriteLine($"\n{analyser.ContentAnalyze()}");
    }

    public void DisplayStrength(Analyzer analyser)
    {
        Console.WriteLine($"\n{analyser.PasswordInfo()}");
    }

    public void IsUpToDate(Analyzer analyzer) => Console.WriteLine(analyzer.DefaultStrongPassword() ? "\nThe password is relevant" : "\nPassword can be hacked");
    public void DisplayMenu(Dictionary<int, string> options)
    {
        Console.WriteLine("________________________");
        foreach (var option in options)
        {
            Console.WriteLine($"{option.Key}. {option.Value}");
        }
        Console.WriteLine("________________________");
        Console.WriteLine("Choose your option:");
    }

}