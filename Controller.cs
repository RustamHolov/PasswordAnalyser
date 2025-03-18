public class Controller
{
    private Analyser Analyser { get; set; }
    private View View { get; set; }
    private Input Input { get; set; }
    public Controller(Analyser analyser, View view, Input input)
    {
        Analyser = analyser;
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
                View.DisplayAllOptions(Analyser.options);
                Console.WriteLine("Choose your option:");
                Input.InputInRange(Input.AppropriateInput(), Analyser.options, out int decision);
                // TODO Only 2 options ar first, work with your password or generate password 
                switch (decision)
                {
                    case 1: Console.WriteLine("Type your password"); View.DisplayContent(Analyser, new Password(Input.AppropriateInput())); continue;
                    case 2: Console.WriteLine("Create strong password"); View.DisplayFinalResult(Analyser.AnalyseMinimunRequirements(new Password(Input.AppropriateInput())).ToString()); continue;
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