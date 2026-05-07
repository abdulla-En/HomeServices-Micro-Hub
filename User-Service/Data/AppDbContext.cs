using Microsoft.EntityFrameworkCore;

namespace User_Service.Data; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // (DbSets) 
}