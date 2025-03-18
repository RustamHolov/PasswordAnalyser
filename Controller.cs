public class Controller
{
    private Analyser Analyser { get; set; }
    private View View { get; set; }
    private Input Input { get; set; }
    public Controller(Analyser analyser, View view, Input input){
        Analyser = analyser;
        View = view;
        Input = input;
    }
    public void GenerateMenu(){
        List<string> options = View.DisplayAllOptions();
        foreach (var option in options){
            Console.WriteLine(option);
        }
    }
    public void GenerationMenu(){
        View.DisplayPassword(Analyser);
        View.DisplayRandomPassword(Analyser);
        View.DisplayPersonalizedPassword(Analyser, new Person("John", "Doe", "30", "New York"));
    }
    public void HandleUserInput(){
        while (true){
            try{
                Console.WriteLine("Enter your password: ");
                string password = Input.CheckInput(Console.ReadLine());
                Analyser.password = new Password(Analyser.AnalyzeMinimunRequirements(password));
                View.DisplayContent(Analyser, Analyser.password.ToString());
                View.DisplayFinalResult(Analyser);
                Console.WriteLine("Do you want to generate a new password? (Y/N)");
                string answer = Input.CheckInput(Console.ReadLine());
                if (string.Equals(answer, "N", StringComparison.OrdinalIgnoreCase)){
                    break;
                }
            }catch (Exception e){
                Console.WriteLine(e.Message);
                continue;
            }
        }
    }
}