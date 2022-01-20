namespace TestTask.Models
{
    public class EmployeeVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Birthday { get; set; }
        public string IsMaternity { get; set; }
        public string Text { get; set; }
        public EmployeeVm(Employee employee)
        {
            Id = employee.Id;
            Name = $"{employee.LastName} {employee.FirstName} {employee.MiddleName}";
            Position = employee.Position;
            Birthday = employee.Birthday.ToShortDateString();
            IsMaternity = employee.IsMaternity ? "+" : "-";
            Text = string.IsNullOrEmpty(employee.Text) ? "Empty" : employee.Text;
        }
    }
}
