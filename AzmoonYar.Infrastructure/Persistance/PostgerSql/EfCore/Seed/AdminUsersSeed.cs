using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AzmoonYar.Infrastructure.Persistance.PostgerSql.EfCore.Seed;

public class AdminUsersSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(
                new
                {
                    Id = 1L,
                    FirstName = "امیرعلی",
                    LastName = "والی",
                    PhoneNumber = "09361842050",
                    PasswordHash = "$2a$11$YEKWptY9k.kF2OP3h8CAmORe9fsedHxUIeA2lw56SrIx9iUHQTZgG", 
                    Email = (string?)null,
                    UserRole = UserRole.Admin,
                    CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
                },
                new
                {
                    Id = 2L,
                    FirstName = "علی اصغر",
                    LastName = "نجفی",
                    PhoneNumber = "09100039662",
                    PasswordHash = "$2a$11$u573W8/E.nBEvCuu46ddoOAWOx2A6lPXh9P34g01krDjNjPiRxAv6", 
                    Email = (string?)null,
                    UserRole = UserRole.Admin,
                    CreatedAt = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero)
                }
            );
    }
}