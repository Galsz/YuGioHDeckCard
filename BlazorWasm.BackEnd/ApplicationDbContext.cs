﻿using BlazorWasm.Compartilhado.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlazorWasmServer.Server
{
    public class ApplicationDbContext: DbContext    {

        public DbSet<YuGioH> Cards { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
          
            base.OnModelCreating(modelBuilder);
        }


   




    }
}
