using Microsoft.EntityFrameworkCore;
using StudentList.Application.Interfaceses;
using StudentList.Domain.Entities;
using StudentList.Infrastructure.Interceptors;
using System.Reflection;

namespace StudentList.Infrastructure.Context
{
    public class StudentDbContext(AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor) : DbContext, IStudentDbContext
    {
        public StudentDbContext(
      DbContextOptions<StudentDbContext> options,
      AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
      : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }
    }
}
