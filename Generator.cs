public class Generator : Analyzer
{

    public List<string> GenerateTips(Person person) => new List<string> { "Tips based on password preperties or personal information" };

    public Password GeneratePassword() => new Password("Password");

    public Password GenerateRandomPassword() => new Password("RandomPassword");

    public Password GeneratePersonalizedPassword(Person p) => new Password("PersonalizedPassword");
}