using MalihaPolyTex.Academy.Entities;
using Microsoft.EntityFrameworkCore;

namespace MalihaPolyTex.Academy.Contexts
{
    public class AcademyDbContext : DbContext, IAcademyDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public AcademyDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder )
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring( dbContextOptionsBuilder );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentRegistration>()
                .HasKey(cs => new { cs.CourseId, cs.StudentId });

            builder.Entity<StudentRegistration>()
                .HasOne(cs => cs.Course)
                .WithMany(cs => cs.EnrollStudents)
                .HasForeignKey(cs => cs.CourseId);

            builder.Entity<StudentRegistration>()
                .HasOne(cs => cs.Student)
                .WithMany(cs => cs.EnrollCourses)
                .HasForeignKey(cs => cs.StudentId);

            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}