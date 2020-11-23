using CourierManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourierManagementSystem.Repositories
{
    public class UserRepository : Repository<User>
    {
        public User Validate(User user)
        {
            return GetAll().Where<User>(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
        }

        public void verifyUser(int id)
        {
            User user =  Get(id);
            user.Status = 1;
            Update(user);
        }

        public void blockUser(int id)
        {
            User user = Get(id);
            user.Status = 2;
            Update(user);
        }
        public void UnblockUser(int id)
        {
            User user = Get(id);
            user.Status = 1;
            Update(user);
        }
    } 
}