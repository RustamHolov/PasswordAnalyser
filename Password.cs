public class Password
{
    public string? Sequence { get; set; }
    public int Letters;
    public int Numbers;
    public int SpecialSymbols;
    public int Length;
    public int UppercaseLetters;
    public bool HasUpperLetters;
    public bool HasNumbers;
    public bool HasSpecialSymbols;
    public Password(string password = "") //default value is empty password
    {
        Sequence = password;
        Length = password.Length;
        Numbers = password.Count(char.IsDigit);
        SpecialSymbols = password.Count(c => char.IsSymbol(c) || char.IsSeparator(c) || char.IsPunctuation(c));
        UppercaseLetters = password.Count(char.IsUpper);
        Letters = Length - Numbers - SpecialSymbols - UppercaseLetters;
        HasUpperLetters = UppercaseLetters > 0;
        HasNumbers = Numbers > 0;
        HasSpecialSymbols = SpecialSymbols > 0;
    }

    public override string ToString() => Sequence ?? string.Empty;
}