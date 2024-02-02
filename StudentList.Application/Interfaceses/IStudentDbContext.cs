using Microsoft.EntityFrameworkCore;
using StudentList.Domain.Entities;

namespace StudentList.Application.Interfaceses
{
    public interface IStudentDbContext
    {
        DbSet<Student> Students { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
