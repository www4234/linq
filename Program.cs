using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentReportApp
{
    // Класс, описывающий модель студента
    public class Student
    {
        public string Name { get; set; }
        public string GroupName { get; set; }
        public int Age { get; set; }
        public double AverageGrade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Исходный тестовый список студентов
            List<Student> students = new List<Student>
            {
                new Student { Name = "Иван", GroupName = "ИВТ-21", Age = 20, AverageGrade = 4.5 },
                new Student { Name = "Мария", GroupName = "ИВТ-21", Age = 19, AverageGrade = 4.8 },
                new Student { Name = "Пётр", GroupName = "ИВТ-21", Age = 21, AverageGrade = 4.2 },
                
                new Student { Name = "Анна", GroupName = "ЭК-22", Age = 18, AverageGrade = 4.9 },
                new Student { Name = "Сергей", GroupName = "ЭК-22", Age = 22, AverageGrade = 3.9 },
                
                new Student { Name = "Елена", GroupName = "ПИ-20", Age = 22, AverageGrade = 5.0 },
                new Student { Name = "Алексей", GroupName = "ПИ-20", Age = 23, AverageGrade = 4.7 }
            };

            // 2. Один основной LINQ-запрос для группировки и расчета статистики
            var groupReport = students
                .GroupBy(s => s.GroupName)
                .Select(g => new
                {
                    GroupName = g.Key,
                    Count = g.Count(),
                    AverageAge = g.Average(s => s.Age),
                    MaxAverageGrade = g.Max(s => s.AverageGrade)
                });

            // 3. Вывод детального отчета на экран
            Console.WriteLine("================ ДЕТАЛЬНЫЙ ОТЧЕТ ПО ГРУППАМ ================\n");

            foreach (var group in groupReport)
            {
                Console.WriteLine($"Группа: {group.GroupName}");
                Console.WriteLine($"  • Количество студентов: {group.Count}");
                Console.WriteLine($"  • Средний возраст:    {group.AverageAge:F1} лет");
                Console.WriteLine($"  • Максимальный балл:  {group.MaxAverageGrade:F2}");
                Console.WriteLine(new string('-', 45));
            }
        }
    }
}
