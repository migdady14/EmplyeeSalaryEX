using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using EmployeeSalaryAlphaQuery.Entities;

namespace EmployeeSalaryAlphaQuery
{
    class Program
    {
        static void Main(string[] args)
        {

            //string path = @"C:\Users\Dev\Documents\DevStudy\Repository\_ExerciseSource\Employee.csv";

            /* CSV file:
            Maria,maria@gmail.com,3200.00
            Alex,alex@gmail.com,1900.00
            Marcos,marco@gmail.com,1700.00
            Bob,bob@gmail.com,3500.00
            Anna,anna@gmail.com,2800.00
            */

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] ar = sr.ReadLine().Split(',');
                    employees.Add(new Employee(ar[0], ar[1], double.Parse(ar[2], CultureInfo.InvariantCulture)));
                }
            }

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var emailBySal = employees.Where(e => e.Salary > salary).Select(e => e.Email);
            Console.WriteLine("Email of people whose salary is more than " + salary.ToString("F2", CultureInfo.InvariantCulture));
            foreach (string e in emailBySal)
            {
                Console.WriteLine(e);
            }

            var salaryM = employees.Where(e => e.Name[0] == 'M').Select(e => e.Salary).Aggregate((a, b) => a + b);
            Console.WriteLine("Sum of salary of people whose name start with 'M': " + salaryM.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
