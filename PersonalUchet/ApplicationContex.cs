﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibEmployees
{
    public class ApplicationContex : DbContext
    {
        public ApplicationContex() : base("DefaultConnection")
        {
        }
        public DbSet<Transfer> Transfers { get; set; }
    }
}
