using System.Diagnostics.CodeAnalysis;
using System;
using System.Text;
public class Analyzer
{
    private Password _Pass { get; set; } = new Password("password");  // default password if overloaded constructor not used or password wasn't set 

    #region Regex
    private const int _L = 8; // length (value and more)
    private const int _S = 1; // count of special symblos
    private const int _U = 1; // count of upper case letters
    private const int _D = 2; //count of digits
    public static readonly string minimunReq = $$"""^(?=(.*[A-Z]){{{_U}},})(?=(.*[0-9]){{{_D}},})(?=(.*[~`!@#$%^&*()_\-+={}[\]|\\:;'<,>.?/""]){{{_S}},}).{{{_L}},}$"""; // min.Req. is (_U) amount of upperCase, (_D) digits, (_S) special symbols, (_L) length
    #endregion
    public Analyzer() { }
    public Analyzer(Password pass) => _Pass = pass;
    public void SetPassword(Password pass) => _Pass = pass;

    public Dictionary<int, string> options = new Dictionary<int, string>(){
            {1, "Check content of your password"},
            {2, "Check strength of your password"},
            {3, "Check if your password is up to date"},
            {4, "Generate a random password"},
            {5, "Generate a personalized password"},
            {0, "Exit"}
        };

    public static bool DefualtStrongPassword(string password) => System.Text.RegularExpressions.Regex.IsMatch(password, minimunReq); // minimum requirements for a password
    public bool DefaultStrongPassword() => DefualtStrongPassword(_Pass.ToString()); //overload for internal use

    public static string ContentAnalyze(Password Pass) => $"{Pass.Length} characters, including:\n" +
        $"{Pass.UppercaseLetters} uppercase letters \n" +
        $"{Pass.Numbers} numbers \n" +
        $"{Pass.SpecialSymbols} special characters";
    public string ContentAnalyze() => ContentAnalyze(_Pass); //overload for internal use

    public static double GetStrength(Password Pass)
    {
        double strength;
        strength = Pass.Letters + Pass.UppercaseLetters + Pass.Numbers + Pass.SpecialSymbols; // one point for each character 

        return (Pass.HasUpperLetters, Pass.HasNumbers, Pass.HasSpecialSymbols) switch
        {
            (true, true, true) => strength * 1.5, // Strongest: All three types
            (true, true, false) => strength * 1.2, // Upper and numbers
            (true, false, true) => strength * 1.4, // Upper and specials
            (false, true, true) => strength * 1.3, // Numbers and specials
            (true, false, false) => strength * 0.8, // Upper only
            (false, true, false) => strength * 0.9, // Numbers only
            (false, false, true) => strength * 1.0, // Specials only
            (false, false, false) => strength * 0.5, // Weakest: No diversity

        };
    }
    public double GetStrength() => GetStrength(_Pass); //overload for internal use

    public static string PasswordInfo(Password Pass) {
        StringBuilder scale = new StringBuilder();
        int strength = (int)GetStrength(Pass);
        int scaleLength = 20;
        int filledLength = strength > scaleLength ? scaleLength : strength;
        scale.Append("Password Strength: [");
        for (int i = 0; i < scaleLength; i++){
            scale.Append(i < filledLength ? "█" : " ");
        }
        scale.Append($"] {strength:F0}/20");
        return scale.ToString();
    }
    public string PasswordInfo() => PasswordInfo(_Pass);  //overload for internal use
}