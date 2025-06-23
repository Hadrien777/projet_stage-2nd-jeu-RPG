using System;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal abstract class Character : ICharacter
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
        #endregion
        public Character(string nom, int att,int PV)
        {
            Nom = nom;
            NombreAttaque = att;
            PointDeVie = PV;
            Console.WriteLine("Charactere");
        }
        public virtual void Attaquer(ICharacter character)
        {
            Console.WriteLine("Character attaque " + character.nom);
        }
        
        public void Blesser(ICharacter character)
        {
            Console.WriteLine(character.nom + "crie Ailllle!!!");

        }
        public void Crier()
        {
            Console.WriteLine(this.nom + "crie HUAAAAAAAAAAAAA!!");
        }
        public void Mourir()
        {
            Console.WriteLine(this.nom + " est Mort");
        }


    }
}
