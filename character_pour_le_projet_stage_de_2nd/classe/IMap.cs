using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal interface IMap
    {
        void map(Hero joueur);
        void Magasin(Hero joueur);
        void Taverne(Hero joueur);
        void Eglise(Hero joueur);
        void GuilDesAventurier(Hero joueur);
        void Donjons(IHero character);
    }
}
