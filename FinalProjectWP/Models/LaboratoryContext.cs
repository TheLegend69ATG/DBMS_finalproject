using Microsoft.EntityFrameworkCore;

namespace FinalProjectWP.Models
{
    public partial class LaboratoryContext : DbContext
    {
        public LaboratoryContext()
        {
        }

        public LaboratoryContext(DbContextOptions<LaboratoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Experiment> Experiment { get; set; }
        public virtual DbSet<Finished> Finished { get; set; }
        public virtual DbSet<LabInfo> LabInfo { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<MemberInfo> MemberInfo { get; set; }
        public virtual DbSet<Participation> Participation { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.137.1;Database=Laboratory;User ID=quan;Password=123;");//Trusted_Connection=True;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.LeaderId)
                    .HasColumnName("LeaderID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Experiment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LeaderId)
                    .HasColumnName("LeaderID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.Experiment)
                    .HasForeignKey(d => d.LeaderId)
                    .HasConstraintName("FK_Experiment_MemberInfo");
            });

            modelBuilder.Entity<Finished>(entity =>
            {
                entity.HasKey(e => e.ExpId)
                    .HasName("PK__Finished__45B117C70EC7F3CE");

                entity.Property(e => e.ExpId)
                    .HasColumnName("ExpID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Exp)
                    .WithOne(p => p.Finished)
                    .HasForeignKey<Finished>(d => d.ExpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Finished_Experiment");
            });

            modelBuilder.Entity<LabInfo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.HasKey(e => e.MemId)
                    .HasName("PK__LoginInf__E9341AE250AE3366");

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__LoginInf__536C85E4DDBC0549")
                    .IsUnique();

                entity.Property(e => e.MemId)
                    .HasColumnName("MemID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Mem)
                    .WithOne(p => p.LoginInfo)
                    .HasForeignKey<LoginInfo>(d => d.MemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoginInfo_MemberInfo");
            });

            modelBuilder.Entity<MemberInfo>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__MemberIn__A9D1053447DAE06D")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__MemberIn__737584F6BA3EBB99")
                    .IsUnique();

                entity.HasIndex(e => e.Phone)
                    .HasName("UQ__MemberIn__5C7E359E00425513")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PosId).HasColumnName("PosID");

                entity.Property(e => e.ProfilePic).HasColumnType("image");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.MemberInfo)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_MemberInfo_Department");

                entity.HasOne(d => d.Pos)
                    .WithMany(p => p.MemberInfo)
                    .HasForeignKey(d => d.PosId)
                    .HasConstraintName("FK_MemberInfo_Position");
            });

            modelBuilder.Entity<Participation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ExpId).HasColumnName("ExpID");

                entity.Property(e => e.MemId)
                    .HasColumnName("MemID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exp)
                    .WithMany(p => p.Participation)
                    .HasForeignKey(d => d.ExpId)
                    .HasConstraintName("FK_Participation_Experiment");

                entity.HasOne(d => d.Mem)
                    .WithMany(p => p.Participation)
                    .HasForeignKey(d => d.MemId)
                    .HasConstraintName("FK_Participation_MemberInfo");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.ExpId).HasColumnName("ExpID");

                entity.Property(e => e.ReportTime).HasColumnType("datetime");

                entity.HasOne(d => d.Exp)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.ExpId)
                    .HasConstraintName("FK_Report_Experiment");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EqmId).HasColumnName("EqmID");

                entity.Property(e => e.ExpId).HasColumnName("ExpID");

                entity.HasOne(d => d.Eqm)
                    .WithMany(p => p.Supply)
                    .HasForeignKey(d => d.EqmId)
                    .HasConstraintName("FK_Supply_Equipment");

                entity.HasOne(d => d.Exp)
                    .WithMany(p => p.Supply)
                    .HasForeignKey(d => d.ExpId)
                    .HasConstraintName("FK_Supply_Experiment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
