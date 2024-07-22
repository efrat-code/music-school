using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MusicSchoole.Model;
using static System.Net.Mime.MediaTypeNames;
using static MusicSchoole.Configuration.MusicSchoolConfiguration;
using static MusicSchoole.Model.Student;
namespace MusicSchoole.Service
{
    internal static class MusicSchoolServic
    {
        public static void CreateXmlIfNotExists()
        {
            if (!File.Exists(musicSchoolPath))
            {
                XDocument document = new ();
                XElement musicSchool = new(@"music-school");
                document.Add(musicSchool);
                document.Save(musicSchoolPath);
            }
        }

        public static void InsertClassRoom(string classRoomName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? musicSchool = document.Descendants("music-school")
                 .FirstOrDefault();
            if (musicSchool == null) return;

            XElement classroom = new(
                "classroom",
                new XAttribute("name", classRoomName));

            musicSchool.Add(classroom);
            document.Save(musicSchoolPath);
        }

        public static void AddTeacher(string classRoomName  ,string teacherName) 
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("classroom")
                 .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            //XElement? classRoom = musicSchool?.Descendants(classRoomName)
            //.FirstOrDefault();
            if (classRoomName == null) { return; }

            XElement teacher = new("teacher",
                new XAttribute("name", teacherName));
            classRoom?.Add(teacher);
            document.Save(musicSchoolPath);

        }
        public static void AddStudent(string classRoomName, string studentName ,string instrument)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("classroom")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            if (classRoomName == null) return;

            XElement studentname = new(
                "student",
                new XAttribute("name", studentName));
            //studentname.Add(studentName);
            //
            XElement student = new(
              "student",
              new XAttribute("name", studentName),
              new XElement("instrument", instrument)
              );
            classRoom?.Add(student);

            classRoom?.Add(studentname);
            document.Save(musicSchoolPath);

            
        }
        private static XElement ConvertStudentToElement(Student student) =>
            new("student",
            new XAttribute("name", student.name),
            new XElement("insrument", student.instrument.Name));


        public static void AddManyStudents(string classRoomName,params Student[] studentsName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("classroom")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            if (classRoomName == null) return;

            List<XElement> studentlist = studentsName.Select(ConvertStudentToElement).ToList();
            classRoom?.Add(studentlist);
            document.Save(musicSchoolPath);
        }

        public static void UpdateInstrument(string studentName,Instrument instrument)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? student = document.Descendants("student")
                .FirstOrDefault(room => room.Attribute("name")?.Value == studentName);
            if (student == null) { return; }
            student.SetElementValue("instrument", instrument.Name);
            document.Save(musicSchoolPath);

        }

        public static void ReplaceStudent(string studentName,Student student)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? newstudent = document.Descendants("student")
                .FirstOrDefault(room => room.Attribute("name")?.Value == studentName);
            if (newstudent == null) { return; }
            newstudent.ReplaceWith(ConvertStudentToElement(student));
        }
    }




    class Program
    {



        public static Func<List<string>, bool> words = (list) =>
            list.Any(str => str.StartsWith("a")); // where str[0] ==  select str == "")

        public static Func<List<string> ,bool> IsEmpty = (list) =>
            list.Any(string.IsNullOrEmpty);

        public static Func<List<string>, bool> witha = (list) =>
            list.All(str => str.Contains("a"));

        public static Func<List<string>, List<string>>touper = (list) =>
            list.Select(str => str.ToUpper()).ToList();

        public static Func<List<string>, List<string>>touper2 = (list) =>
            (from str in list select str.ToUpper()).ToList();

        public static Func<List<string>, List<string>> bigfrom3 = (list) =>
            list.Where(str => str.Length > 3 ).ToList();

        public static Func<List<string>, List<string>> bigfrom32 = (list) =>
            (from str in list select (str.Length > 3).ToString()).ToList();

        public static Func<List<string>, string> mystring = (list) =>
            list.Aggregate("" ,(add, next)=> $"{add} {next}");

        public static Func<List<string>, int> mystringi = (list) =>
            list.Aggregate(0, (add, next) => add + next.Length);

        public static Func<List<string>, List<int>> mor3 = (list) =>
            list.Aggregate(new List<int>(), (add, next) => [..add ,next.Length]);







    }

}
