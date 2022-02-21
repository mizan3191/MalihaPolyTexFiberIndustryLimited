using MalihaPolyTex.Institute.Entities;
using Microsoft.EntityFrameworkCore;

namespace MalihaPolyTex.Institute.Contexts
{
    public class MalihaPolyTexDbContext : DbContext, IMalihaPolyTexDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MalihaPolyTexDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(s => s.Students)
                .WithOne(d => d.Department);

            modelBuilder.Entity<StudentRegistration>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentRegistration>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.EnrolledStudents)
                .HasForeignKey(fk => fk.CourseId);

            modelBuilder.Entity<StudentRegistration>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.EnrolledCourses)
                .HasForeignKey(fk => fk.StudentId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<StudentRegistration> Registration { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}