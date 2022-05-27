using JsonNet.PrivateSettersContractResolvers;
using MC.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Repo
{
    public static class Seeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 5,
                   UserName = "duc2",
                   Email = "William",
                   Password = "Shakespeare",
                   AddedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   IPAddress = "2"

               }, new User
               {

                   Id = 6,
                   UserName = "duc3",
                   Email = "William",
                   Password = "Shakespeare",
                   AddedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   IPAddress = "3",
               }
           );


            modelBuilder.Entity<UserProfile>().HasData(
                 new UserProfile
                 {
                     Id = 5,
                     LastName = "vo",
                     FirstName = " duc",
                     Address = " quang nam",
                     AddedDate = DateTime.Now,
                     ModifiedDate = DateTime.Now,
                     IPAddress = "5"
                 }, new UserProfile
                 {
                     Id = 6,
                     LastName = "vo",
                     FirstName = " duc",
                     Address = " quang nam",
                     AddedDate = DateTime.Now,
                     ModifiedDate = DateTime.Now,
                     IPAddress = "3"
                 }
            );
        }
    }
}
