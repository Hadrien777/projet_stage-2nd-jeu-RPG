using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal class Epee : Item
    {
        public int quantite { get; set; }
        public Epee(int quantite) : base(quantite)
        {

        }
    }
}
