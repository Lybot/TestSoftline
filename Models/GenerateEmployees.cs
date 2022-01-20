using System;

namespace TestTask.Models
{
    public static class GenerateEmployees
    {
        private static readonly string[] names = { "Vasya", "Petya", "Keshka", "Masha" };
        private static readonly string[] lastNames = { "Sidorov", "Petrov", "Ivanov" };
        private static readonly string[] middleNames = { "Vasilievich", "Petrovich", "Innokenteevich" };
        private static readonly string[] positions = { "Director", "Programmer", "Analyzer", "Accountant", "Cleaner" };
        private static Employee GetEmployee(Random random)
        {
            var date = new DateTime((DateTime.Now - new DateTime(random.Next(18, 66), random.Next(1, 13), random.Next(1, 29))).Ticks);
            Employee employee = new Employee()
            {
                FirstName = names[random.Next(names.Length)],
                LastName = lastNames[random.Next(lastNames.Length)],
                MiddleName = middleNames[random.Next(middleNames.Length)],
                Birthday = date,
                Position = positions[random.Next(positions.Length)],
                IsMaternity = random.Next(2) == 1 ? true : false
            };
            return employee;
        }
        public static Employee[] GetEmployees(int count)
        {
            var random = new Random();
            var employees = new Employee[count];
            for (int i = 0; i < count; i++)
            {
                employees[i] = GetEmployee(random);
            }
            return employees;
        }
    }
}
