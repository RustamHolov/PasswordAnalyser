public class Analyzer
{
    public Password Pass { get; set; } = new Password("0-Pass_word-0");
    
    private const string _lowerLetters = "?=(.*[a-z])"; // lowercase letters
    private const string _upperLetters = "?=(.*[A-Z]){2,}"; // 2+ uppercase letters
    private const string _digits = "?=(.*[0-9])"; // digits
    private const string _sSymbols = @"?=(.*[~`!@#$%^&*()_\-+={}[\]|\\:;'<,>.?/""]){2,}"; // 2+ special symbols
    private const string _length = ".{8,}"; // 8 characters or more
    private readonly string _minimunReq = @$"^({_upperLetters})({_sSymbols}){_length}$"; // minimal requirement is 6 or more characters with 1 uppercase and 1 digit
    public Analyzer() {}
    public Analyzer(Password pass) => Pass = pass;

    public Dictionary<int, string> options = new Dictionary<int, string>(){
            {1, "Check content of your password"},
            {2, "Check strength of your password"},
            {3, "Check if your password is up to date"},
            {4, "Generate a random password"},
            {5, "Generate a personalized password"},
            {0, "Exit"}
        };
    public void SetPassword(Password pass) => Pass = pass;
    public bool FitsMinimunRequirements() => System.Text.RegularExpressions.Regex.IsMatch(Pass.ToString(), _minimunReq); // minimum requirements for a password

    public string ContentAnalyze() => $"{Pass.Length} characters, including:\n" +
        $"{Pass.UppercaseLetters} uppercase letters \n" +
        $"{Pass.Numbers} numbers \n" +
        $"{Pass.SpecialCharacters} special characters";

    public string StrengthAnalyze() => Pass switch{
        _ when FitsMinimunRequirements() => "Strong",
        _ when Pass.UppercaseLetters > 0 && Pass.Numbers > 1 => "Normal",
        _ when Pass.Length < 6 => "Week",
        _ => "missing"
    };




    public List<string> GenerateTips(Person person) => new List<string> { "Tips based on password preperties or personal information" };

    public Password GeneratePassword() => new Password("Password");

    public Password GenerateRandomPassword() => new Password("RandomPassword");

    public Password GeneratePersonalizedPassword(Person p) => new Password("PersonalizedPassword");
}