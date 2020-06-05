using Microsoft.EntityFrameworkCore;
using Opskriftplanen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Data
{
    public class DomainContext
    {
        public DomainContext(DbContextOptions<DomainContext> options) : base(options) { }



        public  DbSet<Category> Category { get; set; }
    }
}
