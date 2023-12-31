﻿using filmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace filmesApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
