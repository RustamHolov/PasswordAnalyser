public class Input
{
    private readonly string _regex = @"^[A-Za-z0-9~`!@#$%^&*()_\-+={}[\]|\\:;'<,>.?/""]+$"; // letters, numbers and special characters
    public Input(){}
    public string GenerealInput()   // avoid unknown symbols or whitespaces
    {
        string? input = Console.ReadLine();
        if (input == null || input == "")
        {
            throw new ArgumentNullException(input);
        }
        if (input.Any(char.IsWhiteSpace))
        {
            throw new ArgumentException("Input cannot contain white spaces");
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(input, _regex))
        {
            throw new ArgumentException("Input can only contain letters, numbers and special characters");
        }
        return input;
    }
    public bool TryGetNumber(Dictionary<int, string> range, out int decision)  // leads user to type correct number in menu's
    {
        if (int.TryParse(GenerealInput(), out int number) && range.Keys.Any(k => k == number))
        {
            decision = number;
            return true;
        }
        else
        {
            throw new Exception("Invalid input, type a number from the list below");
        }
    }
    public bool TryGetPassword(out string password){    //do not accept input if its less than 6 chars.
        string input = GenerealInput();
        if (input.Length > 6){
            password = input;
            return true;
        }else{
            throw new Exception("Password must be 6 or more characters");
        }
    }
}