using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    public partial class Combat
    {
        public Monstre Monstre;
        public IHero hero;
        public IHero compagnion;
        int fuirMonstre = 0;
        bool Jmort = false;
        IHero[] equipe = new IHero[3];
        List<Item> Inventaire; 
        public Combat(Monstre nomMonstre, IHero[] equipe)
        {
            Monstre = nomMonstre;
            hero = equipe[0];
            this.equipe = equipe;
        }
          
        //Tour de Combat des Monstres
        public void TourDuMonstre(int nbCompagnon, IHero[] equipe )
        {
            int AMonstre;
            Console.WriteLine("C'est au tour du " + Monstre.nom);
            AMonstre = WorldEngine.GetRandomValue(1, 2);

            if (AMonstre == 1)
            {
                int C = WorldEngine.GetRandomValue(0, nbCompagnon);
                Monstre.Attaquer(Monstre, equipe[C]);
                Monstre.Blesser(Monstre, equipe[C]);
            }
            else if (AMonstre == 2)
            {
                Monstre.Crier();
            }
        }
        //tour de l'equipe
        public void tourEquipe(int i)
        {
            string choixJoueur;
            Console.WriteLine("C'est au tour de "+equipe[i].nom+" Que faite vous ? \n [1] Ataquer [2]Crier [3]Utiliser un Objet");
            choixJoueur = Console.ReadLine();
                if (choixJoueur == "1" || choixJoueur == "&")
                {
                    equipe[i].Attaquer(equipe[i], Monstre);
                    equipe[i].Blesser(equipe[i], Monstre);
                    if (Monstre.PV <= 0)
                    {
                        Console.WriteLine("Bravo le monstre est mort");
                    }
                }
                else if (choixJoueur == "2" || choixJoueur == "é")
                {
                    equipe[i].Crier();
                    fuirMonstre++;
                }
                else if (choixJoueur == "3" || choixJoueur == "\"")
                {
                    Console.WriteLine("[1]Une Bombe [2]Potion de soins ");
                    string choixItem=Console.ReadLine();
                    if (choixItem == "1"|| choixItem== "&")
                    {
                        Console.WriteLine("Vous utiliser la bombe");
                    }
                    else if (choixItem=="2"|| choixItem=="é")
                    {
                    Console.WriteLine("Vous utiliser la potion de soin ");
                    }
                }
                else
                {
                    Console.WriteLine(equipe[i].nom + " begaye et passe son tour");
                }
        }

        public void lancerCombat(int nbCompagnon)
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
                    TourDuMonstre(nbCompagnon, equipe);
                    Console.ReadLine();
                }
                for ( int i = 0; i<= nbCompagnon;i++ ) 
                { 
                    if(equipe[i].PV > 0)
                    {
                        tourEquipe(i);
                    }
                    else
                    {
                        Console.WriteLine(equipe[i].nom +" a périe");
                    }
                }                
                if (fuirMonstre >= 2)
                {
                    Console.WriteLine("Le monstre fuit");
                }
            }
        }
    }
}