using DSCodeFirst.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCodeFirst.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ContextBDD())
            {
                var jeuSouhaite = db.Jeux.Join(db.Reservations
                                            ,j => j.Stock
                                          
            }
        }

    }
}
