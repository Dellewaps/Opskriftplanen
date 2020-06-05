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

        public DbSet<MeasurmentUnit> MeasurmentUnit { get; set; }

        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }

        public DbSet<PlanHeader> PlanHeader { get; set; }

        public DbSet<RecipeList> RecipeList { get; set; }

        public DbSet<WeekPlan> WeekPlan { get; set; }

        public DbSet<WeekDetails> WeekDetails { get; set; }
    }
}
