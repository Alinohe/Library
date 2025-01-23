﻿namespace Library.Data;
using Microsoft.EntityFrameworkCore;
using Library.Entities;


public class LibraryDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Client> Client => Set<Client>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}
