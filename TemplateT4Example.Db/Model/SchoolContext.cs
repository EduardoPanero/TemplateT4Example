namespace TemplateT4Example.Db.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=SchoolContext")
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);
            modelBuilder.Entity<Student>()
                .Property(e => e.Username)
                .IsUnicode(false);
            modelBuilder.Entity<Student>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Classes)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentID");
                    cs.MapLeftKey("ClassID");
                    cs.ToTable("StudentsClasses");
                });

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Email)
                .IsUnicode(false);
            modelBuilder.Entity<Teacher>()
                .Property(e => e.Username)
                .IsUnicode(false);
            modelBuilder.Entity<Teacher>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsUnicode(false);
            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Classes)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<Class>()
                .Property(e => e.Location)
                .IsUnicode(false);
        }

    }
    
}