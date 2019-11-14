using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCodeFirst.ORM
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [StringLength(50)]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Jeu> Jeux { get; set; }


        public Client()
        {
            Jeux = new List<Jeu>();
        }
    }
}
