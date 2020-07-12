using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HasniAPI.Model
{
    public partial class SSContext : DbContext
    {
        public SSContext()
        {
        }

        public SSContext(DbContextOptions<SSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleXCommande> ArticleXCommande { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Commande> Commande { get; set; }
        public virtual DbSet<Depot> Depot { get; set; }
        public virtual DbSet<Famillearticle> Famillearticle { get; set; }
        public virtual DbSet<Familleclient> Familleclient { get; set; }
        public virtual DbSet<Fournisseur> Fournisseur { get; set; }
        public virtual DbSet<Magasin> Magasin { get; set; }
        public virtual DbSet<Sousfamillearticle> Sousfamillearticle { get; set; }
        public virtual DbSet<Tva> Tva { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=SS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArticle);

                entity.ToTable("ARTICLE");

                entity.Property(e => e.CodeAbarre)
                    .HasColumnName("CodeABarre")
                    .HasMaxLength(256);

                entity.Property(e => e.CodeF).HasMaxLength(100);

                entity.Property(e => e.CodeFrs).HasMaxLength(100);

                entity.Property(e => e.CodeSf)
                    .HasColumnName("CodeSF")
                    .HasMaxLength(100);

                entity.Property(e => e.Colis).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDebut).HasColumnType("smalldatetime");

                entity.Property(e => e.DateFin).HasColumnType("smalldatetime");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.DernierPrixAchat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DernierPrixVente).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Designation).HasMaxLength(100);

                entity.Property(e => e.EncodageType).HasMaxLength(256);

                entity.Property(e => e.IdTva).HasColumnName("IdTVA");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.IsPlinthe).HasDefaultValueSql("(0)");

                entity.Property(e => e.NbreParColis)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.NomImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pmp)
                    .HasColumnName("PMP")
                    .HasColumnType("decimal(24, 3)");

                entity.Property(e => e.Pmpachat)
                    .HasColumnName("PMPAchat")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Pmpvente)
                    .HasColumnName("PMPVente")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrixAchat).HasColumnType("decimal(24, 3)");

                entity.Property(e => e.PrixAchatHamria).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrixAchatTtc)
                    .HasColumnName("PrixAchatTTC")
                    .HasColumnType("decimal(24, 3)");

                entity.Property(e => e.PrixAchatZitoune).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrixHamria).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PrixMin)
                    .HasColumnType("decimal(24, 3)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PrixMinTtc)
                    .HasColumnName("PrixMinTTC")
                    .HasColumnType("decimal(24, 3)");

                entity.Property(e => e.PrixVenteArticleHt)
                    .HasColumnName("PrixVenteArticleHT")
                    .HasColumnType("decimal(24, 3)");

                entity.Property(e => e.PrixVenteArticleTtc)
                    .HasColumnName("PrixVenteArticleTTC")
                    .HasColumnType("decimal(24, 3)");

                entity.Property(e => e.PrixZitoune).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.QteParClois).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.QteParColis)
                    .HasColumnType("decimal(18, 3)")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.RefArticle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StockMax).HasColumnType("decimal(24, 3)");

                entity.Property(e => e.StockMin).HasColumnType("decimal(24, 3)");

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TypeImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unite)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFamilleArticleNavigation)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.IdFamilleArticle)
                    .HasConstraintName("FK_ARTICLE_SOUSFAMILLEARTICLE");

                entity.HasOne(d => d.IdTvaNavigation)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.IdTva)
                    .HasConstraintName("FK_ARTICLE_TVA");
            });

            modelBuilder.Entity<ArticleXCommande>(entity =>
            {
                entity.ToTable("ARTICLE_X_COMMANDE");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Designation).HasMaxLength(100);

                entity.Property(e => e.Prix)
                    .HasColumnType("decimal(24, 3)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.PrixTtc)
                    .HasColumnName("PrixTTC")
                    .HasColumnType("decimal(24, 3)");

                entity.Property(e => e.QuantiteCommandee)
                    .HasColumnType("decimal(24, 3)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.QuantiteLivree).HasColumnType("decimal(24, 3)");

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TauxTva)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.HasOne(d => d.IdArticleNavigation)
                    .WithMany(p => p.ArticleXCommande)
                    .HasForeignKey(d => d.IdArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARTICLE_ASCARTICL_ARTICLE2");

                entity.HasOne(d => d.IdCommandeNavigation)
                    .WithMany(p => p.ArticleXCommande)
                    .HasForeignKey(d => d.IdCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARTICLE_ASCARTICL_COMMANDE");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("CLIENT");

                entity.Property(e => e.AddresseFacturation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Adresse).HasMaxLength(100);

                entity.Property(e => e.Agence)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Banque)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Compte)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.ContactClient).HasMaxLength(100);

                entity.Property(e => e.Credit)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Debit)
                    .HasColumnType("decimal(24, 2)")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EmailClient).HasMaxLength(100);

                entity.Property(e => e.IsBloque).HasColumnName("isBloque");

                entity.Property(e => e.NomClient).HasMaxLength(100);

                entity.Property(e => e.NumFax).HasMaxLength(100);

                entity.Property(e => e.NumTele).HasMaxLength(100);

                entity.Property(e => e.RefClt).HasMaxLength(100);

                entity.Property(e => e.SiteWebClient).HasMaxLength(100);

                entity.Property(e => e.SoldeMaximum).HasColumnType("decimal(24, 2)");

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ville).HasMaxLength(100);

                entity.HasOne(d => d.IdFamilleClientNavigation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.IdFamilleClient)
                    .HasConstraintName("FK_CLIENT_REFERENCE_FAMMILLE");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.IdCommande);

                entity.ToTable("COMMANDE");

                entity.Property(e => e.DateCommande).HasColumnType("datetime");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.IsReported).HasColumnType("datetime");

                entity.Property(e => e.RefCommande).HasMaxLength(100);

                entity.Property(e => e.Remarque).HasMaxLength(100);

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Commande)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_COMMANDE_ASSOCIATI_CLIENT");

                entity.HasOne(d => d.IdMagasinNavigation)
                    .WithMany(p => p.Commande)
                    .HasForeignKey(d => d.IdMagasin)
                    .HasConstraintName("FK_COMMANDE_MAGASIN");
            });

            modelBuilder.Entity<Depot>(entity =>
            {
                entity.HasKey(e => e.IdDepot);

                entity.ToTable("DEPOT");

                entity.Property(e => e.Adresse).HasMaxLength(100);

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Fax).HasMaxLength(100);

                entity.Property(e => e.IsMagasin).HasDefaultValueSql("(0)");

                entity.Property(e => e.NomDepot).HasMaxLength(100);

                entity.Property(e => e.Reference).HasMaxLength(100);

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Tele).HasMaxLength(100);
            });

            modelBuilder.Entity<Famillearticle>(entity =>
            {
                entity.HasKey(e => e.IdFamilleArticle)
                    .HasName("PK_FAMARTICLE");

                entity.ToTable("FAMILLEARTICLE");

                entity.Property(e => e.CodeFamille).HasMaxLength(50);

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.IsCarreaux).HasDefaultValueSql("(0)");

                entity.Property(e => e.LibelleFamArticle).HasMaxLength(100);

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Familleclient>(entity =>
            {
                entity.HasKey(e => e.IdFamilleClient)
                    .HasName("PK_FAMMILLECLT");

                entity.ToTable("FAMILLECLIENT");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.LibelleFamilleClt).HasMaxLength(100);

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.HasKey(e => e.IdFournisseur)
                    .HasName("PK__Fourniss__A63C9FB992B754AC");

                entity.Property(e => e.IdFournisseur).ValueGeneratedNever();

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Magasin>(entity =>
            {
                entity.HasKey(e => e.IdMagasin);

                entity.ToTable("MAGASIN");

                entity.Property(e => e.Adresse).HasMaxLength(100);

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Fax).HasMaxLength(100);

                entity.Property(e => e.NomMagasin).HasMaxLength(100);

                entity.Property(e => e.Reference).HasMaxLength(100);

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Tele).HasMaxLength(100);

                entity.HasOne(d => d.IdDepotNavigation)
                    .WithMany(p => p.Magasin)
                    .HasForeignKey(d => d.IdDepot)
                    .HasConstraintName("FK_MAGASIN_DEPOT");
            });

            modelBuilder.Entity<Sousfamillearticle>(entity =>
            {
                entity.HasKey(e => e.IdSousFamille);

                entity.ToTable("SOUSFAMILLEARTICLE");

                entity.Property(e => e.CodeSf)
                    .HasColumnName("CodeSF")
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.LibelleSousFamille).HasMaxLength(100);

                entity.Property(e => e.Supprimer).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.IdFamilleArticleNavigation)
                    .WithMany(p => p.Sousfamillearticle)
                    .HasForeignKey(d => d.IdFamilleArticle)
                    .HasConstraintName("FK_SOUSFAMILLEARTICLE_FAMILLEARTICLE");
            });

            modelBuilder.Entity<Tva>(entity =>
            {
                entity.HasKey(e => e.IdTva);

                entity.ToTable("TVA");

                entity.Property(e => e.IdTva).HasColumnName("IdTVA");

                entity.Property(e => e.CodeTva)
                    .HasColumnName("CodeTVA")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateModification).HasColumnType("datetime");

                entity.Property(e => e.Supprime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TauxTva)
                    .HasColumnName("TauxTVA")
                    .HasColumnType("decimal(24, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
