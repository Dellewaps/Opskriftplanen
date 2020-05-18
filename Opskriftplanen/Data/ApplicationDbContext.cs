using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Opskriftplanen.Data.Migrations;
using Opskriftplanen.Models;

namespace Opskriftplanen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Recipes> Recipe { get; set; }

        public DbSet<IngredientCollection> IngredientCollection { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }

        public DbSet<Measurment> Measurment { get; set; }

        public DbSet<MeasurmentUnit> MeasurmentUnit { get; set; }

    }
}
