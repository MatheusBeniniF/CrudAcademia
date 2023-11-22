using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CrudApi.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            options.UseSqlite($"Data Source={System.IO.Path.Join(path, "academia.db")}");
        }
    }
}