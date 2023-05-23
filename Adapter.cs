using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1OOD
{

    public interface IRoom
    {
        int Number { get; }
        string Type { get; }
        List<string> Classes { get; }
    }

    public interface IClass
    {
        string Name { get; }
        string Code { get; }
        string Duration { get; }
        List<string> Teachers { get; }
        List<string> Students { get; }
    }

    public interface ITeacher
    {
        string Name { get; }
        string Surname { get; }
        string Rank { get; }
        string Code { get; }
        List<string> Classes { get; }
    }

    public interface IStudent
    {
        string Name { get; }
        string Surname { get; }
        int Semester { get; }
        string Code { get; }
        List<string> Classes { get; }
    }
    public class RoomAdapter : IRoom
    {
        private readonly SecondaryRoom _room;

        public RoomAdapter(SecondaryRoom room)
        {
            _room = room;
        }

        public int Number => int.Parse(_room.Data["Number"]);
        public string Type => _room.Data["Type"];
        public List<string> Classes => Enumerable.Range(0, int.Parse(_room.Data["Classes.Size()"]))
                                                 .Select(i => _room.Data[$"Classes[{i}]"]).ToList();
    }

    public class ClassAdapter : IClass
    {
        private readonly SecondaryClass _class;

        public ClassAdapter(SecondaryClass cls)
        {
            _class = cls;
        }

        public string Name => _class.Data["Name"];
        public string Code => _class.Data["Code"];
        public string Duration => _class.Data["Duration"];
        public List<string> Teachers => Enumerable.Range(0, int.Parse(_class.Data["Teachers.Size()"]))
                                                  .Select(i => _class.Data[$"Teachers[{i}]"]).ToList();
        public List<string> Students => Enumerable.Range(0, int.Parse(_class.Data["Students.Size()"]))
                                                  .Select(i => _class.Data[$"Students[{i}]"]).ToList();
    }

    public class TeacherAdapter : ITeacher
    {
        private readonly SecondaryTeacher _teacher;

        public TeacherAdapter(SecondaryTeacher teacher)
        {
            _teacher = teacher;
        }

        public string Name => _teacher.Data["Name"];
        public string Surname => _teacher.Data["Surname"];
        public string Rank => _teacher.Data["Rank"];
        public string Code => _teacher.Data["Code"];
        public List<string> Classes => Enumerable.Range(0, int.Parse(_teacher.Data["Classes.Size()"]))
                                                 .Select(i => _teacher.Data[$"Classes[{i}]"]).ToList();
    }

    public class StudentAdapter : IStudent
    {
        private readonly SecondaryStudent _student;

        public StudentAdapter(SecondaryStudent student)
        {
            _student = student;
        }

        public string Name => _student.Data["Name"];
        public string Surname => _student.Data["Surname"];
        public int Semester => int.Parse(_student.Data["Semester"]);
        public string Code => _student.Data["Code"];
        public List<string> Classes => Enumerable.Range(0, int.Parse(_student.Data["Classes.Size()"]))
                                                 .Select(i => _student.Data[$"Classes[{i}]"]).ToList();
    }

    //Representation 3 

    public class ThirdRoomAdapter : IRoom
    {
        private ThirdRoom _thirdRoom;

        public ThirdRoomAdapter(ThirdRoom thirdRoom)
        {
            _thirdRoom = thirdRoom;
        }

        public int Number
        {
            get => _thirdRoom.Number;
            set => _thirdRoom.Number = value;
        }

        public string Type
        {
            get => _thirdRoom.Type;
            set => _thirdRoom.Type = value;
        }

        public List<string> Classes
        {
            get => _thirdRoom.Classes.Split(',').ToList();
            set => _thirdRoom.Classes = string.Join(",", value);
        }

    }

    public class ThirdClassAdapter : IClass
    {
        private ThirdClass _thirdClass;

        public ThirdClassAdapter(ThirdClass thirdClass)
        {
            _thirdClass = thirdClass;
        }

        public string Name
        {
            get => _thirdClass.Name;
            set => _thirdClass.Name = value;
        }

        public string Code
        {
            get => _thirdClass.Code;
            set => _thirdClass.Code = value;
        }

        public string Duration
        {
            get => _thirdClass.Duration.ToString() + "h";
            set => _thirdClass.Duration = int.Parse(value.TrimEnd('h'));
        }

        public List<string> Teachers
        {
            get => _thirdClass.People.Split('$')[0].Split(',').ToList();
            set => _thirdClass.People = string.Join(",", value) + "$" + string.Join(",", Students);
        }

        public List<string> Students
        {
            get => _thirdClass.People.Split('$')[1].Split(',').ToList();
            set => _thirdClass.People = string.Join(",", Teachers) + "$" + string.Join(",", value);
        }

    }

    public class ThirdTeacherAdapter : ITeacher
    {
        private ThirdTeacher _thirdTeacher;

        public ThirdTeacherAdapter(ThirdTeacher thirdTeacher)
        {
            _thirdTeacher = thirdTeacher;
        }

        public string Name
        {
            get
            {
                var nameParts = _thirdTeacher.Identity.Split(',');
                return string.Join(",", nameParts.Skip(1));
            }
            set
            {
                var nameParts = _thirdTeacher.Identity.Split(',');
                _thirdTeacher.Identity = nameParts[0] + "," + value + ",";
            }
        }

        public string Surname
        {
            get => _thirdTeacher.Identity.Split(',')[0];
            set
            {
                var nameParts = _thirdTeacher.Identity.Split(',');
                var newName = string.Join(",", nameParts.Skip(1));
                _thirdTeacher.Identity = value + "," + newName + ",";
            }
        }


        public string Rank
        {
            get => _thirdTeacher.Rank;
            set => _thirdTeacher.Rank = value;
        }

        public string Code
        {
            get => _thirdTeacher.Code;
            set => _thirdTeacher.Code = value;
        }

        public List<string> Classes
        {
            get => _thirdTeacher.Classes.Split(',').ToList();
            set => _thirdTeacher.Classes = string.Join(",", value);
        }


    }

    public class ThirdStudentAdapter : IStudent
    {
        private ThirdStudent _thirdStudent;

        public ThirdStudentAdapter(ThirdStudent thirdStudent)
        {
            _thirdStudent = thirdStudent;
        }


        public string Name
        {
            get
            {
                var nameParts = _thirdStudent.Identity.Split(',');
                return string.Join(",", nameParts.Skip(1));
            }
            set
            {
                var nameParts = _thirdStudent.Identity.Split(',');
                _thirdStudent.Identity = nameParts[0] + "," + value + ",";
            }
        }

        public string Surname
        {
            get => _thirdStudent.Identity.Split(',')[0];
            set
            {
                var nameParts = _thirdStudent.Identity.Split(',');
                var newName = string.Join(",", nameParts.Skip(1));
                _thirdStudent.Identity = value + "," + newName + ",";
            }
        }



        public int Semester
        {
            get => _thirdStudent.Semester;
            set => _thirdStudent.Semester = value;
        }

        public string Code
        {
            get => _thirdStudent.Code;
            set => _thirdStudent.Code = value;
        }

        public List<string> Classes
        {
            get => _thirdStudent.Classes.Split(',').ToList();
            set => _thirdStudent.Classes = string.Join(",", value);
        }


    }
}