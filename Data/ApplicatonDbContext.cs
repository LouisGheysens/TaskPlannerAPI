using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class ApplicatonDbContext: IdentityDbContext<IdentityUser>
{
    public ApplicatonDbContext(DbContextOptions<ApplicatonDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    public DbSet<IdentityUser> ApplicationUser { get; set; }
}
