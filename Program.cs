using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentsLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exempeldata
            List<Student> studenter = new List<Student>
            {
                new Student { Id = 1, Namn = "Anna", Alder = 19, Klass = "A", Poang = 85 },
                new Student { Id = 2, Namn = "Bertil", Alder = 22, Klass = "B", Poang = 72 },
                new Student { Id = 3, Namn = "Cecilia", Alder = 20, Klass = "A", Poang = 91 },
                new Student { Id = 4, Namn = "David", Alder = 24, Klass = "C", Poang = 64 },
                new Student { Id = 5, Namn = "Eva", Alder = 19, Klass = "B", Poang = 85 },
                new Student { Id = 6, Namn = "Felix", Alder = 21, Klass = "A", Poang = 77 },
                new Student { Id = 7, Namn = "Gustav", Alder = 23, Klass = "C", Poang = 58 },
                new Student { Id = 8, Namn = "Hanna", Alder = 20, Klass = "B", Poang = 95 }
            };

            Console.WriteLine("LINQ-ÖVNINGAR MED STUDENTER\n");

            PrintOut("Över 20 år:", studenter.Where(student => student.Alder > 20));
            PrintOut("Över 80 poäng:", studenter.Where(student => student.Poang > 80));

            PrintOut("Bara namn:", studenter.Select(student => student.Namn));
            var data = from student in studenter
                       select new
                       {
                           Namn = student.Namn,
                           Poang = student.Poang
                       };

            Console.WriteLine($"Namn och poäng:");

            foreach (var element in data)
            {
                Console.WriteLine($"\t{element.Namn}, {element.Poang}");
            }

            Console.WriteLine();

            PrintOut("Sorterad efter ålder:", studenter.OrderBy(student => student.Alder));
            PrintOut("Sorterad efter poäng, fallande:", studenter.OrderByDescending(student => student.Poang));

            PrintOut("Antal studenter:", studenter.Count());
            PrintOut("Antal studenter i klass A:", studenter.Where(student => student.Klass.Equals("A")).Count());

            PrintOut("De tre första studenterna:", studenter.Take(3));
            PrintOut("De två högsta poängen: ", studenter.OrderByDescending(student => student.Poang).Take(2).Select(student => student.Poang));

            PrintOut("Unika klassnamn:", studenter.DistinctBy(student => student.Klass).Select(student => student.Klass));
            PrintOut("Unika Åldrar:", studenter.DistinctBy(student => student.Alder).Select(student => student.Alder));

            PrintOut("Finns student med 100 poäng:", studenter.Any(student => student.Poang == 100));
            PrintOut("Har alla minst 50 poäng:", studenter.All(student => student.Poang >= 50));

            PrintOut("Första studenten i klass B:", studenter.FirstOrDefault(student => student.Klass.Equals("B")));
            PrintOut("Sista studenten i listan:", studenter.Last());
            PrintOut("Student med ID 4:", studenter.SingleOrDefault(student => student.Id == 4));

            PrintOut("Studenter grupperade efter klass:","Klass", studenter.GroupBy(student => student.Klass));
            PrintOut("Student namn grupperade efter klass:", "Klass", studenter.Select(student => (student.Klass, student.Namn)).GroupBy(student => student.Klass));

            PrintOut("Totalt antal poäng:", studenter.Sum(student => student.Poang));
            PrintOut("Medelpoäng:", studenter.Average(student => student.Poang));
            PrintOut("Högsta poäng:", studenter.Max(student => student.Poang));
            PrintOut("Lägsta poäng:", studenter.Min(student => student.Poang));

            Console.WriteLine();
            Console.WriteLine("Tryck valfri tangent för att avsluta");
            Console.ReadKey();
        }

        private static void PrintOut(string prefix, double data)
        {
            Console.WriteLine($"{prefix} {data}");

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, string secondPrefix, IEnumerable<IGrouping<string, (string Klass, string Namn)>> enumerable)
        {
            Console.WriteLine($"{prefix}");

            foreach (var element in enumerable)
            {
                Console.WriteLine($"\t{secondPrefix}: {element.Key}");
                foreach (var student in element)
                {
                    Console.WriteLine($"\t\t{student.Namn}");
                }
            }

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, string secondPrefix, IEnumerable<IGrouping<string, Student>> enumerable)
        {
            Console.WriteLine($"{prefix}");

            foreach (var element in enumerable)
            {
                Console.WriteLine($"\t{secondPrefix}: {element.Key}");
                foreach(var student in element)
                {
                    Console.WriteLine($"\t\t{student}");
                }
            }

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, bool value)
        {
            var text = value ? "Ja" : "Nej";
            Console.WriteLine($"{prefix} {text}");

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, IEnumerable<Student> students)
        {
            Console.WriteLine($"{prefix}");

            foreach (Student student in students)
            {
                Console.WriteLine($"\t{student}");
            }

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, IEnumerable<string> data)
        {
            Console.WriteLine($"{prefix}");

            foreach (string element in data)
            {
                Console.WriteLine($"\t{element}");
            }

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, IEnumerable<int> data)
        {
            Console.WriteLine($"{prefix}");

            foreach (int element in data)
            {
                Console.WriteLine($"\t{element}");
            }

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, int data)
        {
            Console.WriteLine($"{prefix} {data}");

            Console.WriteLine();
        }

        private static void PrintOut(string prefix, Student? student)
        {
            if (student is not null)
            {
                Console.WriteLine($"{prefix} {student}");
            }
            else
            {
                Console.WriteLine($"{prefix} Ingen");
            }

            Console.WriteLine();
        }
    }
}
