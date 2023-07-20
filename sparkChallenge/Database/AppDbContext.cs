using System;
using Microsoft.EntityFrameworkCore;
using sparkChallenge.Models;

namespace sparkChallenge.Database
{
	public class AppDbContext : DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Expense> Expenses { get; set; }
	}
}

