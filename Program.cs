using System.ComponentModel.Design;

namespace PasswordAnalyser;

class Program
{
    static void Main(string[] args)
    {
        Controller controller = new Controller(new Analyzer(), new View(), new Input());
        controller.HandleUserInput();
    }
}
