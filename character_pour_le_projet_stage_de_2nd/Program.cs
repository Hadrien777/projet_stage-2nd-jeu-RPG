﻿using character_pour_le_projet_stage_de_2nd.classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd
{
    public class Program : IMap
    {
        #region Proprieté
        public string nom { get; set; }
        public int PV { get; set; }
        public int DAtt { get; set; }
        public int att { get; set; }
        public int lvl { get; set; }
        public int dmg { get; set; }
        public int ClArmure { get; set; }
        public int MP { get; set; }
        public int nbCompagnon { get; set; }
        public int or { get; set; }
        public int nbMort { get; set; }

        public Inventaire inventaire = new Inventaire(new List<Item>());

        public static IHero[] equipe = new Hero[3];

        static void Main(string[] args)
        {
            string nom;
            int PV = 10;
            int DAtt = 2;
            int att = 1;
            int lvl = 1;
            int dmg = 10;
            int ClArmure = 1;
            int or = 10;
            int MP = 1;

            Console.WriteLine("Bonjourd veuillez saisir votre nom");
            nom = Console.ReadLine();

            IMap carte = new Program();

            string choixClasse = "";

            Hero joueur = new Hero(nom, att, dmg, lvl, DAtt, PV, ClArmure, or);

            while (choixClasse != "1" && choixClasse != "&"&& choixClasse != "2" && choixClasse != "é" && choixClasse != "3" && choixClasse != "\"" && choixClasse != "4" && choixClasse != "'" )
            {
                Console.WriteLine(" \n\n Quel classe voulez vous choisir ?  \n[1] pour Guerrier   [2]pour Roublard [3]pour Mage [4] pour Prêtre \n (Pour votre première partie le Guerrier est conseiller)");
                choixClasse = Console.ReadLine();
                if (choixClasse == "1" || choixClasse == "&")
                {
                    joueur = new Guerrier(nom, 1, dmg, lvl, DAtt, PV, ClArmure, or);
                    Console.WriteLine("vous avez Choisie un Guerrier");
                }
                else if (choixClasse == "2" || choixClasse == "é")
                {
                    joueur = new Roublard(nom, att, dmg, lvl, DAtt, PV, ClArmure, or);
                    Console.WriteLine("vous avez Choisie un Roublard");
                }
                else if (choixClasse == "3" || choixClasse == "\"")
                {
                    joueur = new Mage(nom, att, dmg, lvl, DAtt, PV, MP, ClArmure, or);
                    Console.WriteLine("vous avez Choisie un Mage");
                }
                else if (choixClasse == "4" || choixClasse == "'")
                {
                    joueur = new Prêtre(nom, att, dmg, lvl, DAtt, PV, ClArmure, or  );
                    Console.WriteLine("vous avez Choisie un Prêtre");
                }
                else
                {
                    Console.WriteLine("Vous avez appyer sur la mauvaise touche est vous avez contrarier le jeux ):<( ");
                }
                joueur.or = 10;
                equipe[0] = joueur;
                carte.map(joueur);
            }
        }
        #endregion



        //Carte Du Monde
        public void Magasin(Hero joueur)
       {
            bool sortie = false;
            string choixObjet = "";
            
            while (sortie == false)
            {
                Console.WriteLine("Vous êtes dans le magasin il y a en boutique : \n [1]Bombe(tue les ennemie instantanement:10 piece d'or) [2]épée(ameliore les dmg :5 piece d'or) \n\n [3]un arc(agrendit la distence d'attaque: 5 piece d'or) [4]une potion de soins(soigne tous vaux PV : 10 Piece d'or) \n\n vous avez "+joueur.or +" d'or [5]partir ");
                choixObjet = Console.ReadLine();
                if (choixObjet == "1" || choixObjet == "&")
                {
                    Console.WriteLine("vous achheter une bombe");
                    joueur.or = joueur.or - 10;
                    inventaire.inventaire.Add(new Bombe(1)); 
                }
                else if (choixObjet == "2" || choixObjet == "é")
                {
                    Console.WriteLine("vous achetez une épée");
                    joueur.or = joueur.or - 5;
                    inventaire.inventaire.Add(new Epee(1));
                }
                else if (choixObjet == "3" || choixObjet == "\"")
                {
                    Console.WriteLine("Vous acheter un arc ");
                    joueur.or = joueur.or - 5;
                    inventaire.inventaire.Add(new Arc(1));
                }
                else if (choixObjet == "4" || choixObjet == "'")
                {
                    Console.WriteLine("Vous achetez une potion de soin");
                    joueur.or = joueur.or - 10;
                    inventaire.inventaire.Add(new PotionSoin(1));
                }
                else if (choixObjet == "(" || choixObjet == "5")
                {
                    sortie = true;
                }
                else
                {
                    Console.WriteLine("vous rester planter devant la vitrine pendant des heures jusqu'a ce que le marchant en est marre et vous jette a la porte");
                    sortie = true;
                }
            }
        }
       public void Taverne(Hero joueur)
             {
                
                string ChoixJoueur;
                bool sortir = false;
                while (sortir == false)
                {
                    Console.WriteLine("Vous êtes dans la Taverne, que voulez vous faire ? \n [1]se reposer [2]recruter un nouveau compagnion (10 piece d'or) [3]sortir");
                    Console.WriteLine("Vous avez "+ joueur.or+" piece d'or");
                   ChoixJoueur = Console.ReadLine();
                    if (ChoixJoueur == "1" || ChoixJoueur == "&")
                    {
                        Console.WriteLine("vous passer une merveilleuse nuit");
                        Console.WriteLine("PV =" + joueur.PV);
                        for(int i = 0; i<=nbCompagnon; i++)
                        {
                        equipe[i].PV = equipe[i].PVMax;
                            Console.WriteLine(equipe[i].nom+" à "+equipe[i].PV +" PV");
                        }
                    }
                    else if (ChoixJoueur == "2" || ChoixJoueur == "é")
                    {

                        if (joueur.or < 10)
                        {
                            Console.WriteLine("Tavernier: Vous êtes trop PAUUUVRE revener quand vous serez plus $RICHE$!\n");
                        }
                        else if (nbCompagnon < 2)
                        {
                            Console.WriteLine(" \n\n Quel Aventurier vouler vous choisir ?  \n[1] pour un Guerrier   [2]pour un Roublard [3]pour un Mage [4] pour un Prêtre");
                            string ChoixCompagnon = "";
                            joueur.or = joueur.or - 10;

                            while (ChoixCompagnon == "")
                            {
                                ChoixCompagnon = Console.ReadLine();
                                if (ChoixCompagnon == "1" || ChoixCompagnon == "&")
                                {
                                    Hero compagnon = new Guerrier("Jean", 1, dmg, lvl, DAtt, PV, ClArmure, or);
                                    Console.WriteLine("vous avez Choisie un Guerrier");
                                    nbCompagnon++;
                                    equipe[nbCompagnon] = compagnon;
                                }
                                else if (ChoixCompagnon == "2" || ChoixCompagnon == "é")
                                {
                                    Hero compagnon = new Roublard("Michelle", att, dmg, lvl, DAtt, PV, ClArmure, or);
                                    Console.WriteLine("vous avez Choisie un Roublard");
                                    nbCompagnon++;
                                    equipe[nbCompagnon] = compagnon;
                                }
                                else if (ChoixCompagnon == "3" || ChoixCompagnon == "\"")
                                {
                                    Hero compagnon = new Mage("Maria", att, dmg, lvl, DAtt, PV, MP, ClArmure, or);
                                    Console.WriteLine("vous avez Choisie un Mage");
                                    nbCompagnon++;
                                    equipe[nbCompagnon] = compagnon;
                                }
                                else if (ChoixCompagnon == "4" || ChoixCompagnon == "'")
                                {
                                    Hero compagnon = new Prêtre("Uber", att, dmg, lvl, DAtt, PV, ClArmure , or);
                                    Console.WriteLine("vous avez Choisie un Prêtre");
                                    nbCompagnon++;
                                    equipe[nbCompagnon] = compagnon;
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Vous avez appyer sur la mauvaise touche est vous avez contrarier le jeux ):<( ");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vous avez deja un groupe de 3 personne");
                        }
                    }
                    else if (ChoixJoueur == "3" || ChoixJoueur == "\"")
                    {
                    sortir = true;
                    }
                }

             }
       public void Eglise(Hero joueur)
        {
            string choixEglise; 
            Console.WriteLine("Vous êtes dans l'Eglise, que voulez vous faire ? [1]Ressuciter un hero mort (30 piece d'or) [2]Partir");
            choixEglise = Console.ReadLine();
            if (choixEglise == "1" || choixEglise == "&")
            {
                if (equipe.Where(x => x != null).Any(x => x.estMort))
                {
                        string choixR;
                        int R;
                        Console.WriteLine("qui voulez vous ressuciter [1]"+equipe[1].nom+" [2]"+equipe[2].nom +" [3]"+ equipe[1].nom);
                        choixR = Console.ReadLine();
                        if (choixR == "1" || choixR == "&")
                        {
                            R = 0;
                            if (equipe[R].estMort == false)
                            {
                                Console.WriteLine("ce personnage est Vivant");
                            }
                            else
                            {
                                equipe[R].estMort = false;
                            }
                        }
                        else if (choixR == "é" || choixR == "2")
                        {
                            R = 1;
                            if (equipe[R].estMort == false)
                            {
                                Console.WriteLine("ce personnage est Vivant");
                            }
                            else
                            {
                                equipe[R].estMort = false;
                            }
                        }
                        else if (choixR == "3" || choixR == "\"")
                        {
                            R = 2;
                            if (equipe[R].estMort == false)
                            {
                                Console.WriteLine("ce personnage est Vivant");
                            }
                            else
                            {
                                equipe[R].estMort = false;
                            }
                        }
                }
                else
                {
                    Console.WriteLine("personne dans votre equipe est mort\n");
                }
            }
            else if (choixEglise == "2" || choixEglise == "é")
            {
               
            }
        }
       public void GuilDesAventurier(Hero joueur)
       {
            Console.WriteLine("Vous êtes dans la Guilde des Aventurier");
       }
       public void Donjons(IHero joueur)
       {
            Console.WriteLine("Vous entrer dans le Donjon");
            Monstre goule = new Monstre("goule", 1, WorldEngine.GetRandomValue(1+joueur.lvl, 5+joueur.lvl), PV, dmg);
            Combat combat = new Combat(goule, equipe);
            combat.lancerCombat(nbCompagnon, inventaire, nbMort);
             if (joueur.PV >0)
             {
               Console.WriteLine("Victoire vous obtener 10 or et 1 niveau ");
               joueur.or = joueur.or + 10;
                for (int i = 0;i<=nbCompagnon;i++ )
                {
                    equipe[i].lvl++;
                }
             }
            Console.ReadLine();
       }
       public void map(Hero joueur)
       {
            Console.WriteLine("Vous êtes sur la carte");
            string endroit;
            bool quitterLeJeu = false;
            while (quitterLeJeu == false)
            {
                Console.WriteLine("Dans quel endroit voulez vous allez ? \n [1] Magasin [2] Taverne [3] Eglise [4] GuilDesAventurier [5] Donjons [Q]Pour quitter le jeu");
                endroit = Console.ReadLine();
                if (endroit == "1" || endroit == "&")
                {
                    Magasin(joueur);
                }
                else if (endroit == "2" || endroit == "é")
                {
                    Taverne(joueur);
                }
                else if (endroit == "3" || endroit == "\"")
                {
                    Eglise(joueur);
                }
                else if (endroit == "4" || endroit == "'")
                {
                    GuilDesAventurier(joueur);
                }
                else if (endroit == "5" || endroit == "(")
                {
                    Donjons(joueur);
                }
                else if (endroit == "Q" || endroit == "q")
                {
                    quitterLeJeu = true;
                }
                else
                {
                    Console.WriteLine("... Vous vous paumer et rechercher le village Pendant des heures en vain");
                }
            }
       }
    }
} 