using character_pour_le_projet_stage_de_2nd.classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd
{
    internal class Program :  IMap
    {
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
            int nbCompagnon = 0;

            Console.WriteLine("Bonjourd veuillez saisir votre nom");
            nom = Console.ReadLine();

            IMap carte = new Program();

            string choixClasse = "";

            Hero joueur = new Hero(nom, att, dmg, lvl, DAtt, PV, ClArmure, or);

            while (choixClasse == "")
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
                }
                else if (choixObjet == "2" || choixObjet == "é")
                {
                    Console.WriteLine("vous achetez une épée");
                }
                else if (choixObjet == "3" || choixObjet == "\"")
                {
                    Console.WriteLine("Vous acheter un arc ");
                }
                else if (choixObjet == "4" || choixObjet == "'")
                {
                    Console.WriteLine("Vous achetez une potion de soin");
                }
                else if (choixObjet == "("|| choixObjet == "5")
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
                    ChoixJoueur = Console.ReadLine();
                    if (ChoixJoueur == "1" || ChoixJoueur == "&")
                    {
                        Console.WriteLine("vous passer une merveilleuse nuit");
                        joueur.PV = joueur.PVMax;
                    Console.WriteLine("PV =" + joueur.PV);
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
                                    Hero compagnon = new Guerrier(nom, 1, dmg, lvl, DAtt, PV, ClArmure, or);
                                    Console.WriteLine("vous avez Choisie un Guerrier");
                                    nbCompagnon++;
                                    equipe[nbCompagnon] = compagnon;
                                }
                                else if (ChoixCompagnon == "2" || ChoixCompagnon == "é")
                                {
                                    Hero compagnon = new Roublard(nom, att, dmg, lvl, DAtt, PV, ClArmure, or);
                                    Console.WriteLine("vous avez Choisie un Roublard");
                                    nbCompagnon++;
                                    equipe[nbCompagnon] = compagnon;
                                }
                                else if (ChoixCompagnon == "3" || ChoixCompagnon == "\"")
                                {
                                    Hero compagnon = new Mage(nom, att, dmg, lvl, DAtt, PV, MP, ClArmure, or);
                                    Console.WriteLine("vous avez Choisie un Mage");
                                    nbCompagnon++;
                                    equipe[nbCompagnon] = compagnon;
                                }
                                else if (ChoixCompagnon == "4" || ChoixCompagnon == "'")
                                {
                                    Hero compagnon = new Prêtre(nom, att, dmg, lvl, DAtt, PV, ClArmure , or);
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
            Console.WriteLine("Vous êtes dans l'Eglise");
        }
       public void GuilDesAventurier(Hero joueur)
        {
            Console.WriteLine("Vous êtes dans la Guil des Aventurier");
        }
       public void Donjons(IHero joueur)
             {

                Console.WriteLine("Vous entrer dans le Donjon");

                Monstre goule = new Monstre("goule", 1, WorldEngine.GetRandomValue(1, 5), PV, dmg);
                Combat combat = new Combat(goule, joueur);
                combat.lancerCombat();
                if (joueur.PV >0)
                {
                    Console.WriteLine("Victoire vous obtener 10 or");
                    joueur.or = joueur.or + 10;
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