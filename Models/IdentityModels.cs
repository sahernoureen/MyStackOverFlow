using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyStackOverFlow.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Questions = new HashSet<Question>();
            this.Answers = new HashSet<Answer>();
            this.Comments = new HashSet<QComment>();
        }

       
        public int Reputation { get; set; }
        public string Badge { get; set; }
        public virtual ICollection<Question> Questions { get; set;}
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QComment> Comments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QComment> QComments { get; set; }
        public DbSet<AComment> AComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
      //  public DbSet<Quest_Tag> Quest_Tags { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public IEnumerable ApplicationUsers { get; internal set; }

        public ApplicationDbContext()
            : base("MyStackOverFlow", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });


            modelBuilder.Entity<Question>()
                .HasMany(Q => Q.Tag)
                .WithMany(T => T.Question)
                    .Map(t => t.MapLeftKey("Id")
                        .MapRightKey("TagId")
                         .ToTable("QuestTag"));

            modelBuilder.Entity<Question>()
                .Property(Q => Q.Qdate)
                .HasColumnType("datetime2");

            modelBuilder.Entity<Answer>()
              .Property(A => A.Ansdate)
              .HasColumnType("datetime2");

            modelBuilder.Entity<QComment>()
            .Property(QC => QC.Comdate)
            .HasColumnType("datetime2");

            modelBuilder.Entity<AComment>()
            .Property(AC => AC.Comdate)
            .HasColumnType("datetime2");

        }


    }
}