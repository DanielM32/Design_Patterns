using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Lab1OOD.CollectionAlgorithms;

namespace Lab1OOD
{
    class Program
    {
        static void Main(string[] args)
        {
            var rooms = new List<Room>
{
    new Room { Number = 107, Type = "lecture", Classes = new List<string> { "MD2", "RD", "WDK", "AC3" } },
    new Room { Number = 204, Type = "tutorials", Classes = new List<string> { "WDK", "AC3" } },
    new Room { Number = 21, Type = "lecture", Classes = new List<string> { "RD" } },
    new Room { Number = 123, Type = "laboratory", Classes = new List<string> { "RD", "WDK" } },
    new Room { Number = 404, Type = "lecture", Classes = new List<string> { "MD2", "WDK", "RD" } },
    new Room { Number = 504, Type = "tutorials", Classes = new List<string> { "MD2" } },
    new Room { Number = 73, Type = "laboratory", Classes = new List<string> { "AC3" } }
            };
            var classes = new List<Class>
            {
    new Class { Name = "Diabolical Mathematics 2", Code = "MD2", Duration = "2h", Teachers = new List<string> { "P2" }, Students = new List<string> { "S1", "S2", "S5" } },
    new Class { Name = "Routers descriptions", Code = "RD", Duration = "1h", Teachers = new List<string> { "P3" }, Students = new List<string> { "S3", "S4" } },
    new Class { Name = "Introduction to cables", Code = "WDK", Duration = "5h", Teachers = new List<string> { "P4", "P3" }, Students = new List<string> { "S1", "S2", "S3", "S4", "S5" } },
    new Class { Name = "Advanced Cooking 3", Code = "AC3", Duration = "3h", Teachers = new List<string> { "P5", "P1" }, Students = new List<string> { "S2", "S4", "S5" } }
};

            var teachers = new List<Teacher>
{
    new Teacher { Name = "Tomas", Surname = "Cherrmann", Rank = "MiB", Code = "P1", Classes = new List<string> { "AC3" } },
    new Teacher { Name = "Jon", Surname = "Tron", Rank = "TiB", Code = "P2", Classes = new List<string> { "MD2" } },
    new Teacher { Name = "William Joseph", Surname = "Blazkowicz", Rank = "GiB", Code = "P3", Classes = new List<string> { "RD", "WDK" } },
    new Teacher { Name = "Arkadiusz Amadeusz", Surname = "Kamiński", Rank = "KiB", Code = "P4", Classes = new List<string> { "WDK" } },
    new Teacher { Name = "Cooking", Surname = "Mama", Rank = "GiB", Code = "P5", Classes = new List<string> { "AC3" } }
};

            var students = new List<Student>
            {
    new Student { Name = "Robert", Surname = "Kielbica", Semester = 3, Code = "S1", Classes = new List<string> { "MD2", "WDK" } },
    new Student { Name = "Archibald Agapios", Surname = "Linux", Semester = 7, Code = "S2", Classes = new List<string> { "MD2", "WDK", "AC3" } },
    new Student { Name = "Angrboða", Surname = "Kára", Semester = 1, Code = "S3", Classes = new List<string> { "RD", "WDK" } },
    new Student { Name = "Olympos", Surname = "Andronikos", Semester = 5, Code = "S4", Classes = new List<string> { "RD", "WDK", "AC3" } },
    new Student { Name = "Mac Rhymes", Surname = "Pickuppicker", Semester = 6, Code = "S5", Classes = new List<string> { "MD2", "WDK", "AC3" } }

            };

            List<SecondaryStudent> secondarystudents = new List<SecondaryStudent>
            {
                new SecondaryStudent(1, "Robert", "Kielbica", "3", new List<string> { "MD2", "WDK" }),
                new SecondaryStudent(2, "Archibald Agapios", "Linux", "7", new List<string> { "MD2", "WDK", "AC3" }),
                new SecondaryStudent(3, "Angrboða", "Kára", "1", new List<string> { "RD", "WDK" }),
                new SecondaryStudent(4, "Olympos", "Andronikos", "5", new List<string> { "RD", "WDK", "AC3" }),
                new SecondaryStudent(5, "Mac Rhymes", "Pickuppicker", "6", new List<string> { "MD2", "WDK", "AC3" })
            };

            List<SecondaryTeacher> secondaryteachers = new List<SecondaryTeacher>
            {
                new SecondaryTeacher(1, "Tomas", "Cherrmann", "MiB", "P1", new List<string> { "AC3" }),
                new SecondaryTeacher(2, "Jon", "Tron", "TiB", "P2", new List<string> { "MD2" }),
                new SecondaryTeacher(3, "William Joseph", "Blazkowicz", "GiB", "P3", new List<string> { "RD", "WDK" }),
                new SecondaryTeacher(4, "Arkadiusz Amadeusz", "Kamiński", "KiB", "P4", new List<string> { "WDK" }),
                new SecondaryTeacher(5, "Cooking", "Mama", "GiB", "P5", new List<string> { "AC3" })
            };


            List<SecondaryRoom> secondaryrooms = new List<SecondaryRoom>
            {
                new SecondaryRoom(1, "107", "lecture", new List<string> { "MD2", "RD", "WDK", "AC3" }),
                new SecondaryRoom(2, "204", "tutorials", new List<string> { "WDK", "AC3" }),
                new SecondaryRoom(3, "21", "lecture", new List<string> { "RD" }),
                new SecondaryRoom(4, "123", "laboratory", new List<string> { "RD", "WDK" }),
                new SecondaryRoom(5, "404", "lecture", new List<string> { "MD2", "WDK", "RD" }),
                new SecondaryRoom(6, "504", "tutorials", new List<string> { "MD2" }),
                new SecondaryRoom(7, "73", "laboratory", new List<string> { "AC3" })
            };

            List<SecondaryClass> secondaryclasses = new List<SecondaryClass>
            {
                new SecondaryClass(1, "Diabolical Mathematics 2", "MD2", "2h", new List<string> { "P2" }, new List<string> { "S1", "S2", "S5" }),
                new SecondaryClass(2, "Routers descriptions", "RD", "1h", new List<string> { "P3" }, new List<string> { "S3", "S4" }),
                new SecondaryClass(3, "Introduction to cables", "WDK", "5h", new List<string> { "P4", "P3" }, new List<string> { "S1", "S2", "S3", "S4", "S5" }),
                new SecondaryClass(4, "Advanced Cooking 3", "AC3", "3h", new List<string> { "P5", "P1" }, new List<string> { "S2", "S4", "S5" })
            };


            List<ThirdRoom> thirdRooms = new List<ThirdRoom>
{
    new ThirdRoom { Number = 107, Type = "lecture", Classes = "MD2,RD,WDK,AC3" },
    new ThirdRoom { Number = 204, Type = "tutorials", Classes = "WDK,AC3" },
    new ThirdRoom { Number = 21, Type = "lecture", Classes = "RD" },
    new ThirdRoom { Number = 123, Type = "laboratory", Classes = "RD,WDK" },
    new ThirdRoom { Number = 404, Type = "lecture", Classes = "MD2,WDK,RD" },
    new ThirdRoom { Number = 504, Type = "tutorials", Classes = "MD2" },
    new ThirdRoom { Number = 73, Type = "laboratory", Classes = "AC3" },
};

            List<ThirdClass> thirdClasses = new List<ThirdClass>
{
    new ThirdClass { Name = "Diabolical Mathematics 2", Code = "MD2", Duration = 2, People = "P2$S1,S2,S5" },
    new ThirdClass { Name = "Routers descriptions", Code = "RD", Duration = 1, People = "P3$S3,S4" },
    new ThirdClass { Name = "Introduction to cables", Code = "WDK", Duration = 5, People = "P4,P3$S1,S2,S3,S4,S5" },
    new ThirdClass { Name = "Advanced Cooking 3", Code = "AC3", Duration = 3, People = "P5,P1$S2,S4,S5" }
};

            List<ThirdTeacher> thirdTeachers = new List<ThirdTeacher>
{
    new ThirdTeacher { Identity = "Cherrmann,Tomas", Rank = "MiB", Code = "P1", Classes = "AC3" },
    new ThirdTeacher { Identity = "Tron,Jon", Rank = "TiB", Code = "P2", Classes = "MD2" },
    new ThirdTeacher { Identity = "Blazkowicz,William,Joseph", Rank = "GiB", Code = "P3", Classes = "RD,WDK" },
    new ThirdTeacher { Identity = "Kaminski,Arkadiusz,Amadeusz", Rank = "KiB", Code = "P4", Classes = "WDK" },
    new ThirdTeacher { Identity = "Mama,Cooking", Rank = "GiB", Code = "P5", Classes = "AC3" }
};

            List<ThirdStudent> thirdStudents = new List<ThirdStudent>
{
    new ThirdStudent { Identity = "Kielbica,Robert", Semester = 3, Code = "S1", Classes = "MD2,WDK" },
    new ThirdStudent { Identity = "Linux,Archibald,Agapios", Semester = 7, Code = "S2", Classes = "MD2,WDK,AC3" },
    new ThirdStudent { Identity = "Kára,Angrboða", Semester = 1, Code = "S3", Classes = "RD,WDK" },
    new ThirdStudent { Identity = "Andronikos,Olympos", Semester = 5, Code = "S4", Classes = "RD,WDK,AC3" },
    new ThirdStudent { Identity = "Pickuppicker,Mac,Rhymes", Semester = 6, Code = "S5", Classes = "MD2,WDK,AC3" }
};


            //foreach (var student in students)
            //{
            //    Console.WriteLine($"Name: {student.Name} Surname:{student.Surname} Code:{student.Code} Semester:{student.Semester}");
            //    foreach (string a in student.Classes)
            //    {
            //        Console.WriteLine($"Class: {a}");
            //    }
            //    Console.WriteLine();
            //}

            //foreach (var secondarystudent in secondarystudents)
            //{
            //    Console.WriteLine($"Id: {secondarystudent.Id}");
            //    foreach (var kvp in secondarystudent.Data)
            //    {
            //        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            //    }
            //    Console.WriteLine();
            //}


            var thirdRoomAdapters = thirdRooms.Select(room => new ThirdRoomAdapter(room)).ToList();
            var thirdClassAdapters = thirdClasses.Select(cls => new ThirdClassAdapter(cls)).ToList();
            var thirdTeacherAdapters = thirdTeachers.Select(teacher => new ThirdTeacherAdapter(teacher)).ToList();
            var thirdStudentAdapters = thirdStudents.Select(student => new ThirdStudentAdapter(student)).ToList();



            //var roomAdapters = thirdRooms.Select(room => new ThirdRoomAdapter(room)).ToList();
            //foreach (var room in roomAdapters)
            //{
            //    Console.WriteLine($"Room Number: {room.Number}, Type: {room.Type}, Classes: {string.Join(", ", room.Classes)}");
            //}

            //Finder.PrintCoursesWithTwoNamedPeople(thirdRoomAdapters.Select(r => r as IRoom).ToList(),
            //                          thirdClassAdapters.Select(c => c as IClass).ToList(),
            //                          thirdTeacherAdapters.Select(t => t as ITeacher).ToList(),
            //                          thirdStudentAdapters.Select(s => s as IStudent).ToList());


            //test of secondary also
            //List<IRoom> rooms2 = secondaryrooms.Select(r => new RoomAdapter(r)).Cast<IRoom>().ToList();
            //List<IClass> classes2 = secondaryclasses.Select(c => new ClassAdapter(c)).Cast<IClass>().ToList();
            //List<ITeacher> teachers2 = secondaryteachers.Select(t => new TeacherAdapter(t)).Cast<ITeacher>().ToList();
            //List<IStudent> students2 = secondarystudents.Select(s => new StudentAdapter(s)).Cast<IStudent>().ToList();

            ////test of base
            //List<IRoom> roomsbase = rooms.OfType<IRoom>().ToList();
            //List<IClass> classesbase = classes.OfType<IClass>().ToList();
            //List<ITeacher> teachersbase = teachers.OfType<ITeacher>().ToList();
            //List<IStudent> studentsbase = students.OfType<IStudent>().ToList();

            ////base test
            //Finder.PrintCoursesWithTwoNamedPeople(roomsbase, classesbase, teachersbase, studentsbase);
            ////third test
            //Finder.PrintCoursesWithTwoNamedPeople(thirdRoomAdapters.Select(r => r as IRoom).ToList(),
            //                          thirdClassAdapters.Select(c => c as IClass).ToList(),
            //                          thirdTeacherAdapters.Select(t => t as ITeacher).ToList(),
            //                          thirdStudentAdapters.Select(s => s as IStudent).ToList());

            //Test with a room  TASK3

            //// Define a predicate to find lecture rooms
            //Func<Room, bool> isLectureRoom = r => r.Type == "lecture";

            //// Test the CountIf method on the rooms list
            //int lectureRoomsCount = CountIf(rooms.GetEnumerator(), isLectureRoom);
            //Console.WriteLine($"Count of lecture rooms: {lectureRoomsCount}");

            //// Test the Find method on the rooms list
            //Room firstLectureRoom = Find(rooms.GetEnumerator(), isLectureRoom);
            //Console.WriteLine($"First lecture room found: Room {firstLectureRoom.Number}");

            //// Define an action to print room information
            //Action<Room> printRoomInfo = r => Console.WriteLine($"Room {r.Number}: {r.Type}");

            //// Test the ForEach method on the rooms list
            //ForEach(rooms.GetEnumerator(), printRoomInfo);

            ////Same test but with a CustomCollection
            //Console.WriteLine("Here starts the fun part \n");

            Comparison<Room> roomComparison = (room1, room2) => room1.Number.CompareTo(room2.Number);

            ICustomCollection<Room> customrooms = new SortedArray<Room>(roomComparison);

            customrooms.Add(new Room { Number = 107, Type = "lecture", Classes = new List<string> { "MD2", "RD", "WDK", "AC3" } });
            customrooms.Add(new Room { Number = 204, Type = "tutorials", Classes = new List<string> { "WDK", "AC3" } });
            customrooms.Add(new Room { Number = 21, Type = "lecture", Classes = new List<string> { "RD" } });
            customrooms.Add(new Room { Number = 123, Type = "laboratory", Classes = new List<string> { "RD", "WDK" } });
            customrooms.Add(new Room { Number = 404, Type = "lecture", Classes = new List<string> { "MD2", "WDK", "RD" } });
            customrooms.Add(new Room { Number = 504, Type = "tutorials", Classes = new List<string> { "MD2" } });
            customrooms.Add(new Room { Number = 73, Type = "laboratory", Classes = new List<string> { "AC3" } });

            ICustomCollection<Class> customclass = new CustomLinkedList<Class>();
            customclass.Add(new Class { Name = "Diabolical Mathematics 2", Code = "MD2", Duration = "2h", Teachers = new List<string> { "P2" }, Students = new List<string> { "S1", "S2", "S5" } });
            customclass.Add(new Class { Name = "Routers descriptions", Code = "RD", Duration = "1h", Teachers = new List<string> { "P3" }, Students = new List<string> { "S3", "S4" } });
            customclass.Add(new Class { Name = "Introduction to cables", Code = "WDK", Duration = "5h", Teachers = new List<string> { "P4", "P3" }, Students = new List<string> { "S1", "S2", "S3", "S4", "S5" } });
            customclass.Add(new Class { Name = "Advanced Cooking 3", Code = "AC3", Duration = "3h", Teachers = new List<string> { "P5", "P1" }, Students = new List<string> { "S2", "S4", "S5" } });
            
            //// Test the CountIf method on the rooms list
            //int customlectureRoomsCount = CountIf(customrooms.GetForwardIterator(), isLectureRoom);
            //Console.WriteLine($"Count of lecture rooms: {customlectureRoomsCount}");

            //// Test the Find method on the rooms list
            //Room customfirstLectureRoom = Find(customrooms.GetForwardIterator(), isLectureRoom);
            //Console.WriteLine($"First lecture room found: Room {customfirstLectureRoom.Number}");

            //// Test the ForEach method on the rooms list
            //ForEach(customrooms.GetForwardIterator(), printRoomInfo);

            //Task4

            var roomCollection = customrooms;
            var classCollection = customclass;

            var commandManager = new CommandManager();
            commandManager.RegisterCommand("list room", new ListCommand<Room>(roomCollection, commandManager.roomfieldTypes));
            commandManager.RegisterCommand("list class", new ListCommand<Class>(classCollection, commandManager.classFieldTypes));
            commandManager.RegisterCommand("find class", new FindCommand<Class>(classCollection, new Dictionary<string, Predicate<Class>>(), commandManager.classFieldTypes));
            commandManager.RegisterCommand("find room", new FindCommand<Room>(roomCollection, new Dictionary<string, Predicate<Room>>(), commandManager.roomfieldTypes));
            commandManager.RegisterCommand("exit", new ExitCommand());
            commandManager.RegisterCommand("add room", new AddCommand<Room>(roomCollection, commandManager.roomfieldTypes));
            commandManager.RegisterCommand("add class", new AddCommand<Class>(classCollection, commandManager.classFieldTypes));


            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();
                commandManager.ExecuteCommand(command);
            }
        }
    }

}