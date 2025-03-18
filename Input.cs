public class Input
{
    private readonly string regex = @"^[A-Za-z0-9~`!@#$%^&*()_\-+={}[\]|\\:;'<,>.?/""]+$"; // letters, numbers and special characters
    public Input()
    {
    }

    public string AppropriateInput()
    {
        string? outside = Console.ReadLine();
        string? input = outside;
        if (input == null || input == "")
        {
            throw new ArgumentNullException(input);
        }
        if (input.Any(char.IsWhiteSpace))
        {
            throw new ArgumentException("Input cannot contain white spaces");
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(input, regex))
        {
            throw new ArgumentException("Input can only contain letters, numbers and special characters");
        }
        return input;
    }
    public bool InputInRange(string? input, Dictionary<int, string>? range, out int decision)
    {
        if (int.TryParse(input, out int number) && range!=null && range.Keys.Any(k => k == number))
        {
            Console.WriteLine($"You chose {input}");
            decision = number;
            return true;
        }else{
             throw new ArgumentException("Invalid number");
        }
    }
}