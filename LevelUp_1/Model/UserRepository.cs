using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;

namespace LevelUp_1.Model
{
    [EnableCors("CORSPolicy")]
    public class UserRepository
    {
        
        internal async static Task<List<User>> GetUsersAsync()
        {
            using (var db = new LevelUpContext())
            {
                return await db.Users.ToListAsync();
            }
        }
        internal async static Task<bool> SignUp(User user)
        {
            using (var db = new LevelUpContext())
            {
                try
                {
                    await db.Users.AddAsync(user);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<User> Login(string mailId,string password)
        {
            using (var db = new LevelUpContext())
            {
                return await db.Users
                    .FirstOrDefaultAsync(user => (user.User_Mailid == mailId)
                    && (user.User_Password == password));
            }
        }

        internal async static Task<List<Domain>> GetDomains()
        {
            using (var db = new LevelUpContext())
            {
                return await db.Domain.ToListAsync();
            }
        }

    }
}
