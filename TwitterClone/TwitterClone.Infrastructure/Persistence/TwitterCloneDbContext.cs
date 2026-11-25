using Microsoft.EntityFrameworkCore;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence
{
    public class TwitterCloneDbContext : DbContext
    {
        public TwitterCloneDbContext(DbContextOptions<TwitterCloneDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Like> Likes { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Retweet> Retweets { get; set; }


        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermissoin> RolePermissoins { get; set; }
        //public DbSet<Comment> Comments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LikeNotification>();
            modelBuilder.Entity<CommentNotification>();
            modelBuilder.Entity<FriendRequestNotification>();
            modelBuilder.Entity<SystemNotification>();
            modelBuilder.Entity<MentionNotification>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitterCloneDbContext).Assembly);
        }
    }
}
