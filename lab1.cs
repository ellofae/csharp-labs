using System;

namespace Program
{
    class Program
    {
        public enum Education { Specialist, Вachelor, SecondEducation };
        public enum Frequency { Weekly, Monthly, Yearly };
        public enum TimeFrame { Year, TwoYears, Long };

        class Exam
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
            public void Display()
            {
                Console.WriteLine($"Subject: {SubjectName}, Mark: {SubjectMark}, Exam Date: {ExamDate}");
            }

            public override string ToString()
            {
                return ($"Subject: {SubjectName}, Mark: {SubjectMark}, Exam Date: {ExamDate}");
            }
        }

        class Person
        {
            string firstName;
            string lastName;
            System.DateTime birthDate;

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
        }

        class Student
        {
            Person studentInfo;
            Education degree;
            Exam[] passedExams;
            int groupNumber;
            int indxOfExams;

            // Constructors
            public Student()
            {
                studentInfo = new Person();
                degree = new Education();
                passedExams = new Exam[3]; // 3 exams for example as a default number of them
                groupNumber = 0;
            }
            public Student(Person stdInfo, Education deg, int num)
            {
                studentInfo = stdInfo;
                degree = deg;
                groupNumber = num;
                passedExams = new Exam[3];
            }

            // Properties
          
            public Person StudentInfo
            {
                get { return studentInfo; }
                set { studentInfo = value; }
            }
            public Education Degree
            {
                get { return degree; }
                set { degree = value; }
            }
            public int GroupNumber
            {
                get { return groupNumber; }
                set { groupNumber = value; }
            }
            public double AverageScore
            {
                get
                {
                    double total = 0.0;
                    for (int i = 0; i < passedExams.Length; i++)
                        total += Convert.ToDouble(passedExams[i].SubjectMark);
                    total = total / passedExams.Length;
                    return total;
                }
            }
            //Indexers
            public bool this [Education edu]
            {
                get
                {
                    if (this.degree == edu)
                        return true;
                    else
                        return false;
                }
            }
            public Exam this [Index i]
            {
                get { return passedExams[i]; }
                set { passedExams[i] = value; }
            }

            
            // Methods
            public void AddExamsByArray(params Exam[] exams)
            {
                for(int i = 0; i < passedExams.Length; i++)
                    passedExams[i] = exams[i];
            }
            public void AddExamsByOne(Exam e)
            {
                passedExams[indxOfExams++] = e;
            }

            public void Display()
            {
                Console.WriteLine($"{StudentInfo.ToString()}, Degree: {Degree}, Group Number: {GroupNumber}, Average Score: {AverageScore}\nExams passed:\n");
                for (int i = 0; i < passedExams.Length; i++)
                {
                    passedExams[i].Display();
                }

            }
            public override string ToString()
            {
                return ($"{StudentInfo.ToString()}, Degree: {Degree}, Group Number: {GroupNumber}, Average Score: {AverageScore}, \nExams:\n{passedExams[0]}\n{passedExams[1]}\n{passedExams[2]}\n");
            }

            public virtual string ToShortString()
            {
                return ($"{StudentInfo.ToString()}, Degree: {Degree}, Group Number: {GroupNumber}, Average Score: {AverageScore}");
            }

        }

        class Article
        {
            public Person AuthorInfo { get; set; }
            public string Title { get; set; }
            public double Rating { get; set; }

            public Article()
            {
                AuthorInfo = new Person();
                Title = "None";
                Rating = 0;
            }
            public Article(Person info, string title, double rating)
            {
                AuthorInfo = info;
                Title = title;
                Rating = rating;
            }

            public override string ToString()
            {
                return ($"Name: {AuthorInfo}, Title: {Title}, Rating: {Rating}\n");
            }
        }

        class Magazine
        {
            string magazineTitle;
            Frequency periodOfPublicity;
            DateTime releaseDate;
            int amountOfPublications;
            Article[] listOfArticles;

            // Constructions
            public Magazine()
            {
                magazineTitle = "None";
                periodOfPublicity = new Frequency();
                releaseDate = DateTime.MinValue;
                amountOfPublications = 0;
                listOfArticles = new Article[3]; // 5 articles in each magazine
            }

            public Magazine(string title, Frequency period, DateTime release, int amount)
            {
                magazineTitle = title;
                periodOfPublicity = period;
                releaseDate = release;
                amountOfPublications = amount;
                listOfArticles = new Article[3];
            }

            // Properties
            public string MagazineTitle
            {
                get { return magazineTitle; }
                set { magazineTitle = value; }
            }
            public Frequency PeriodOfPublicity
            {
                get { return periodOfPublicity; }
                set { periodOfPublicity = value; }
            }
            public DateTime ReleaseDate
            {
                get { return releaseDate; }
                set { releaseDate = value; }
            }
            public int AmountOfPublications
            {
                get { return amountOfPublications; }
                set { amountOfPublications = value; }
            }
            public Article[] Articles
            {
                get
                {
                    for (int i = 0; i < listOfArticles.Length; i++)
                        Console.WriteLine(listOfArticles[i]);
                    Console.WriteLine();
                    return listOfArticles;
                }
            }

            public double AverageRating
            {
                get
                {
                    double total = 0;
                    for (int i = 0; i < listOfArticles.Length; i++)
                        total += listOfArticles[i].Rating;
                    total = total / Convert.ToDouble(listOfArticles.Length);
                    return total;
                }
            }

            //Indexers
            public bool this[Frequency period]
            {
                get
                {
                    if (this.periodOfPublicity == period)
                        return true;
                    else
                        return false;
                }
            }

            // Methods
            public void AddArticles(params Article[] arr)
            {
                for (int i = 0; i < listOfArticles.Length; i++)
                    listOfArticles[i] = arr[i];
            }

            public override string ToString()
            {
                return ($"Title: {magazineTitle}, Period of publicity: {periodOfPublicity}, Release date: {releaseDate}\nAmount of Publications: {amountOfPublications}, Average rating: {AverageRating}\nList of Articles: {Articles}");
            }

            public string ToShortString()
            {
                return ($"Title: {magazineTitle}, Period of publicity: {periodOfPublicity}, Release date: {releaseDate}\nAmount of Publications: {amountOfPublications}, Average rating: {AverageRating}");
            }
        }

        public static void Main()
        {
            Student s = new Student(new Person("Elliot", "Marlow", DateTime.MaxValue), Education.Вachelor, 5001);
            Exam e1 = new Exam("English", 4, DateTime.MinValue);
            Exam e2 = new Exam("Math", 5, DateTime.MaxValue);
            Exam e3 = new Exam("Geometry", 4, DateTime.MinValue);

            Exam[] ArrayOfExams = new Exam[] { e1, e2, e3 };
            s.AddExamsByArray(ArrayOfExams);
            string test = s.ToString();
            Console.WriteLine(test);


            Article a1 = new Article(new Person("Hiao", "Majuka", DateTime.MinValue), "Ghost Taken", 9.85);
            Article a2 = new Article(new Person("John", "Doile", DateTime.MaxValue), "Town of Morok", 7.48);
            Article a3 = new Article(new Person("Marely", "Johnson", DateTime.MinValue), "Fallen Bridge", 8.74);

            Magazine m = new Magazine("Stories of Famous", Program.Frequency.Monthly, DateTime.MaxValue, 7560);
            m.AddArticles(new Article[] { a1, a2, a3});

            string info = m.ToString();
            Console.WriteLine(info);
            
            //s.Display();

            /*
            Index[] test = new Index[] {0, 1, 2};
            s[test[0]] = e1;
            s[test[1]] = e2;
            s[test[2]] = e3;
            */

            /*
            s.AddExamsByOne(e1);
            s.AddExamsByOne(e2);
            s.AddExamsByOne(e3);
            */


            // Arrays declaration
            /*
                int[] oneDementionalArray = new int[5];
                int[,] twoDementionalArray = new int[3,2];
                int[,,] threeDementionalArray = new int[3, 2, 2];
                int[][] jaggedArrayOfArrays = new int[3][];

                jaggedArrayOfArrays[0] = new int[4] { 1, 2, 3, 4 };
                jaggedArrayOfArrays[1] = new int[3] { 1, 2, 3};
                jaggedArrayOfArrays[2] = new int[6] { 1, 2, 3, 4, 5, 6};
             */

        }
    }
}
