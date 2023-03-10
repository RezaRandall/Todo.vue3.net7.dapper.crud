using API.Dot7.CRUD.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Dot7.CRUD.Data;

public class MyWorldDbContext : DbContext
{
    public MyWorldDBContext(DbContextOptions<MyWorldDBContext> options) : base(options)
    {

    }

    public DbSet<Beach> Beaches { get; set; }
}
