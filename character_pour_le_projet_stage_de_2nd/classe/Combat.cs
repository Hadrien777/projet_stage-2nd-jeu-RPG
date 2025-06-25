using System;

namespace character_pour_le_projet_stage_de_2nd.classe
{


    public partial class Combat
    {
        public Monstre Monstre;
        public IHero hero;
        public Combat(Monstre nomMonstre, IHero joueur)
        {
            Monstre = nomMonstre;
            hero = joueur;
        }

        public void TourDuMonstre()
        {
            int AMonstre;
            Console.WriteLine("C'est au tour du " + Monstre.nom);
            AMonstre = WorldEngine.GetRandomValue(1, 1);

            if (AMonstre == 1)
            {
                Monstre.Attaquer(Monstre, hero);
                Monstre.Blesser(Monstre, hero);

            }
            else if (AMonstre == 2)
            {
                Monstre.Crier();
            }

        }

        int fuirMonstre = 0;
        bool Jmort = false;

        public void tourDuJoueur()
        {
            string choixJoueur;
            Console.WriteLine("Que faite vous ? \n [1] Ataquer [2]Crier [3]faire une attaque cardiaque de peur");
            choixJoueur = Console.ReadLine();

            if (choixJoueur == "1" || choixJoueur == "&")
            {
                hero.Attaquer(hero, Monstre);
                hero.Blesser(hero, Monstre);
                if (Monstre.PV <= 0)
                {
                    Console.WriteLine("Bravo le monstre est mort");
                }
            }
            else if (choixJoueur == "2" || choixJoueur == "é")
            {
                hero.Crier();
                fuirMonstre++;
            }
            else if (choixJoueur == "3" || choixJoueur == "\"")
            {
                hero.Mourir();
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
            Console.WriteLine("le combat Comence entre " + Monstre.nom + " et " + hero.nom);
            int tours = 0;
            bool Jmort = false;

            while ((Monstre.PV > 0 && fuirMonstre < 2) && Jmort == false)
            {
                tours++;
                if (tours > 1)
                {
                    Console.WriteLine("\nTours " + tours);
                    TourDuMonstre();
                }
                tourDuJoueur();
                if (fuirMonstre >= 2)
                {
                    Console.WriteLine("Le monstre fuit");
                }
                if (hero.PV == 0)
                {
                    Console.WriteLine("le Hero est mort");
                    Jmort = true;
                }
            }

        }
    }
}