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
    public Dictionary<int, string> MainMenu = new Dictionary<int, string>(){
        {1, "New Password"},
        {2, "Show strength of your password"},
        {3, "Show password and analysis" },
        {4, "Check if your password meets minimum requirements" },
        {5, "Clear Password"},
        {0, "Exit"}
    };
    public Dictionary<int, string> InternalMenu = new Dictionary<int, string>(){
        {1, "Try new password"},
        {9, "Previous menu"},
        {0, "Exit"}
    };

    public Password GetPassword()              // Creating new Password instance from user input, exceptions handling
    {
        try{
            Console.WriteLine("Enter your password:");
            Input.TryGetPassword(out string password);
            Password pass = new Password(password);
            return pass;
        }catch(Exception e){
            Console.WriteLine(e.Message);
            return GetPassword();
        }
    }
    public int GetMenuItem(Dictionary<int, string> menu) // Navigating through menu after users input, exceptions handling
    {
        try{
            Input.TryGetNumber(menu, out int decision);
            return decision;
        }catch (Exception e){
            Console.WriteLine(e.Message);
            return GetMenuItem(menu);
        }
    }
    
    #region Methods for better navigation 
    public void Analysis()
    {
        if (!Analyzer.PasswordExists()) { Analyzer.SetPassword(GetPassword()); }
        Console.Clear();
        View.DisplayContent(Analyzer);
    }
    public void Strength()
    {
        if (!Analyzer.PasswordExists()) { Analyzer.SetPassword(GetPassword()); }
        Console.Clear();
        View.DisplayStrength(Analyzer);
    }
    public void UpToDate()
    {
        if (!Analyzer.PasswordExists()) { Analyzer.SetPassword(GetPassword()); }
        Console.Clear();
        View.IsUpToDate(Analyzer);
    }
    public void SetPassword() {
        Analyzer.SetPassword(GetPassword());
        Console.Clear();
    }

    public void ClearPassword(){
        Analyzer.SetPassword(new Password());
        Console.Clear();
    }
    #endregion

    public void RunMainMenu()    // Main menu of the programm 
    {
        View.DisplayStatus(Analyzer);
        View.DisplayMenu(MainMenu);
        switch (GetMenuItem(MainMenu))
        {
            case 1: SetPassword(); RunMainMenu(); break;
            case 2: Strength(); RunInternalMenu(Strength); break;
            case 3: Analysis(); RunInternalMenu(Analysis); break;
            case 4: UpToDate(); RunInternalMenu(UpToDate); break;
            case 5: ClearPassword(); RunMainMenu(); break;
            case 0: break;
        }
    }
    public void RunInternalMenu(Action act)  // internal menu for quick method reuse
    {   
        View.DisplayMenu(InternalMenu);
        switch(GetMenuItem(InternalMenu)){
            case 1: Analyzer.SetPassword(GetPassword()); act(); RunInternalMenu(act); break;
            case 9: Console.Clear(); RunMainMenu(); break;
            case 0: break;
        }
    }

    public void MainFLow()
    {
        while (true)
        {
            RunMainMenu();
            break;
        }
    }
}