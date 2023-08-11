using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingMert.Entity.Concrete;

namespace WeddingMert.DataAccess.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {         
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Gallery>Galleries{ get; set; }
        public DbSet<Event>Events{ get; set; }
        public DbSet<Contact>Contacts{ get; set; }
    }
}
