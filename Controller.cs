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
    public Dictionary<int, string> Options = new Dictionary<int, string>(){
            {1, "Get password analysis"},
            {2, "Show strength of your password"},
            {3, "Check if your password meets minimum requirements"},
            {0, "Exit"}
        };

    public void CreatePassword()
    {
        Console.WriteLine("Write your password:");
        Input.TryGetPassword(out string password);
        Password pass = new Password(password);
        Analyzer.SetPassword(pass);
    }
    public int GetMenuItem()
    {
        View.DisplayMenu(Options);
        Input.TryGetNumber(Options, out int decision);
        return decision;
    }
    public void HandleUserInput()
    {
        CreatePassword();
        while (true)
        {
            try
            {
                switch (GetMenuItem())
                {
                    case 1: View.DisplayContent(Analyzer); continue;
                    case 2: View.DisplayStrength(Analyzer); continue;
                    case 3: View.IsUpToDate(Analyzer); continue;
                    case 0: break;
                    default: continue;
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