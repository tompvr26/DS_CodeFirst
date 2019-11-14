using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCodeFirst.ORM
{
    public class Jeu
    {
        [Key]
        public int IdJeu { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Plateforme { get; set; }

        public bool Stock{ get; set; }

        public virtual ICollection<Client> Clients { get; set; }


        public Jeu()
        {
            Clients = new List<Client>();

        }
    }
}
