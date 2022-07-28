using Api.Data;
using Api.Domain;
using Pension_Agency_Test.Helpers;
using Pension_Agency_Test.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pension_Agency_Test.Services
{
    public interface IAdminService
    {
        User RegisterUser(UserModel registerData);
        User GiveUserRole(GiveUserRoleModel model);
        public User ModifyUserInfo(ModifyUserModel modify);
        public User ModifyUserRole(GiveUserRoleModel modifyRole);
        public User GetUserByRole(string Role);
    }
    public class AdminService: IAdminService
    {

        private UserContext _context;

        public AdminService(UserContext context)
        {
            _context = context;
        }

        public User GiveUserRole(GiveUserRoleModel model)
        {
            var tempUser = _context.Users.Find(model.Id);
            tempUser.RoleId = model.Id;

            _context.Users.Update(tempUser);
            _context.SaveChanges();
            return tempUser;
        }
        public User RegisterUser(UserModel registerData)
        {
            User user = new User();
            user.Name = registerData.Name;
            user.Surname = registerData.Surname;
            user.Username = registerData.Username;
            user.Password =HashSettings.HashPassword(registerData.Password);
            user.Balance =registerData.Balance;
            user.Age = registerData.Age;
            user.RoleId=registerData.Id;
            user.MonthlySalary = registerData.MonthlySalary;
            _context.Users.Add(user);
            return user;
        }

        public User ModifyUserInfo(ModifyUserModel modify)
        {
            var tempUser = new User() { Id = modify.Id };
            if (modify.Name != null)
            {
                tempUser.Name = modify.Name;
            }
            else
            {
                tempUser.Name = _context.Users.Where(tempUser => tempUser.Id == modify.Id).FirstOrDefault().Name;
            }

            if (modify.Surname != null)
            {
                tempUser.Surname = modify.Surname;
            }
            else
            {
                tempUser.Surname = _context.Users.Where(tempUser => tempUser.Id == modify.Id).FirstOrDefault().Surname;
            }

            if (modify.Username != null)
            {
                tempUser.Username = modify.Username;
            }
            else
            {
                tempUser.Username = _context.Users.Where(tempUser => tempUser.Id == modify.Id).FirstOrDefault().Username;
            }

            if (modify.Balance != 0)
            {
                tempUser.Balance = modify.Balance;
            }
            else
            {
                tempUser.Balance = _context.Users.Where(tempUser => tempUser.Id == modify.Id).FirstOrDefault().Balance;
            }

            if (modify.Age <=0)
            {
                tempUser.Age = modify.Age;
            }
            else
            {
                tempUser.Age = _context.Users.Where(tempUser => tempUser.Id == modify.Id).FirstOrDefault().Age;
            }
            if (modify.MonthlySalary <= 0)
            {
                tempUser.MonthlySalary = modify.MonthlySalary;
            }
            else
            {
                tempUser.MonthlySalary = _context.Users.Where(tempUser => tempUser.Id == modify.Id).FirstOrDefault().MonthlySalary;
            }
            
            return tempUser;
        }

        public User ModifyUserRole(GiveUserRoleModel modifyRole)
        {
            var tempUser = new User() { Id = modifyRole.Id };
            if (modifyRole.Role != null)
            {
                tempUser.Name = modifyRole.Role;
            }
            else
            {
                tempUser.Role = _context.Users.Where(tempUser => tempUser.Id == modifyRole.Id).FirstOrDefault().Role;
            }
            return tempUser;
        }

        public User GetUserByRole(string Role)
        {
            if (Role != null)
            {
                var user = _context.Users.FirstOrDefault(x => x.Role.Role==Role);
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
