﻿namespace Entity_Framework_practice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entity_Framework_practice.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Entity_Framework_practice.Models.CmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Entity_Framework_practice.Models.CmsContext context)
        {
            context.Employees.AddOrUpdate(
                 x => x.Id,
                 new Employee { Id = 1, Name = "David", Mobile = "0933-152667", Email = "david@gmail.com", Department = "總經理室", Title = "CEO" },
                 new Employee { Id = 2, Name = "Mary", Mobile = "0938-456889", Email = "mary@gmail.com", Department = "人事部", Title = "管理師" },
                 new Employee { Id = 3, Name = "Joe", Mobile = "0925-331225", Email = "joe@gmail.com", Department = "財務部", Title = "經理" },
                 new Employee { Id = 4, Name = "Mark", Mobile = "0935-863991", Email = "mark@gmail.com", Department = "業務部", Title = "業務員" },
                 new Employee { Id = 5, Name = "Rose", Mobile = "0987-335668", Email = "rose@gmail.com", Department = "資訊部", Title = "工程師" }
                 );

            context.Registers.AddOrUpdate(
                x => x.Id,
                new Register { Id = 1, Name = "奚江華", Nickname = "聖殿祭司", Password = "myPassword*", Email = "dotnetcool@gmail.com", City = 4, Gender = 1, Commutermode = "1", Comment = "Nothing", Terms = true }
                );
        }
    }
}
