using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ilyes_Andrea_Lab2.Models;


namespace Ilyes_Andrea_Lab2.Data
{
    public class Ilyes_Andrea_Lab2Context : DbContext
    {
        public Ilyes_Andrea_Lab2Context(DbContextOptions<Ilyes_Andrea_Lab2Context> options)
            : base(options)
        { }
            
           
            public DbSet<Ilyes_Andrea_Lab2.Models.Book> Book { get; set; } = default!;
            public DbSet<Ilyes_Andrea_Lab2.Models.Customer> Customer { get; set; } = default!;
            public DbSet<Ilyes_Andrea_Lab2.Models.Genre> Genre { get; set; } = default!;
            public DbSet<Ilyes_Andrea_Lab2.Models.Author> Author { get; set; }
        public DbSet<Ilyes_Andrea_Lab2.Models.Order> Order { get; set; } = default!;
    }
    }



