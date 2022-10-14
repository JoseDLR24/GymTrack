using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymTrack.Models;

namespace GymTrack.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GymTrack.Models.Category>? Category { get; set; }
        public DbSet<GymTrack.Models.Exercise> Exercise { get; set; }
        public DbSet<GymTrack.Models.ExerciseDetail> ExerciseDetail { get; set; }
    }
}