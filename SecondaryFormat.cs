using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1OOD
{
    public class SecondaryStudent
    {
        public int Id { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public SecondaryStudent(int id, string name, string surname, string semester, List<string> classes)
        {
            Id = id;
            Data = new Dictionary<string, string>
        {
            { "Name", name },
            { "Surname", surname },
            { "Semester", semester },
            { "Classes.Size()", classes.Count.ToString() }
        };

            for (int i = 0; i < classes.Count; i++)
            {
                Data[$"Classes[{i}]"] = classes[i];
            }
        }
    }

    public class SecondaryTeacher
    {
        public int Id { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public SecondaryTeacher(int id, string name, string surname, string rank, string code, List<string> classes)
        {
            Id = id;
            Data = new Dictionary<string, string>
        {
            { "Name", name },
            { "Surname", surname },
            { "Rank", rank },
            { "Code", code },
            { "Classes.Size()", classes.Count.ToString() }
        };

            for (int i = 0; i < classes.Count; i++)
            {
                Data[$"Classes[{i}]"] = classes[i];
            }
        }
    }

    public class SecondaryRoom
    {
        public int Id { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public SecondaryRoom(int id, string number, string type, List<string> classes)
        {
            Id = id;
            Data = new Dictionary<string, string>
        {
            { "Number", number },
            { "Type", type },
            { "Classes.Size()", classes.Count.ToString() }
        };

            for (int i = 0; i < classes.Count; i++)
            {
                Data[$"Classes[{i}]"] = classes[i];
            }
        }
    }


    public class SecondaryClass
    {
        public int Id { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public SecondaryClass(int id, string name, string code, string duration, List<string> teachers, List<string> students)
        {
            Id = id;
            Data = new Dictionary<string, string>
        {
            { "Name", name },
            { "Code", code },
            { "Duration", duration },
            { "Teachers.Size()", teachers.Count.ToString() },
            { "Students.Size()", students.Count.ToString() }
        };

            for (int i = 0; i < teachers.Count; i++)
            {
                Data[$"Teachers[{i}]"] = teachers[i];
            }

            for (int i = 0; i < students.Count; i++)
            {
                Data[$"Students[{i}]"] = students[i];
            }
        }
    }
}
