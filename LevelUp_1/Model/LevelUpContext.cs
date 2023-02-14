using Microsoft.EntityFrameworkCore;

namespace LevelUp_1.Model
{
    public class LevelUpContext : DbContext
    {
        public LevelUpContext()
        {
        }

        public LevelUpContext(DbContextOptions<LevelUpContext> options)
            : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Domain> Domain { get; set; }
        public virtual DbSet<demo> demo { get; set; }
        public virtual DbSet<QnA> QnA { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder) =>
            OptionsBuilder.UseSqlServer("Server=LAPTOP-7J3QHB7N; Database=LevelUp; Trust Server Certificate=true; Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id, "UserId");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.First_Name).HasColumnName("First_Name");
                entity.Property(e => e.Last_Name).HasColumnName("Last_Name");
                entity.Property(e => e.User_Password).HasColumnName("User_Password");
                entity.Property(e => e.User_Mailid).HasColumnName("User_Mailid");
                entity.Property(e => e.User_ContactNo).HasColumnName("User_ContactNo");
                entity.Property(e => e.User_Country).HasColumnName("User_Country");
            });
            modelBuilder.Entity<Domain>(entity =>
            {
                entity.HasIndex(e => e.Id, "questionId");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Domain_Name).HasColumnName("domain_name");
            });
            modelBuilder.Entity<demo>(entity =>
            {
                entity.HasIndex(e => e.Id, "questionId");
                entity.Property(e => e.Id).HasColumnName("questionId");
                entity.Property(e => e.DomainId).HasColumnName("domain_id");
                entity.Property(e => e.Question).HasColumnName("questions");
            });
            modelBuilder.Entity<QnA>(entity =>
            {
                entity.HasIndex(e => e.Id, "QId");
                entity.Property(e => e.Id).HasColumnName("QId");
                entity.Property(e => e.Question).HasColumnName("Question");
                entity.Property(e => e.Option1).HasColumnName("Option1");
                entity.Property(e => e.Option2).HasColumnName("Option2");
                entity.Property(e => e.Option3).HasColumnName("Option3");
                entity.Property(e => e.Option4).HasColumnName("Option4");
                entity.Property(e => e.CorrectAns).HasColumnName("CorrectAnswer");
            });
        }
    }
}
