﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        public static void PrintList(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine(numbers.Sum());
            Console.ReadLine();
            //TODO: Print the Average of numbers

            Console.WriteLine(numbers.Average());
            Console.ReadLine();

            //TODO: Order numbers in ascending order and print to the console

            var sortNumbers = numbers.OrderBy(number => number);
            PrintList(sortNumbers);
            Console.ReadLine();

            //TODO: Order numbers in descending order and print to the console

            var descNumbers = numbers.OrderByDescending(number => number);
            PrintList(descNumbers);
            Console.ReadLine();

            //TODO: Print to the console only the numbers greater than 6

            var moreThanSix = numbers.Where(number => number > 6);
            PrintList(moreThanSix);
            Console.ReadLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            var shortList = numbers.OrderBy(number => number).ToList();
            PrintList(shortList.Take(4));
            Console.ReadLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            shortList[3] = 33;
            PrintList(shortList.OrderByDescending(number => number));
            Console.ReadLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var startWithCorS = employees.Where(employee => employee.FirstName.ElementAt(0) == 'C' || employee.FirstName.ElementAt(0) == 'S').OrderBy(Employee => Employee.FirstName);
            foreach (var employee in startWithCorS)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.ReadLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var over26 = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);
            foreach (var employee in over26)
            {
                Console.WriteLine(employee.FullName, ", ", employee.Age);
            }
            Console.ReadLine();
            

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var needExp = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            Console.WriteLine(needExp.Sum(employee => employee.YearsOfExperience));
            Console.ReadLine();

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine(needExp.Average(employee => employee.YearsOfExperience));
            Console.ReadLine();
            //TODO: Add an employee to the end of the list without using employees.Add()
            var employeesJuly = employees.Append(new Employee("John", "Doe", 20, 1));
            foreach (var employee in employeesJuly)
            {
                Console.Write(employee.FirstName);
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
