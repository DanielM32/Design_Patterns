using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab1OOD
{
    public interface ICommand
    {
        void Execute();
    }
    public interface IParameterizedCommand : ICommand
    {
        void SetParameters(string[] parameters);
    }

    public class CommandManager
    {
        private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        public void RegisterCommand(string name, ICommand command)
        {
            commands[name] = command;
        }
        public void ExecuteCommand(string name)
        {
            string[] parts = name.Split(new char[] { ' ' }, 3);
            string commandName = parts.Length > 1 ? parts[0] + " " + parts[1] : parts[0];
            string parametersString = parts.Length > 2 ? parts[2] : "";
            string[] parameters = parametersString.Split(' ');

            if (commands.TryGetValue(commandName, out var command))
            {
                // This checks if the command is an AddCommand for any type.
                if (command.GetType().IsGenericType && command.GetType().GetGenericTypeDefinition() == typeof(AddCommand<>))
                {
                    while (true)
                    {
                        Console.Write("Enter field=value or DONE or EXIT: ");
                        string input = Console.ReadLine();

                        if (input.ToUpper() == "DONE")
                        {
                            command.Execute();
                            break;
                        }
                        else if (input.ToUpper() == "EXIT")
                        {
                            break;
                        }
                        else
                        {
                            parameters = input.Split(' ');
                            if (command is IParameterizedCommand parameterizedCommand)
                            {
                                parameterizedCommand.SetParameters(parameters);
                            }
                        }
                    }
                }
                else
                {
                    // This is a regular command. The parameters should be in the format "<field>=<value>".
                    if (command is IParameterizedCommand parameterizedCommand)
                    {
                        parameterizedCommand.SetParameters(parameters);
                    }
                    command.Execute();
                }
            }
            else
            {
                Console.WriteLine($"Command {commandName} not found.");
            }
        }


        //Dictionaries

        public Dictionary<string, Type> classFieldTypes = new Dictionary<string, Type>()
{
    { "Name", typeof(string) },
    { "Code", typeof(string) },
    { "Duration", typeof(string) },
    { "Teachers", typeof(List<string>) },
    { "Students", typeof(List<string>) }
};

       public Dictionary<string, Type> teacherFieldTypes = new Dictionary<string, Type>()
{
    { "Name", typeof(string) },
    { "Surname", typeof(string) },
    { "Rank", typeof(string) },
    { "Code", typeof(string) },
    { "Classes", typeof(List<string>) }
};

       public Dictionary<string, Type> studentFieldTypes = new Dictionary<string, Type>()
{
    { "Name", typeof(string) },
    { "Surname", typeof(string) },
    { "Semester", typeof(int) },
    { "Code", typeof(string) },
    { "Classes", typeof(List<string>) }
};
       public Dictionary<string, Type> roomfieldTypes = new Dictionary<string, Type>()
{
    { "Number", typeof(int) },
    { "Type", typeof(string) },
    { "Classes", typeof(List<string>) }
};


    }

    public class ListCommand<T> : ICommand
    {
        private readonly ICustomCollection<T> _collection;
        private readonly Dictionary<string, Type> _fieldTypes;

        public ListCommand(ICustomCollection<T> collection, Dictionary<string, Type> fieldTypes)
        {
            _collection = collection;
            _fieldTypes = fieldTypes;
        }

        public void Execute()
        {
            var iterator = _collection.GetForwardIterator();
            while (iterator.MoveNext())
            {
                var obj = iterator.Current;
                foreach (var field in _fieldTypes)
                {
                    var value = obj.GetType().GetProperty(field.Key).GetValue(obj);
                    if (value is List<string> listValue)
                    {
                        Console.WriteLine($"{field.Key}: {String.Join(", ", listValue)}");
                    }
                    else
                    {
                        Console.WriteLine($"{field.Key}: {value}");
                    }
                }
                Console.WriteLine();
            }
        }
    }

        public class FindCommand<T> : ICommand, IParameterizedCommand
    {
        private readonly ICustomCollection<T> _collection;
        private Dictionary<string, Predicate<T>> _requirements;
        private Dictionary<string, Type> _fieldTypes;

        public FindCommand(ICustomCollection<T> collection, Dictionary<string, Predicate<T>> requirements, Dictionary<string, Type> fieldTypes)  
        {
            _collection = collection;
            _requirements = requirements;
            _fieldTypes = fieldTypes; 
        }

        public void Execute()
        {
            var iterator = _collection.GetForwardIterator();
            while (iterator.MoveNext())
            {
                var obj = iterator.Current;
                // Check if the object matches all requirements
                if (_requirements.All(requirement => requirement.Value(obj)))
                {
                    // If it does, print out all its properties

                    // Use the field type information to correctly format the output
                    foreach (var fieldName in _fieldTypes.Keys)
                    {
                        var value = obj.GetType().GetProperty(fieldName).GetValue(obj);

                        if (_fieldTypes[fieldName] == typeof(List<string>))
                        {
                            // Print list elements separated by commas
                            Console.WriteLine($"{fieldName}: {string.Join(", ", (List<string>)value)}");
                        }
                        else
                        {
                            // Just print the value as is
                            Console.WriteLine($"{fieldName}: {value}");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }


        public void SetParameters(string[] parameters)
        {
            _requirements = new Dictionary<string, Predicate<T>>();

            foreach (string parameter in parameters)
            {
                string[] parts = parameter.Split(new[] { '=', '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    throw new ArgumentException($"Invalid parameter format: {parameter}");
                }

                string fieldName = parts[0];
                string valueStr = parts[1];

                if (_fieldTypes.TryGetValue(fieldName, out Type fieldType))
                {
                    if (fieldType == typeof(int))
                    {
                        int value = int.Parse(valueStr);
                        if (parameter.Contains("<"))
                        {
                            _requirements[fieldName] = obj => (int)obj.GetType().GetProperty(fieldName).GetValue(obj) < value;
                        }
                        else if (parameter.Contains(">"))
                        {
                            _requirements[fieldName] = obj => (int)obj.GetType().GetProperty(fieldName).GetValue(obj) > value;
                        }
                        else
                        {
                            _requirements[fieldName] = obj => (int)obj.GetType().GetProperty(fieldName).GetValue(obj) == value;
                        }
                    }
                    else if (fieldType == typeof(string))
                    {
                        _requirements[fieldName] = obj => (string)obj.GetType().GetProperty(fieldName).GetValue(obj) == valueStr;
                    }
                    else if (fieldType == typeof(List<string>))
                    {
                        _requirements[fieldName] = obj => ((List<string>)obj.GetType().GetProperty(fieldName).GetValue(obj)).Contains(valueStr);
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid field name: {fieldName}");
                }
            }
        }


    }

    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }

    //Task 4

    public class AddCommand<T> : ICommand, IParameterizedCommand
    {
        private ICustomCollection<T> _collection;
        private T _newObject;
        private Dictionary<string, Type> _fieldTypes;
        public string Format { get; set; }


        public AddCommand(ICustomCollection<T> collection, Dictionary<string, Type> fieldTypes)
        {
            _collection = collection;
            _fieldTypes = fieldTypes;
            _newObject = Activator.CreateInstance<T>();
        }

        public void Execute()
        {
            _collection.Add(_newObject);
            // Reset _newObject so this command can be used again
            _newObject = Activator.CreateInstance<T>();
        }

        public void SetParameters(string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                string[] parts = parameter.Split('=');
                if (parts.Length != 2)
                {
                    Console.WriteLine($"Invalid parameter format: {parameter}. Expected format: <field>=<value>");
                    continue;
                }

                string fieldName = parts[0];
                string fieldValueString = parts[1];

                if (!_fieldTypes.TryGetValue(fieldName, out var fieldType))
                {
                    Console.WriteLine($"Invalid field name: {fieldName}");
                    continue;
                }

                object fieldValue;
                if (fieldType == typeof(string))
                {
                    fieldValue = fieldValueString;
                }
                else if (fieldType == typeof(int))
                {
                    fieldValue = int.Parse(fieldValueString);
                }
                else if (fieldType == typeof(List<string>))
                {
                    fieldValue = fieldValueString.Split(',').ToList();
                }
                else
                {
                    Console.WriteLine($"Unsupported field type: {fieldType.Name}");
                    continue;
                }

                typeof(T).GetProperty(fieldName).SetValue(_newObject, fieldValue);
            }
        }

    }


}
