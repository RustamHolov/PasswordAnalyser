public class Person{
    public string name { get; set; }
    public string surname { get; set; }
    public string age { get; set; }
    public string city { get; set; }
    public Person(string name, string surname, string age, string city){
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.city = city;
    }
}