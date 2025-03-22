using System.Text;
using System.Text.RegularExpressions;
public class Analyzer
{
    private Password _pass { get; set; } = new Password();  // default password if overloaded constructor not used or password wasn't set 

    #region Regex
    private const int _L = 8; // length (value and more)
    private const int _S = 1; // count of special symblos
    private const int _U = 1; // count of upper case letters
    private const int _D = 1; //count of digits
    public static readonly string s_minimunReq = $$"""^(?=(.*[A-Z]){{{_U}},})(?=(.*[0-9]){{{_D}},})(?=(.*[~`!@#$%^&*()_\-+={}[\]|\\:;'<,>.?/""]){{{_S}},}).{{{_L}},}$"""; // min.Req. is (_U) amount of upperCase, (_D) digits, (_S) special symbols, (_L) length
    #endregion
    public Analyzer() { }
    public Analyzer(Password pass) => _pass = pass;
    public void SetPassword(Password pass) => _pass = pass;
    public Password GetPassword() => _pass;

    public static bool DefualtStrongPassword(Password Pass) => Regex.IsMatch(Pass.ToString(), s_minimunReq); // minimum requirements for a password
    public bool DefaultStrongPassword() => DefualtStrongPassword(_pass); //overload for internal use

    public static string ContentAnalyze(Password Pass) => Pass switch
    {
        _ when Pass.Length < 8 => "Warning: Password length is too short. Consider using at least 8 characters.",
        _ when !Pass.HasNumbers || !Pass.HasSpecialSymbols || !Pass.HasUpperLetters => "Suggestion: For stronger passwords, include a mix of uppercase letters, lowercase letters, numbers, and special symbols.",
        _ when DefualtStrongPassword(Pass) && Pass.Length >= 12 => "Excellent! This password has a good mix of character types and sufficient length.",
        _ when DefualtStrongPassword(Pass) && Pass.Length < 12 => "Good password, but consider to increase the length.",
        _ when Regex.IsMatch(Pass.ToString().ToLower(), @"password|123456|qwerty") => "Warning: Password contains common patterns. Consider using a more unique password.",
        _ when Regex.IsMatch(Pass.ToString(), @"(.)\1{2,}") => "Warning: Password contains repeating characters. Consider using more diverse characters.",
        _ when Regex.IsMatch(Pass.ToString().ToLower(), @"abc|def|ghi|jkl|mno|pqr|stu|vwx|yz|123|456|789|012") => "Warning: Password contains sequential characters. Consider using non-sequential characters.",
        _ => "failed to get information, try new password"
    };
    public string ContentAnalyze() => ContentAnalyze(_pass); //overload for internal use

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
    public double GetStrength() => GetStrength(_pass); //overload for internal use

    public static string PasswordInfo(Password Pass)
    {
        StringBuilder scale = new StringBuilder();
        int strength = (int)GetStrength(Pass);
        int scaleLength = 20;
        int filledLength = strength > scaleLength ? scaleLength : strength;  // 20 points is the highest rate for strength
        scale.Append("Password Strength: ├");
        for (int i = 0; i < scaleLength; i++)
        {
            scale.Append(i < filledLength ? "▓" : "░");
        }
        scale.Append($"┤ {strength:F0}/20");
        return scale.ToString();
    }
    public string PasswordInfo() => PasswordInfo(_pass);  //overload for internal use

    public bool PasswordExisting() => _pass.Length > 0; 
}