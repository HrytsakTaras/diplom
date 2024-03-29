﻿using ApplicationCore.Entities;
using Infrastructure.IntermediateEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<NewsItemDTO> News { get; set; }
        public DbSet<ChartItem> Charts { get; set; }
        public DbSet<EmployeeNewsItem> EmployeeNewsItems { get; set; }
        public DbSet<EmployeeDTO> Employers { get; set; }
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeNewsItem>().HasKey(mf => new { mf.EmployeeId, mf.NewsItemId });


            base.OnModelCreating(modelBuilder);

            ContextsSeed.SeedNewsCharts(modelBuilder);
            ContextsSeed.SeedEmployers(modelBuilder);

        }
    

    }
}