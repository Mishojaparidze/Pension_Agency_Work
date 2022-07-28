namespace Pension_Agency_Test.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int MonthlySalary { get; set; }
        public int Age { get; set; }
        public int Balance { get; set; }
        public string RoleId { get; set; }
    }
}
