using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{


    public partial class Combat
    {
        public IMonstre Monstre;
        public IHero Hero;

        public Combat(IMonstre nomMonstre, IHero nomHero)
        {
            Monstre = nomMonstre;
            Hero = nomHero;
        }


        public void TourDuMonstre()
        {
            int AMonstre;
            Console.WriteLine("C'est au tour du " + Monstre.nom );
            AMonstre=WorldEngine.GetRandomValue(1, 2);
            
            if (AMonstre == 1)
            {
                Monstre.Attaquer(Monstre,Hero);
                Monstre.Blesser(Monstre,Hero);
            }
            else if(AMonstre==2) 
            {
                Monstre.Crier();
            }
        }


        int fuirMonstre = 0;
        bool Jmort=false;


        public void tourDuJoueur()
        {
            string choixJoueur;
            Console.WriteLine("Que faite vous ? \n [1] Ataquer [2]Crier [3]faire une attaque cardiaque de peur");
            choixJoueur = Console.ReadLine();

            if (choixJoueur == "1" || choixJoueur == "&")
            {
                Hero.Attaquer(Hero, Monstre);
                Hero.Blesser(Hero, Monstre);
                if (Monstre.PV <= 0)
                {
                    Console.WriteLine("Bravo le monstre est mort");
                }
            }
            else if (choixJoueur == "2" || choixJoueur == "é")
            {
                Hero.Crier();
                fuirMonstre++;
            }
            else if (choixJoueur == "3" || choixJoueur == "\"")
            {
                Hero.Mourir();
                Jmort = true;
                Console.WriteLine(" Vous êtes mort");
            }
            else
            {
                Console.WriteLine("Vous begayer et passer votre tour");
            }
        }

        public void lancerCombat()
        {
            Console.WriteLine("le combat Comence entre " + Monstre.nom + " et " + Hero.nom );
            int tours = 0;

            while ((Monstre.PV >0 && fuirMonstre < 2) && Jmort == false)
            {
                tours++;
                if (tours > 1)
                {
                    Console.WriteLine("Tours " + tours);
                    TourDuMonstre();
                    if (Hero.PV <= 0)
                    {
                        Hero.Mourir();
                        Jmort = true;
                        break;
                    }

                }
                tourDuJoueur();
                if (fuirMonstre >= 2)
                {
                    Console.WriteLine("Le monstre fuit");
                }


                if (Hero.PV <= 0)
                {
                    Hero.Mourir();
                    Jmort = true;
                }
            }
        }
    }
}



    

