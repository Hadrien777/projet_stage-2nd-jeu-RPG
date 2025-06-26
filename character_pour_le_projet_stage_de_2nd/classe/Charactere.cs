using System;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    public abstract class Character : ICharacter
    {

        public string Nom;
        protected int pointDeVie;
        protected int pointDeVieMax;
        protected int nombreAttaque;
        protected int classeArmure;
        protected int jetDeSauvegarde;


        #region Propriétés
        public string nom => Nom;



        public int PointDeVie
        {
            get => pointDeVie;
            set
            {
                if(pointDeVie + value > pointDeVieMax)
                {
                    pointDeVie = pointDeVieMax;
                }
                else
                {
                    pointDeVie += value;
                }
            }

        }
        public int PointDeVieMax
        {
            get => pointDeVieMax;
            set
            {
                pointDeVieMax = value;
            }
        }
        public int NombreAttaque
        {
            get => nombreAttaque;
            set
            {
                nombreAttaque = value;
            }
        }
        public int ClasseArmure
        {
            get => classeArmure;
            set
            {
                classeArmure = value;
            }
        }
        public int JetDeSauvegarde
        {
            get => jetDeSauvegarde;
            set
            {
                jetDeSauvegarde = value;
            }
        }
        public int PV{ get; set; }
        public int dmg { get; set; }

        #endregion
        public Character(string nom, int att, int PV)
        {
            Nom = nom;
            NombreAttaque = att;
            PointDeVie = PV;
            Console.WriteLine("Charactere");
        }

        public virtual void Attaquer(ICharacter Attaquant, ICharacter Cible)
        {
            Console.WriteLine(this.nom +" attaque " + Cible.nom);
        }
        
        public void Blesser(ICharacter Attaquant , ICharacter Cible)
        {
            Console.WriteLine(Cible.nom + " crie Ailllle!!!");
            Cible.PV = Cible.PV - Attaquant.dmg;
            if (Cible.PV < 0)
            {
                Cible.PV = 0;
            }
            Console.WriteLine("Il reste " + Cible.PV + " PV à " + Cible.nom);
        }

        public void Crier()
        {
            Console.WriteLine(this.nom + " crie HUAAAAAAAAAAAAA!!");
        }

        public void Mourir()
        {
           Console.WriteLine(this.nom + " est Mort");
        }


    }
}
