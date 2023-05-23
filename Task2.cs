using Lab1OOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1OOD
{
    public class Finder
    {
        public static void PrintCoursesWithTwoNamedPeople(
            List<IRoom> rooms, List<IClass> classes, List<ITeacher> teachers, List<IStudent> students)
        {
            
            var studentsWithTwoNames = students.Where(s => HasTwoNames(s.Name)).ToList();
            var teachersWithTwoNames = teachers.Where(t => HasTwoNames(t.Name)).ToList();

            var targetClasses = classes.Where(c => c.Students.Any(s => studentsWithTwoNames.Select(x => x.Code).Contains(s)) &&
                                                   c.Teachers.Any(t => teachersWithTwoNames.Select(x => x.Code).Contains(t))).ToList();


            foreach (var targetClass in targetClasses)
            {
                Console.WriteLine($"Course Name: {targetClass.Name}, Code: {targetClass.Code}, Duration: {targetClass.Duration}");
                Console.WriteLine("Students:");
                foreach (var studentCode in targetClass.Students)
                {
                    var student = students.FirstOrDefault(s => s.Code == studentCode);
                    Console.WriteLine($"- Name: {student.Name}, Code: {student.Code}");
                }
                Console.WriteLine("Teachers:");
                foreach (var teacherCode in targetClass.Teachers)
                {
                    var teacher = teachers.FirstOrDefault(t => t.Code == teacherCode);
                    Console.WriteLine($"- Name: {teacher.Name}, Code: {teacher.Code}");
                }
                Console.WriteLine();
            }
        }
        private static bool HasTwoNames(string name)
        {
            return name.Contains(",") || name.Contains(" ");
        }
    }
}

