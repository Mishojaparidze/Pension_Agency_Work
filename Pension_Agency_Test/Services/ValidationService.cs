﻿using Api.Data;
using FluentValidation;
using Pension_Agency_Test.Models;
using System.Linq;

namespace Pension_Agency_Test.Services
{
    
        public class ValidationService : AbstractValidator<UserModel>
        {
            UserContext _context;
            public ValidationService(UserContext context)
            {
                _context = context;
                RuleFor(UserRegisterModel => UserRegisterModel.Name).Length(1, 20).NotNull().WithMessage("Name can not be empty and should contain 1-20 elements");
                RuleFor(UserRegisterModel => UserRegisterModel.Surname).Length(1, 20).NotNull().WithMessage("Surname can not be empty and should contain 1-20 elements");
                RuleFor(UserRegisterModel => UserRegisterModel.Username).Length(1, 20).NotNull().WithMessage("UserName can not be empty and should contain 1-20 elements").
                    Must(distinctUserName).WithMessage("Username already exists");
                RuleFor(UserRegisterModel => UserRegisterModel.Password).Length(8, 30).NotNull().WithMessage("UserName can not be empty and should contain 1-20 elements")
                    .MinimumLength(8).WithMessage("Your password must be minimum 8 characters");
                RuleFor(UserRegisterModel => UserRegisterModel.MonthlySalary).GreaterThan(499).WithMessage("Your salary should be more or equal to 500");
                RuleFor(RegistrationModel => RegistrationModel.Age).GreaterThan(17).WithMessage("You must be more than 18 to apply for a loan").LessThan(80).WithMessage
                    ("Your age should be less than 80 to apply for a loan");
            }
            private bool distinctUserName(string userName)
            {
                try
                {
                    var userNameCheck = _context.Users.Where(x => x.Username.ToUpper() == userName.ToUpper()).FirstOrDefault();
                    if (userNameCheck == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
}
