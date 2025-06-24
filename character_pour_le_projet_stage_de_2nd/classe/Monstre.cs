using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal class Monstre : Character, IMonstre, ICharacter
    {
        public int PV { get; set; }
        public int dmg { get; set; }
        public Monstre(string nom, int att, int lvl, int PV, int dmg) : base(nom, att, PV )
        {
            Console.WriteLine(nom + "de lvl" + lvl);
            lvl = WorldEngine.GetRandomValue(1, 10);
            int vit = WorldEngine.GetRandomValue(1, 3);
            att = 1;
            this.PV = 5  + lvl;
            this.dmg = att * (lvl + 5);
            bool BOSSE = lvl >= 10;
            if (BOSSE)
            {
                att = 15;
                PV = 30;
                vit = 2;
            }
        }



        #region Propriété
        private int niveau;
        public int lvl
        {
            get => niveau;
            set
            {
                niveau = value;
            }
        }

            #endregion
        void ICharacter.Attaquer(ICharacter Attaquant, ICharacter Cible)
        {
            Console.WriteLine("Le Monstre attaque");
        }
        void IMonstre.Crier(IMonstre monstre)
        {
            Console.WriteLine(this.nom + " crie HUAAAAAAAAAAAAA!!");
            Console.WriteLine("La prochaine attaque du monstre sera plus forte");
            monstre.dmg = monstre.dmg + 10;
        }
    }
}

