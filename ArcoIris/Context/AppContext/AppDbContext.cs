using Microsoft.EntityFrameworkCore;

namespace Database.Context.AppContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Prova> Provas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=arcoiris.db");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alternativa>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Questao>()
                .HasKey(q => q.Id);

            modelBuilder.Entity<Alternativa>()
                .HasOne(a => a.Questao)
                .WithMany(q => q.Alternativas)
                .HasForeignKey(a => a.QuestaoId);
        }
    }
}
