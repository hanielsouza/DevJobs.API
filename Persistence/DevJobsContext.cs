using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Persistence
{
    public class DevJobsContext : DbContext
    {
        public DevJobsContext(DbContextOptions<DevJobsContext> options) : base(options)
        {
        }

        //Representa a Entidade e retorna os dados
        public DbSet<JobVacancy> JobVacancies { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configuração das classes para transformar em tabelas

            builder.Entity<JobVacancy>(e =>
            {
                e.HasKey(jv => jv.Id);

                e.HasMany(jv => jv.Applications)
                    .WithOne()
                    .HasForeignKey(ja => ja.IdJobVacancy)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<JobApplication>(e =>
            {
                e.HasKey(ja => ja.Id);
            });
        }
    }
}
