namespace Frontend.ApiModel
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IDNumber { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateOnly? HireDate { get; set; }

        public string Position { get; set; }
    }
}
