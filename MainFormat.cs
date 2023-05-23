using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1OOD
{
        public class Room: IRoom
        {
            public int Number { get; set; }
            public string Type { get; set; }
            public List<string> Classes { get; set; }


    }

        public class Class: IClass
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string Duration { get; set; }
            public List<string> Teachers { get; set; }
            public List<string> Students { get; set; }

    }

        public class Teacher: ITeacher
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Rank { get; set; }
            public string Code { get; set; }
            public List<string> Classes { get; set; }

    }

        public class Student:IStudent
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Semester { get; set; }
            public string Code { get; set; }
            public List<string> Classes { get; set; }
        
    }


}
