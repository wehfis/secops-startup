using Microsoft.EntityFrameworkCore;
using BLL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //    new User
            //    {
            //        Id = 1,
            //        Email = "William",
            //        Password = "sifjokasfp212"
            //    },
            //    new User
            //    {
            //        Id = 2,
            //        Email = "John",
            //        Password = "12312sadads"
            //    },
            //    new User
            //    {
            //        Id = 3,
            //        Email = "Alex",
            //        Password = "asjdgukah19091"
            //    },
            //    new User
            //    {
            //        Id = 4,
            //        Email = "Jane",
            //        Password = "sasfjguahs21"
            //    }
            //);
            //modelBuilder.Entity<Dialog>().HasData(
            //    new Dialog
            //    {
            //        Id = 100,
            //        SenderId = 1,
            //        RecipientId = 2
            //    },
            //    new Dialog
            //    {
            //        Id = 101,
            //        SenderId = 1,
            //        RecipientId = 3
            //    },
            //    new Dialog
            //    {
            //        Id = 102,
            //        SenderId = 1,
            //        RecipientId = 4
            //    },
            //    new Dialog
            //    {
            //        Id = 103,
            //        SenderId = 3,
            //        RecipientId = 4
            //    },
            //    new Dialog
            //    {
            //        Id = 104,
            //        SenderId = 3,
            //        RecipientId = 2
            //    }
            //);
            //modelBuilder.Entity<Message>().HasData(
            //    new Message
            //    {
            //        Id = 5000,
            //        Content = "Hi there John!",
            //        DialogId = 100,
            //        Time = new DateTime(2020, 3, 15, 7, 1,0)
            //    },
            //    new Message
            //    {
            //        Id = 5001,
            //        Content = "Hi there!",
            //        DialogId = 101,
            //        Time = new DateTime(2020, 3, 15, 7, 2, 0)
            //    },
            //    new Message
            //    {
            //        Id = 5002,
            //        Content = "Hi there!",
            //        DialogId = 102,
            //        Time = new DateTime(2020, 3, 15, 7, 3, 0)
            //    },
            //    new Message
            //    {
            //        Id = 5003,
            //        Content = "Hi there!",
            //        DialogId = 103,
            //        Time = new DateTime(2020, 3, 15, 7, 4, 0)
            //    },
            //    new Message
            //    {
            //        Id = 5004,
            //        Content = "Hi there!",
            //        DialogId = 104,
            //        Time = new DateTime(2020, 3, 15, 7, 5, 0)
            //    },
            //    new Message
            //    {
            //        Id = 5005,
            //        Content = "Hi there!",
            //        DialogId = 102,
            //        Time = new DateTime(2020, 3, 15, 7, 6, 0)
            //    },
            //    new Message
            //    {
            //        Id = 5006,
            //        Content = "Hi there!",
            //        DialogId = 104,
            //        Time = new DateTime(2020, 3, 15, 7, 7, 0)
            //    },
            //    new Message
            //    {
            //        Id = 5007,
            //        Content = "Hi there!",
            //        DialogId = 100,
            //        Time = new DateTime(2020, 3, 15, 7, 8, 0)
            //    }
            //);
        }
    }
}
