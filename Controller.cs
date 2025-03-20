using System.Linq.Expressions;

public class Controller
{
    private Analyzer Analyzer { get; set; }
    private View View { get; set; }
    private Input Input { get; set; }
    public Controller(Analyzer analyzer, View view, Input input)
    {
        Analyzer = analyzer;
        View = view;
        Input = input;
    }

    public void HandleUserInput()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Write your password:");
                Input.TryGetPassword(out string password);
                Password pass = new Password(password);
                Analyzer.SetPassword(pass);
                View.DisplayAllOptions(Analyzer.options);
                Console.WriteLine("Choose your option:");
                Input.TryGetNumber(Analyzer.options, out int decision);
                // TODO Only 2 options ar first, work with your password or generate password 
                switch (decision)
                {
                    case 1: Console.WriteLine("Type your password"); View.DisplayContent(Analyzer, pass); continue;
                    case 2: View.DisplayStrength(Analyzer); continue;
                    case 3: View.DisplayUpToDate(Analyzer); continue;
                    case 0: break;
                    default: break;
                }
                break;
            }
            catch (Input.InvalidItemException e)
            {
                Console.WriteLine(e);
                continue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }
}