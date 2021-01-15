using BLOG_Project.EntityLayer.Entities.Concrete;
using BLOG_Project.MapLayer.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_Project.DataAccessLayer.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=NIHOO;Database=BLOG_PROJECTDB;uid=nihatcan;pwd=123;";
                                                  
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)//We sent mapping operations to database
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new LikeMap());

            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }





    }
}
