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
        public int PVMonstre
        {
            get => PV; 
            set
            {
                PV = value;
            } 
        }

        public Monstre(string nom, int att, int lvl, int PVMontres) : base(nom, att, PVMontres )
        {
            int vit = WorldEngine.GetRandomValue(1, 3);
            att = WorldEngine.GetRandomValue(8, 14) + lvl / 2;
            PVMonstre = 5 + WorldEngine.GetRandomValue(3, 10) + lvl;
            lvl = WorldEngine.GetRandomValue(1, 10);
            bool BOSSE = lvl >= 10;
            if (BOSSE)
            {
                att = 15;
                PVMonstre = 30;
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


        void ICharacter.Attaquer(ICharacter character)
        {
            Console.WriteLine("Le Monstre attaque");
        }
    }
}

