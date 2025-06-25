using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    public  class Hero : Character, ICharacter, IHero
    {
        protected int niveau;
        protected int experienceENCours;
        protected ClasseHero classe;
        public Dictionary<string, int> caracteristiques;
        public Dictionary<string, int> bonusCaracteristiques;



        #region Proriété
        public int lvl
        {
            get => niveau;
            set
            {
                niveau = value;
            }
        }
        public int ClArmure { get; set; }
        public int expEnCours
        {
            get => experienceENCours;
            set
            {
                experienceENCours = value;
            }
        }
        public int PVMax { get; set; }

        new public int dmg { get; set; }
        public int or {  get; set; }    

        //Constructeur
        public Hero(string nom, int att,int dmg, int lvl, int DAtt, int PV, int ClArmure,int or) : base(nom, att, PV)
        {
            PointDeVieMax = PVMax;
            string nomCara;
            int val;
            InitialisCarac();          
            Console.WriteLine("heros");
            or = 10;
        }


        //limite des Carac
        public void limiteCarac(string nomCara, int val)
        {

            caracteristiques[nomCara] = val;
            if (caracteristiques[nomCara] > 18)
            {
                caracteristiques[nomCara] = 18;
            }
        }


        //liste des Carac
        public void InitialisCarac()
        {
            caracteristiques = new Dictionary<string, int>();

            caracteristiques.Add("FORCE", 0);
            caracteristiques.Add("CONSTITUTION", 0);
            caracteristiques.Add("DEXTERITE", 0);
            caracteristiques.Add("INTELIGENCE", 0);
            caracteristiques.Add("SAGESSE", 0);
            caracteristiques.Add("CHARISME", 0);

            bonusCaracteristiques = new Dictionary<string, int>();
            bonusCaracteristiques.Add("FORCE", 0);
            bonusCaracteristiques.Add("CONSTITUTION", 0);
            bonusCaracteristiques.Add("DEXTERITE", 0);
            bonusCaracteristiques.Add("INTELIGENCE", 0);
            bonusCaracteristiques.Add("SAGESSE", 0);
            bonusCaracteristiques.Add("CHARISME", 0);

            foreach (var caracteristique in caracteristiques)
            {
                GenrCarac(caracteristique.Key, caracteristique.Value);
            }

        }

        //buf et débuf des Carac
        protected void GenrCarac(string nomCara, int val)
        {

            if (val == 3 || val == 4)
            {
                bonusCaracteristiques[nomCara] = -2;
            }
            else if (val == 5 && val <= 7)
            {
                bonusCaracteristiques[nomCara] = -1;
            }
            else if (val >= 8 && val <= 12)
            {
                bonusCaracteristiques[nomCara] = 0;
            }
            else if (val >= 13 || val <= 15)
            {
                bonusCaracteristiques[nomCara] = 1;
            }
            else if (val == 16 || val == 17)
            {
                bonusCaracteristiques[nomCara] = 2;
            }
            else if (val == 18)
            {
                bonusCaracteristiques[nomCara] = 3;
            }
            else
            {
                throw new Exception(string.Format("Une erreur est survenue dans la méthode GenereCarac pour la carac {0} et valeur {1} ", nomCara, val));
            }
        }


        //gestion vie Max
        public void GenerVieMax()
        {
            if (PointDeVie == 1)
            {
                PointDeVieMax = 6 + bonusCaracteristiques["CONSTITUTION"];
            }
            else
            {
                int totalVie = 0;
                for (int i = 0; i < PointDeVie; i++)
                {
                    totalVie += WorldEngine.GetRandomValue(1, 6);
                }

                PointDeVieMax = totalVie > PointDeVieMax ? totalVie : PointDeVieMax + 1;

            }
        }

        void ICharacter.Attaquer(ICharacter Attaquant, ICharacter Cible)
        {
            Console.WriteLine("Héro attaque");
        }
    }
}   public enum ClasseHero { GUERRIER, MAGE, PRETRE, VOLEUR }

   

  
#endregion