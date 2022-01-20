using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public DateTime Birthday { get; set; } 
        public bool IsMaternity { get; set; }
        public string Text { get; set; }
    }
}
