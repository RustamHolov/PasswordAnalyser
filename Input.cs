public class Input{
    private readonly string regex = @"^[A-Za-z0-9~`!@#$%^&*()_\-+={}[\]|\\:;""'<,>.?/]+$"; // letters, numbers and special characters
    public Input(){
    }

    public string CheckInput(string? input) {
        if (input == null || input == ""){
            throw new ArgumentNullException("Input cannot be empty");
        }
        if (input.Any(char.IsWhiteSpace)){
            throw new ArgumentException("Input cannot contain white spaces");
        }
        if (!System.Text.RegularExpressions.Regex.IsMatch(input, regex)){
            throw new ArgumentException("Input can only contain letters, numbers and special characters");
        }
        return input;
    }

}