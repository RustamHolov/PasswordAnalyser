public class Password{
    public string? Sequence { get; set; }
    public int Letters;
    public int Numbers;
    public int SpecialCharacters;
    public int Length;
    public int UppercaseLetters;
    public Password(string password){
        Sequence = password;
        Length = password.Length;
        Numbers = password.Count(char.IsDigit);
        SpecialCharacters = password.Count(c => char.IsSymbol(c) || char.IsSeparator(c) || char.IsPunctuation(c));
        UppercaseLetters = password.Count(char.IsUpper);
        Letters = Length - Numbers - SpecialCharacters - UppercaseLetters;
    }
    

    public override string ToString() => Sequence ?? string.Empty;
}