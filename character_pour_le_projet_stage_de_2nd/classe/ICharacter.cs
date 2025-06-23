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
        void Attaquer(ICharacter character);
        void Crier();
        void Blesser(ICharacter character);
        void Mourir();




    }
}
