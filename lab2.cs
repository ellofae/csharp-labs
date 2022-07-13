using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        public enum Education { Specialist, Вachelor, SecondEducation };
        public enum Frequency { Weekly, Monthly, Yearly };


        interface IDateAndCopy
        {
            object DeepCopy();
            DateTime Date { get; set; }
        }

        class Test
        {
            public string SubjectName { get; set; }
            public bool PassedOrNot { get; set; }

            public object DeepCopy() { return 0; }
            public DateTime Date { get; set; }

            public Test()
            {
                SubjectName = "None";
                PassedOrNot = false;
            }
            public Test(string subjectName, bool passedOrNot)
            {
                SubjectName = subjectName;
                PassedOrNot = passedOrNot;
            }

            public override string ToString()
            {
                return ($"Subject: {SubjectName}, passed? : {PassedOrNot}");
            }
        }


        class Exam : IDateAndCopy
        {
            public string SubjectName { get; set; }
            public int SubjectMark { get; set; }
            public DateTime ExamDate { get; set; }

            public Exam()
            {
                SubjectName = "None";
                SubjectMark = 0;
                ExamDate = DateTime.MinValue;
            }
            public Exam(string subjectName, int subjectMark, DateTime examDate)
            {
                SubjectName = subjectName;
                SubjectMark = subjectMark;
                ExamDate = examDate;
            }
            
            public override string ToString()
            {
                return ($"Subject: {SubjectName}, Mark: {SubjectMark}, Exam Date: {ExamDate}");
            }

            // Interface realization
            public object DeepCopy() { return 0; }
            public DateTime Date { get; set; }
        }

        class Person : IDateAndCopy
        {
            protected string firstName;
            protected string lastName;
            protected DateTime birthDate;

            // Properties
            public string GetFirstName
            {
                get { return firstName; }
            }
            public string GetLastName
            {
                get { return lastName; }
            }
            public System.DateTime GetBirthDate
            {
                get { return birthDate; }
                set { birthDate = value; }
            }

            // Constructors
            public Person()
            {
                firstName = "None";
                lastName = "None";
                birthDate = new DateTime(1991, 10, 10);
            }
            public Person(string firstName, string lastName, System.DateTime birthDate)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.birthDate = birthDate;
            }

            // Methods

            public override string ToString()
            {
                return ($"{firstName} {lastName}\nDate of birth: {birthDate}");
            }

            public virtual string ToShortString()
            {
                return ($"{firstName} {lastName}");
            }

            // Interface realization
            public virtual object DeepCopy() { return 0; }
            public DateTime Date { get; set; }

            // Additional methods

            public override bool Equals(object obj)
            {
                if ((obj.GetType().Name).ToString() == "Person")
                {
                    Person new_obj = (Person)obj;
                    if ((this.firstName == new_obj.firstName) && (this.lastName == new_obj.lastName) && (this.birthDate == new_obj.birthDate))
                        return true;
                    else
                        return false;
                } else
                {
                    Console.WriteLine("not correct data type");
                    return false;
                }
            }
        }

        class Student : Person, IDateAndCopy
        {
            Education degree;
            int groupNumber;
            ArrayList testList;
            ArrayList examList;

            // Constructors
            public Student()
            {
                degree = new Education();
                examList = new ArrayList();
                testList = new ArrayList();
                groupNumber = 0;
            }
            public Student(Person personInfo, Education deg, int num)
            {
                firstName = personInfo.GetFirstName;
                lastName = personInfo.GetLastName;
                birthDate = personInfo.GetBirthDate;

                degree = deg;
                groupNumber = num;
                examList = new ArrayList();
                testList = new ArrayList();
            }

            // Properties
            public Education Degree
            {
                get { return degree; }
                set { degree = value; }
            }
            public int GroupNumber
            {
                get { return groupNumber; }
                set
                {
                    if ((value > 599) || (value <= 100))
                        throw new Exception();
                    else
                        groupNumber = value;
                }
            }
            public double AverageScore
            {
                get
                {
                    double total = 0.0;
                    foreach (Exam exam in examList)
                        total += exam.SubjectMark;
                    total = total / examList.Count;
                    return total;
                }
            }

            public ArrayList ExamListAccession
            {
                get
                {
                    Console.WriteLine("\nExam List:");
                    foreach (Exam exam in examList)
                        Console.WriteLine(exam.ToString());
                    return examList;
                }
            }

            public ArrayList TestListAccession
            {
                get
                {
                    Console.WriteLine("\nTest List:");
                    foreach (Test test in testList)
                        Console.WriteLine(test.ToString());
                    return testList;
                }
            }


            //Indexers
            public bool this[Education edu]
            {
                get
                {
                    if (this.degree == edu)
                        return true;
                    else
                        return false;
                }
            }

            // Methods
            public void AddExamsByArray(params Exam[] exams)
            {
                examList.AddRange(exams);
            }

            public void AddTestsByArray(params Test[] tests)
            {
                testList.AddRange(tests);
            }

            public void Display()
            {
                Console.WriteLine($"{firstName} {lastName}, Degree: {Degree}, Group Number: {GroupNumber}, Average Score: {AverageScore}");
                Console.WriteLine("List of exams:");
                foreach (Exam exam in examList)
                    Console.WriteLine(exam.ToString());
            }

            public override string ToString()
            {
                return ($"{firstName} {lastName}, Degree: {Degree}, Group Number: {GroupNumber}, Average Score: {AverageScore}");
            }

            public override string ToShortString()
            {
                return ($"{firstName} {lastName}, Average Score: {AverageScore}");
            }

            //Interface realization
            public override object DeepCopy() { return 0; }
            public new DateTime Date { get; set; }

        }

        

        static void Main(string[] args)
        {
            Student test_student = new Student(new Person("Elliot", "Murray", DateTime.MaxValue), Education.Вachelor, 60);

            Exam e1 = new Exam("English", 4, DateTime.MinValue);
            Exam e2 = new Exam("Math", 5, DateTime.MaxValue);
            Exam e3 = new Exam("Geometry", 4, DateTime.MinValue);

            Test t1 = new Test("Engenering", true);
            Test t2 = new Test("Applied Math", true);
            Test t3 = new Test("Computer Science", true);
            Test t4 = new Test("Programming", true);

            test_student.AddExamsByArray(new Exam[] {e1, e2, e3});
            test_student.AddTestsByArray(new Test[] { t1, t2, t3, t4 });

            string info = test_student.ToString();
            Console.WriteLine(info);

            Console.WriteLine(test_student.ExamListAccession);
            Console.WriteLine(test_student.TestListAccession);
        }

    }
}
