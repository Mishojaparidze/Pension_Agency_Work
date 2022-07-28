using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain
{   
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int MonthlySalary { get; set; }
        public int Age { get; set; }
        public int Balance { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get; set; }

    }
}
