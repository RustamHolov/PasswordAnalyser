public class Analyser
{
    public Password password { get; set; }
    public Analyser(Password password)
    {
        this.password = password;
    }
    public Dictionary<int, string> options = new Dictionary<int, string>(){
            {1, "Check content of your password"},
            {2, "Check strength of your password"},
            {3, "Generate tips for your password"},
            {4, "Generate a random password"},
            {5, "Generate a personalized password"},
            {0, "Exit"}
        };
    public Password AnalyseMinimunRequirements(Password pass) => pass switch
    {
        _ when pass.Length < 8 => throw new Exception("Password must have at least 8 characters"),
        _ when pass.UppercaseLetters < 1 => throw new Exception("Password must have at least one uppercase letter"),
        _ when pass.Numbers < 2 => throw new Exception("Password must have at least two numbers"),
        _ when pass.SpecialCharacters < 1 => throw new Exception("Password must have at least one special character"),
        _ => pass
    }; // minimum requirements for a password


    public string ContentAnalyse(Password pass) => $"{pass.Length} characters, including:\n" +
        $"{pass.UppercaseLetters} uppercase letters \n" +
        $"{pass.Numbers} numbers \n" +
        $"{pass.SpecialCharacters} special characters";

    public string StrengthAnalyse() => "Strong";

    public List<string> GenerateTips(Person person) => new List<string> { "Tips based on password preperties or personal information" };

    public Password GeneratePassword() => new Password("Password");

    public Password GenerateRandomPassword() => new Password("RandomPassword");

    public Password GeneratePersonalizedPassword(Person p) => new Password("PersonalizedPassword");
}