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
    // public void GenerateMenu(){
    //     List<string> options = View.DisplayAllOptions();
    //     foreach (var option in options){
    //         Console.WriteLine(option);
    //     }
    // }
    public void GenerationMenu()
    {

    }
    public void HandleUserInput()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Write your password:");
                Analyzer.SetPassword(new Password(Input.AppropriateInput()));
                View.DisplayAllOptions(Analyzer.options);
                Console.WriteLine("Choose your option:");
                Input.InputInRange(Input.AppropriateInput(), Analyzer.options, out int decision);
                // TODO Only 2 options ar first, work with your password or generate password 
                switch (decision)
                {
                    case 1: Console.WriteLine("Type your password"); View.DisplayContent(Analyzer); continue;
                    case 2: View.DisplayStrength(Analyzer); continue;
                    case 3: ; continue;
                    case 0: break;
                    default: break;
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }
}