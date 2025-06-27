using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    public class Inventaire
    {
        public List<Item>inventaire  { get ; set ;}
        public Inventaire(List<Item> inventaire)
        {
            this.inventaire = inventaire;
        }
    }
}
