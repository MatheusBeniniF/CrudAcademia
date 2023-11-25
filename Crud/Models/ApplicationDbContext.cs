using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Crud.Models;

namespace CrudApi.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<UserInfo> UserInfo { get; set; } = null!;
        public DbSet<Ficha> Fichas { get; set; } = null!;
        public DbSet<ExercicioRecord> ExercicioRecords { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<RequerirNovaFicha> RequerirNovaFichas { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            options.UseSqlite($"Data Source={System.IO.Path.Join(path, "dumbFit2.db")}");
        }
    }
}