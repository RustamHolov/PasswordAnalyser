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

    public Dictionary<int, string> WelcomeMenu = new Dictionary<int, string>(){
        {1, "Check existed"},
        {2, "Create new"},
        {0, "Exit"}
    };
    public Dictionary<int, string> MainMenu = new Dictionary<int, string>(){
            {1, "Get password analysis"},
            {2, "Show strength of your password"},
            {3, "Check if your password meets minimum requirements"},
            {9, "Previous Menu"},
            {0, "Exit"}
        };

    public Password GetPassword()
    {
        Console.WriteLine("Write your password:");
        Input.TryGetPassword(out string password);
        Password pass = new Password(password);
        return pass;
    }
    public int GetMenuItem(Dictionary<int, string> menu)
    {
        Input.TryGetNumber(menu, out int decision);
        return decision;
    }
    public void WMenu(){
        View.DisplayMenu(WelcomeMenu);
        switch (GetMenuItem(WelcomeMenu)){
            case 1: Analyzer.SetPassword(GetPassword()); Console.Clear(); MMenu(); break;
            case 2: Analyzer.SetPassword(new Password()); Console.Clear(); MMenu(); break;
            case 0: break;
        };

    }
    public void MMenu(){
        View.DisplayMenu(MainMenu);
        switch (GetMenuItem(MainMenu)){
            case 1 when !Analyzer.PasswordExisting(): Analyzer.SetPassword(GetPassword()); goto case 1;
            case 1: Console.Clear(); View.DisplayContent(Analyzer); MMenu(); break;
            case 2 when !Analyzer.PasswordExisting(): Analyzer.SetPassword(GetPassword()); goto case 2;
            case 2: Console.Clear(); View.DisplayStrength(Analyzer); MMenu(); break;
            case 3 when !Analyzer.PasswordExisting(): Analyzer.SetPassword(GetPassword()); goto case 3;
            case 3: Console.Clear(); View.IsUpToDate(Analyzer); MMenu(); break;
            case 9: Console.Clear(); WMenu(); break;
            case 0: break;
        }
    }
    
    public void HandleUserInput()
    {
        while(true){
            try
            {
                WMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            break;
        }
    }
}