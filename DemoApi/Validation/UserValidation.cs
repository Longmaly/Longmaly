using DemoApi.Command;
using DemoApi.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApi
{
    public class UserValidation
    {
        public (bool, string) CreateUserValidation(CreateUserCommand request, DemoApiDbContext ctx)
        {
            if (string.IsNullOrEmpty(request.FirstName))
            {
                return (false, "First Name can not be empty.");
            }
            return (true, string.Empty);
        }
        public (bool, string) UpdateUserValidation(Guid id, DemoApiDbContext ctx)
        {
            var user = ctx.UserModels.Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return (false, "User not found.");
            }
            return (true, string.Empty);
        }

        public (bool, string) DeleteUserValidation(Guid id, DemoApiDbContext ctx)
        {
            var user = ctx.UserModels.Where(u => u.Id == id).FirstOrDefault();
            if (user == null)
            {
                return (false, "User not found.");
            }
            return (true, string.Empty);
        }
    }
}
