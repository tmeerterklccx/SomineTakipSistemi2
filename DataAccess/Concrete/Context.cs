using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=77.245.159.27\\MSSQLSERVER2019;database=devmertc_;User ID=devmertcom; Password=qweasdzxc38!!Xx;TrustServerCertificate=True");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<GetContact> getContacts { get; set; }
        public DbSet<MainTop> MainTops { get; set; }
        public DbSet<MoreAskQuestion> MoreAskQuestions { get; set; }
        public DbSet<OurInfo> ourInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TestiMonial> TestiMonials { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
