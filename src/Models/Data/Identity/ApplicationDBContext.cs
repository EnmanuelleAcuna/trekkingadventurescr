using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace trekkingadventurescr.Models.Data.Identity
{
	public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder Builder)
		{
			base.OnModelCreating(Builder);

			if (Builder is null)
			{
				throw new ArgumentNullException(paramName: nameof(ModelBuilder), message: "Builder es nulo.");
			}

			// Remap identity tables needed on the database
			// Usuarios
			Builder.Entity<User>().ToTable("USERS");

			// Each User can have many entries in the UserRole join table
			Builder.Entity<User>().HasMany<IdentityUserRole<string>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

			// Roles
			Builder.Entity<Role>().ToTable("ROLES");

			// User roles
			Builder.Entity<IdentityUserRole<string>>().ToTable("USER_ROLES");
		}
	}
}
