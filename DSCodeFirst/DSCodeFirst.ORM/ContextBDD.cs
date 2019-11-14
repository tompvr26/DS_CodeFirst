using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCodeFirst.ORM
{
    public class ContextBDD : DbContext
    {
            public ContextBDD()
                : base("chaineDeConnexion")
            {

            }

            public DbSet<Client> Clients { get; set; }

            public DbSet<Jeu> Jeux { get; set; }

            public DbSet<Reservation> Reservations { get; set; }

            public DbSet<Echange> Echanges{ get; set; }
    }
}
