using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCodeFirst.ORM
{
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; }

        public virtual ICollection<Jeu> Jeux { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public Reservation()
        {
            Jeux = new List<Jeu>();
            Clients = new List<Client>();
        }
    }
}
