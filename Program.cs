using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace laba5
{
    class Program
    {
        static Student[] ReadData(string fileName)
        {
            string[] FileInfo = File.ReadAllLines(fileName);
            Student[] ArrayOfStudent = new Student[FileInfo.Length];

            for (int i = 0; i < FileInfo.Length; i++)
            {
                ArrayOfStudent[i] = new Student(FileInfo[i]);
            }
            return ArrayOfStudent;
        }
        static void runMenu(Student[] studs)
        {
            var today = DateTime.Today;
            int students = 0;
            for (int i = 0; i < studs.Length; i++)
            {
                string[] mas = studs[i].dateOfBirth.Split(".");
                int day = Convert.ToInt32(mas[0]);
                int month = Convert.ToInt32(mas[1]);
                int year = Convert.ToInt32(mas[2]);
                var birthdate = new DateTime(year, month, day);
                var age = today.Subtract(birthdate).TotalDays;
                var years = (age / 365);
                Math.Round(years);
                if (years < 16)
                {
                    students += 1;
                    Console.WriteLine(" {0}  {1}  {2}  {3} {4} {5} {6} {7} {8} ", studs[i].surName, studs[i].firstName, studs[i].patronymic, studs[i].sex, studs[i].dateOfBirth, studs[i].mathematicsMark, studs[i].physicsMark, studs[i].informaticsMark, studs[i].scholarship);
                }
            }
            Console.WriteLine("Кiлькiсть студентiв молодше 16 рокiв - " + students);
        }
        static void Main(string[] args)
        {
            string path = @"D:\input.txt";
            Student[] studs = ReadData(path);
            runMenu(studs);
        }
    }
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        public Student(string lineWithAllData)
        {
            string[] linesWiThDataAboutOneStudent = lineWithAllData.Split(" ");
            this.surName = linesWiThDataAboutOneStudent[0];
            this.firstName = linesWiThDataAboutOneStudent[1];
            this.patronymic = linesWiThDataAboutOneStudent[2];
            this.sex = Convert.ToChar(linesWiThDataAboutOneStudent[3]);
            this.dateOfBirth = linesWiThDataAboutOneStudent[4];
            this.mathematicsMark = Convert.ToChar(linesWiThDataAboutOneStudent[5]);
            this.physicsMark = Convert.ToChar(linesWiThDataAboutOneStudent[6]);
            this.informaticsMark = Convert.ToChar(linesWiThDataAboutOneStudent[7]);
            this.scholarship = Convert.ToInt32(linesWiThDataAboutOneStudent[8]);
        }
    }
}
