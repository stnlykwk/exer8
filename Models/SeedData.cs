using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using exercise_8.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace exercise_8.Models
{
    public class SeedData
    {
        public static void Initialize(UserContext context)
        {
            // var dbConnection = context.Database.GetDbConnection();
            // if (dbConnection.State != ConnectionState.Open) dbConnection.Open();

            //  Look for any users.
            if (context.User.Any())
            {
                return; // DB has been seeded
            }

            context.User.AddRange(
                new User
                {
                    firstName = "Seelan",
                    lastName = "Dan",
                    email = "dskjlf@fdkjs.com",
                    phoneNum = "432-983-9834",
                    notes = "none"
                },
                new User
                {
                    firstName = "Mutlun",
                    lastName = "Yie",
                    email = "dgf@bd.com",
                    phoneNum = "231-456-2546",
                    notes = "abcdef"
                },
                new User
                {
                    firstName = "Diula",
                    lastName = "Sing",
                    email = "342qsd@23sda.com",
                    phoneNum = "124-698-5246",
                    notes = "heheh"
                });

            context.SaveChanges();

            // Checking for users
            var users = context.User.ToList();
            Console.WriteLine($"\n\nFound {users.Count} users");
        }
    }
}
