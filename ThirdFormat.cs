using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1OOD
{
    public class ThirdRoom
    {
        public int Number { get; set; }
        public string Type { get; set; }
        public string Classes { get; set; }
    }

    public class ThirdClass
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Duration { get; set; }
        public string People { get; set; }
    }

    public class ThirdTeacher
    {
        public string Identity { get; set; }
        public string Rank { get; set; }
        public string Code { get; set; }
        public string Classes { get; set; }
    }

    public class ThirdStudent
    {
        public string Identity { get; set; }
        public int Semester { get; set; }
        public string Code { get; set; }
        public string Classes { get; set; }
    }

}
