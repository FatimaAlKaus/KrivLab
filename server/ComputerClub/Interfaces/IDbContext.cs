using ComputerClub.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerClub.Interfaces
{
    public interface IDbContext
    {
        DbSet<Place> Places { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Status> Statuses { get; set; }


        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
