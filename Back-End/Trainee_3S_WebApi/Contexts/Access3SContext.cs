using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Trainee_3S_WebApi.Domains;

namespace Trainee_3S_WebApi.Contexts;

public partial class Access3SContext : DbContext
{
    public Access3SContext()
    {
    }

    public Access3SContext(DbContextOptions<Access3SContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcessoEspaco> AcessoEspacos { get; set; }

    public virtual DbSet<Colaboradore> Colaboradores { get; set; }

    public virtual DbSet<Espaco> Espacos { get; set; }

    public virtual DbSet<Ponto> Pontos { get; set; }

    public virtual DbSet<Setore> Setores { get; set; }

    public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Visitante> Visitantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=ACCESS_3S;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcessoEspaco>(entity =>
        {
            entity.HasKey(e => e.IdAcessoEspaco).HasName("PK__AcessoEs__66E8CB646D2BFA43");

            entity.ToTable("AcessoEspaco");

            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AcessoEspacos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AcessoEsp__IdUsu__36B12243");
        });

        modelBuilder.Entity<Colaboradore>(entity =>
        {
            entity.HasKey(e => e.IdColaborador).HasName("PK__Colabora__3D2CA512B50EBE39");

            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSetorNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.IdSetor)
                .HasConstraintName("FK__Colaborad__IdSet__2C3393D0");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Colaboradores)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Colaborad__IdUsu__2B3F6F97");
        });

        modelBuilder.Entity<Espaco>(entity =>
        {
            entity.HasKey(e => e.IdEspaco).HasName("PK__Espacos__1EDE22F275EBFE01");

            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ponto>(entity =>
        {
            entity.HasKey(e => e.IdPonto).HasName("PK__Pontos__BCD1F103D332BCC8");

            entity.Property(e => e.HorarioPonto)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColaboradorNavigation).WithMany(p => p.Pontos)
                .HasForeignKey(d => d.IdColaborador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pontos__IdColabo__2F10007B");
        });

        modelBuilder.Entity<Setore>(entity =>
        {
            entity.HasKey(e => e.IdSetor).HasName("PK__Setores__113E4B9E133FC24A");

            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TiposUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TiposUsu__CA04062BADF42951");

            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF9731F2EA8D");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdTipo__267ABA7A");
        });

        modelBuilder.Entity<Visitante>(entity =>
        {
            entity.HasKey(e => e.IdVisitante).HasName("PK__Visitant__696F3E9F2B976A6F");

            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Visitantes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Visitante__IdUsu__31EC6D26");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
