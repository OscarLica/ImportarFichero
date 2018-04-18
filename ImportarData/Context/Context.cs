using ImportarData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImportarData.Context
{
    public class Context : DbContext
    {
        public Context()
            : base("Default")
        {

        }
        public DbSet<Encargos> Encargos { get; set; }
    }
}