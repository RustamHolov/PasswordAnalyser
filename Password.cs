public class Password{
    public string? password { get; set; }
    public int letters;
    public int numbers;
    public int specialCharacters;
    public int length;
    public int uppercaseLetters;
    public Password(string password){
        this.password = password;
    }

    public override string ToString() => password ?? string.Empty;
}