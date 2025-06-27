using System;
using System.Collections.Generic;
using System.Linq;
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
            AMonstre = WorldEngine.GetRandomValue(1, 1);
            if (AMonstre == 1)
            {
                int C = WorldEngine.GetRandomValue(0, nbCompagnon);
                for (int act=0;act == 0;)
                {
                    if (equipe[C].estMort == false)
                    {
                        Monstre.Attaquer(Monstre, equipe[C]);
                        Monstre.Blesser(Monstre, equipe[C]);
                        act = 1;
                    }
                    else
                    {
                        C = WorldEngine.GetRandomValue(0, nbCompagnon);
                    }
                }
            }
            else if (AMonstre == 2)
            {
                Monstre.Crier();
            }
        }
        //tour de l'equipe
        public void tourEquipe(int i ,Inventaire inventaire , int nbCompagnon)
        {
            string choixJoueur;
            if (equipe[i] is Prêtre)
            {
                Console.WriteLine("C'est au tour de " + equipe[i].nom + " Que faite vous ? \n [1] Ataquer [2]Crier [3]Utiliser un Objet [4] soigner un allier");
            }
            else
            {
                Console.WriteLine("C'est au tour de " + equipe[i].nom + " Que faite vous ? \n [1] Ataquer [2]Crier [3]Utiliser un Objet");
            }
                
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
                if (choixItem == "1" || choixItem == "&" && inventaire.inventaire.Exists(x => x is Bombe))
                {
                    Console.WriteLine("Vous utiliser la bombe");
                    Console.WriteLine("Vous utiliser la plus puissante magie qui existe en ce monde ... LA DYNAMITTE!!!");
                    Monstre.PV = 0;
                    Console.WriteLine("\n Mais le soufle de l'explosion vous inflige des dommage . . . ");
                    for (int O = 0; O <= nbCompagnon; O++)
                    {
                        equipe[O].PV = equipe[O].PV - WorldEngine.GetRandomValue(3, 5);
                    }
                    var bombe = inventaire.inventaire.FirstOrDefault(x => x is Bombe);
                    if (bombe != null) 
                    {
                        inventaire.inventaire.Remove(bombe);
                    }
                }
                else if (choixItem == "2" || choixItem == "é" && inventaire.inventaire.Exists(x => x is PotionSoin))
                {
                    Console.WriteLine("Vous utiliser la potion de soin ");
                    equipe[i].PV = equipe[i].PVMax;
                    Console.WriteLine(equipe[i].nom + "a regagner tous c'est PV ");
                }
                }
                else if (equipe[i] is Prêtre && choixJoueur == "4" || choixJoueur == "'")
                {
                    string Choixsoins;
                    Console.WriteLine("qui voulez vous soignez");
                     for (int s = 0; s<=nbCompagnon; s++)
                     {
                        Console.WriteLine("["+(s+1)+"] pour soigner"+equipe[s].nom);
                     }
                     Choixsoins = Console.ReadLine();
                    int f; 
                    if (Choixsoins == "1" || Choixsoins == "&")
                    {
                    f = 0;
                    equipe[f].PV= equipe[i].PV + WorldEngine.GetRandomValue(3, 5);
                    }
                    else if (Choixsoins == "2" || Choixsoins == "é")
                    {
                    f = 1;
                    equipe[f].PV = equipe[i].PV + WorldEngine.GetRandomValue(3, 5);
                }   
                    else if (Choixsoins == "3" || Choixsoins == "\"")
                    {
                    f = 1;
                    equipe[f].PV = equipe[i].PV + WorldEngine.GetRandomValue(3, 5);
                    }

                }
                else
                {
                Console.WriteLine(equipe[i].nom + " begaye et passe son tour");
                }
        }

        //L'Heure du DUDUDDUUUDU DUEL!!!
        public void lancerCombat(int nbCompagnon,Inventaire inventaire,int nbMort)
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
                if (equipe.Where(x => x != null).Any(x => !x.estMort))
                {
                    for (int i = 0; i <= nbCompagnon; i++)
                    {
                        if (!equipe[i].estMort)
                        {
                            tourEquipe(i, inventaire, nbCompagnon);
                        }
                    }
                }
                else
                {
                    break;
                }

                if (fuirMonstre >= 2)
                {
                    Console.WriteLine("Le monstre fuit");
                }
            }
        }
    }
}