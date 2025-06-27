using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    public interface ICharacter
    {

        string nom { get; }
        int dmg { get; set; }
        int PV { get; set; }
        bool estMort { get; set; }
        void Attaquer(ICharacter Attquant,ICharacter Cible);
        void Crier();
        void Blesser(ICharacter Attaquant , ICharacter Cible);
        void Mourir(ICharacter Cible);
        void BlesserMagiquement(ICharacter Attaquant, ICharacter Cible);
    }
}
