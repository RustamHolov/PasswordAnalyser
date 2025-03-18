public class Analyser{
    public Password password { get; set; }
    public Analyser(Password password){
        this.password = password;
    }
    public string AnalyzeMinimunRequirements(string input) => input switch
    {
        _ when input.Length < 8 => throw new Exception("Password must have at least 8 characters"),
        _ when !input.Any(char.IsUpper) => throw new Exception("Password must have at least one uppercase letter"),
        _ when !input.Any(char.IsDigit) => throw new Exception("Password must have at least one number"),
        _ when !input.Any(c => char.IsSymbol(c) || char.IsPunctuation(c) || char.IsSeparator(c))  => throw new Exception("Password must have at least one special character"),
        _ => input
    }; // minimum requirements for a password
    

    public string ContentAnalyse(String password) => $"{password.Length} characters, including:\n" +
        $"{password.Count(char.IsUpper)} uppercase letters \n" +
        $"{password.Count(char.IsDigit)} numbers \n" +
        $"{password.Count(c => char.IsSymbol(c) || char.IsSeparator(c) || char.IsPunctuation(c))} special characters";

    public string StrengthAnalyse() => "Strong";

    public List<string> GenerateTips(Person person) => new List<string> {"Tips based on password preperties or personal information"};

    public Password GeneratePassword() => new Password("Password");

    public Password GenerateRandomPassword() => new Password("RandomPassword");

    public Password GeneratePersonalizedPassword(Person p) => new Password("PersonalizedPassword");
}