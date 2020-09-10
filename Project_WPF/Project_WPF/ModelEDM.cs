namespace Project_WPF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelEDM : DbContext
    {
        public ModelEDM()
            : base("name=ModelEDM")
        {
        }

        public virtual DbSet<Autorisation> Autorisations { get; set; }
        public virtual DbSet<Comission> Comissions { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Questionn> Questions { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<WrongAnswer> WrongAnswers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autorisation>()
                .Property(e => e.login)
                .IsFixedLength();

            modelBuilder.Entity<Autorisation>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.dep_name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.dep_abvr)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Storages)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WrongAnswers)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questionn>()
                .HasMany(e => e.Tests)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.Questions_1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questionn>()
                .HasMany(e => e.Tests1)
                .WithRequired(e => e.Question1)
                .HasForeignKey(e => e.Questions_2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questionn>()
                .HasMany(e => e.Tests2)
                .WithRequired(e => e.Question2)
                .HasForeignKey(e => e.Questions_3)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questionn>()
                .HasMany(e => e.Tests3)
                .WithRequired(e => e.Question3)
                .HasForeignKey(e => e.Questions_4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(e => e.Storages)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.title_name)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.title_abvr)
                .IsUnicode(false);

            modelBuilder.Entity<Title>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Title)
                .WillCascadeOnDelete(false);
        }
    }
}
