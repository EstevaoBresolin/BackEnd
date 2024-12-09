using BackEnd.Classes;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BackEnd
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Voluntario> Voluntarios { get; set; }

        public DbSet<Instituicao> Instituicao { get; set; }


        //dotnet ef migrations add InitialCreate

        //dotnet ef database update
    }

}
