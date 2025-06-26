using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal class PotionSoin : Item
    {
        public int quantite { get; set; }
        public PotionSoin(int quantite) : base(quantite)
        {

        }
    }
}
