using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCodeFirst.ORM
{
    public class Echange
    {
        [Key]
        public int IdEchange { get; set; }

        public virtual ICollection<Jeu> Jeux { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public Echange()
        {
            Jeux = new List<Jeu>();
            Clients = new List<Client>();
        }

    }
}
