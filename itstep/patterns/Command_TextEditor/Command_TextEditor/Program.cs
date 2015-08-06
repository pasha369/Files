using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Command_TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            UserOperation user = new UserOperation();
            Editor editor = new Editor();
    
            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo keyInfo = Console.ReadKey(false);

                    if (keyInfo.Key == ConsoleKey.F1)
                    {
                        user.Undo();
                    }
                    else if (keyInfo.Key == ConsoleKey.F2)
                    {
                        user.Redo();
                    }
                    else
                    {
                        string line = Console.ReadLine();
                        ICommand command = new TextCommand(editor, keyInfo.KeyChar + line);
                        user.ExecuteCommand(command);
                    }
                }

            }
            Console.ReadLine();
        }
    }


    /// <summary>
    /// Abstract command
    /// </summary>
    interface ICommand
    {
        void Execute();
    }

    /// <summary>
    /// Abstract receiver
    /// </summary>
    interface IReceiver
    {
        void EnterText(string word);
    }

    /// <summary>
    /// Concrete command
    /// </summary>
    class TextCommand : ICommand
    {
        private string _line;
        private IReceiver _editor;

        public TextCommand(Editor receiver, string line)
        {
            _editor = receiver;
            _line = line;
        }

        public void Execute()
        {
            _editor.EnterText(_line);
        }
    }

    /// <summary>
    /// Receiver
    /// </summary>
    class Editor : IReceiver
    {
        public void EnterText(string word)
        {
            Console.WriteLine(word);
        }
    }

    /// <summary>
    /// Invoker
    /// </summary>
    class UserOperation
    {
        private IReceiver _editor;
        private List<ICommand> commands;
        private int current;


        public UserOperation()
        {
            commands = new List<ICommand>();
        }

        public void Undo()
        {
            if(current > 0)
                current--;
            
            RunCommand();
        }
        public void Redo()
        {
            if(current < commands.Count)
                current++;

            RunCommand();

        }
        public void ExecuteCommand(ICommand command)
        {
            commands.Add(command);
            current++;

            RunCommand();
        }

        public void RunCommand()
        {
            Console.Clear();
            for (int i = 0; i < current; i++)
            {
                commands[i].Execute();
            }
        }
    }
}
