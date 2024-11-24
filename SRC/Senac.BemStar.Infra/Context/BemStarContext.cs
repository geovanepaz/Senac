using Microsoft.EntityFrameworkCore;
using Senac.BemStar.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Senac.BemStar.Infra.Context
{
    public class BemStarContext : DbContext
    {
        public BemStarContext(DbContextOptions<BemStarContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("AlunosTestes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DataNascimento).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(150);
            });
        }
    }
}
