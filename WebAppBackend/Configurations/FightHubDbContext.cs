using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebAppBackend.Models;

namespace WebAppBackend.Configurations;

public class FightHubDbContext : DbContext
{
    public DbSet<FinancialRaport> FinancialRaports { get; set; }
    public DbSet<AddressData> AddressDatas { get; set; }
    public DbSet<ContactData> ContactDatas { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<TrainingBootcamp> TrainingBootcamps { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Name> Names { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkerFan> WorkerFans { get; set; }
    public DbSet<Fighter> Fighters { get; set; }
    public DbSet<WorkerFanWorkerFanType> WorkerFanWorkerFanTypes { get; set; }
    public DbSet<MedicalCertificate> MedicalCertificates { get; set; }
    public DbSet<MartialArt> MartialArts { get; set; }
    public DbSet<SkillLevelOfMartialArt> SkillLevelOfMartialArts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<FighterInvolvement> FighterInvolvements { get; set; }
    public DbSet<FanInvolvement> FanInvolvements { get; set; }
    

    public FightHubDbContext() { }
    public FightHubDbContext(DbContextOptions<FightHubDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        CreateAssotiationContactDataPhoneNumbers(modelBuilder);
        CreateCompositionTrainingBootcampLesson(modelBuilder);
        CreateTPTForOveralppingUsers(modelBuilder);
        CreateAssotiationWorkerFanAndWorkerFanType(modelBuilder);
        CreateBagMedicalCertificate(modelBuilder);
        CreateQualifiedAssotiation(modelBuilder);
        CreateAssotiationSkillLevels(modelBuilder);
        CreateTPTMultiaspectInheritence(modelBuilder);
        CreateXORMasterStudent(modelBuilder);
        CreateAssotiaitonFighterInvolvement(modelBuilder);
        CreateAssotiaitonOrganizedEvents(modelBuilder);
        CreateAssotiaitonOrganizedTrainingBootcamps(modelBuilder);
    }

    private void CreateAssotiationContactDataPhoneNumbers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactData>()
            .HasMany(cd => cd.PhoneNumbers)
            .WithMany(pn => pn.ContactDatas)
            .UsingEntity(t => t.ToTable("ContactDatasPhoneNumbers"));

        modelBuilder.Entity<ContactData>()
            .HasIndex(cd => cd.Email)
            .IsUnique();
    }
    
    private void CreateCompositionTrainingBootcampLesson(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>()
            .OwnsOne(l => l.Localization, a =>
            {
                a.Property(ad => ad.Street).HasColumnName("Street");
                a.Property(ad => ad.BuildingNumber).HasColumnName("BuildingNumber");
                a.Property(ad => ad.ApartmentNumber).HasColumnName("ApartmentNumber");
                a.Property(ad => ad.City).HasColumnName("City");
                a.Property(ad => ad.ZipCode).HasColumnName("ZipCode");
            });

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.TrainingBootcamp)
            .WithMany(tb => tb.Lessons)
            .OnDelete(DeleteBehavior.Cascade); // Deleting TrainingBootcamp deletes all Lessons that depend on it
        
        modelBuilder.Entity<Lesson>()
            .Property(l => l.TrainingBootcampId)
            .ValueGeneratedNever();
    }
    
    private void CreateTPTForOveralppingUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.PESEL)
            .IsUnique();
        
        modelBuilder.Entity<User>()
            .OwnsOne(l => l.AddressData, a =>
            {
                a.Property(ad => ad.Street).HasColumnName("Street");
                a.Property(ad => ad.BuildingNumber).HasColumnName("BuildingNumber");
                a.Property(ad => ad.ApartmentNumber).HasColumnName("ApartmentNumber");
                a.Property(ad => ad.City).HasColumnName("City");
                a.Property(ad => ad.ZipCode).HasColumnName("ZipCode");
            });
        
        modelBuilder.Entity<User>()
            .ToTable("Users");

        modelBuilder.Entity<WorkerFan>()
            .ToTable("WorkerFans")
            .HasBaseType<User>();
        
        modelBuilder.Entity<Fighter>()
            .ToTable("Fighters")
            .HasBaseType<User>();
    }
    
    private void CreateAssotiationWorkerFanAndWorkerFanType(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkerFanWorkerFanType>()
            .HasKey(wf => new { wf.WorkerFanId, wf.WorkerFanType });

        modelBuilder.Entity<WorkerFanWorkerFanType>()
            .HasOne(wf => wf.WorkerFan)
            .WithMany(w => w.WorkerFanTypes)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    private void CreateBagMedicalCertificate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkerFan>()
            .HasMany(e => e.MedicalCertificates)
            .WithOne(mc => mc.WorkerFan)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Fighter>()
            .HasMany(e => e.MedicalCertificates)
            .WithOne(mc => mc.Fighter)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    private void CreateQualifiedAssotiation(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MartialArt>()
            .HasMany(ma => ma.TrainingBootcamps)
            .WithOne(tb => tb.MartialArt)
            .HasForeignKey(tb => tb.MartialArtName)
            .HasPrincipalKey(ma => ma.Name)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    private void CreateAssotiationSkillLevels(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SkillLevelOfMartialArt>()
            .HasKey(sl => new { sl.FighterId, sl.MartialArtId });
        
        modelBuilder.Entity<SkillLevelOfMartialArt>()
            .HasOne(sl => sl.Fighter)
            .WithMany(f => f.SkillLevels)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<SkillLevelOfMartialArt>()
            .HasOne(sl => sl.MartialArt)
            .WithMany(ma => ma.SkillLevels)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<SkillLevelOfMartialArt>()
            .HasIndex(sl => new { sl.FighterId, sl.MartialArtId }).IsUnique()
            .IsUnique();
    }
    
    private void CreateTPTMultiaspectInheritence(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .OwnsOne(l => l.Localization, a =>
            {
                a.Property(ad => ad.Street).HasColumnName("Street");
                a.Property(ad => ad.BuildingNumber).HasColumnName("BuildingNumber");
                a.Property(ad => ad.ApartmentNumber).HasColumnName("ApartmentNumber");
                a.Property(ad => ad.City).HasColumnName("City");
                a.Property(ad => ad.ZipCode).HasColumnName("ZipCode");
            });
        
        modelBuilder.Entity<Show>()
            .ToTable("Shows")
            .HasBaseType<Event>();

        modelBuilder.Entity<Tournament>()
            .ToTable("Tournaments")
            .HasBaseType<Event>();
    }

    private void CreateXORMasterStudent(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingBootcamp>()
            .HasOne(tb => tb.Master)
            .WithMany(f => f.TrainingBootcampsAsMaster)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Fighter>()
            .HasMany(f => f.TrainingBootcampsAsStudent)
            .WithMany(b => b.Students)
            .UsingEntity(e => e.ToTable("TrainingBootcampsStudents"));
    }

    private void CreateAssotiaitonFighterInvolvement(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FighterInvolvement>()
            .Property(fi => fi.RegistrationDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        modelBuilder.Entity<FighterInvolvement>()
            .Property(fi => fi.Points)
            .HasDefaultValue(0);

        modelBuilder.Entity<FighterInvolvement>()
            .Property(fi => fi.EarnedPlace)
            .HasDefaultValue(0);

        modelBuilder.Entity<FighterInvolvement>()
            .HasOne(fi => fi.Fighter)
            .WithMany(f => f.FighterInvolvements)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FighterInvolvement>()
            .HasOne(fi => fi.Event)
            .WithMany(e => e.FighterInvolvements)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    private void CreateAssotiaitonFanInvolvement(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FanInvolvement>()
            .HasIndex(fi => fi.TicketId)
            .IsUnique();
        
        modelBuilder.Entity<FanInvolvement>()
            .Property(fi => fi.TicketBuyDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        modelBuilder.Entity<FanInvolvement>()
            .HasOne(fi => fi.WorkerFan)
            .WithMany(f => f.FanInvolvements)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FanInvolvement>()
            .HasOne(fi => fi.Event)
            .WithMany(e => e.FanInvolvements)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    private void CreateAssotiaitonOrganizedEvents(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasOne(e => e.WorkerFan)
            .WithMany(wf => wf.OrganizedEvents)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    private void CreateAssotiaitonOrganizedTrainingBootcamps(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingBootcamp>()
            .HasOne(e => e.WorkerFan)
            .WithMany(wf => wf.OrganizedTrainingBootcamps)
            .OnDelete(DeleteBehavior.Restrict);
    }
}