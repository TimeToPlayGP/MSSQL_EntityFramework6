namespace dboEF6.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AutoEntities : DbContext
    {
        public AutoEntities()
            : base("name=AutoConnection")
        {
        }

        public virtual DbSet<companyCustomer> companyCustomers { get; set; }
        public virtual DbSet<companyPerformer> companyPerformers { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<projectManager> projectManagers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<companyCustomer>()
                .HasMany(e => e.projects)
                .WithRequired(e => e.companyCustomer)
                .HasForeignKey(e => e.id_comC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<companyPerformer>()
                .HasMany(e => e.projects)
                .WithRequired(e => e.companyPerformer)
                .HasForeignKey(e => e.id_comP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.projects)
                .WithMany(e => e.employees)
                .Map(m => m.ToTable("projectEmployee").MapLeftKey("id_comP").MapRightKey("id_proj"));

            modelBuilder.Entity<project>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<projectManager>()
                .HasMany(e => e.projects)
                .WithRequired(e => e.projectManager)
                .HasForeignKey(e => e.id_projM)
                .WillCascadeOnDelete(false);
        }
    }
}
