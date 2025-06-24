using character_pour_le_projet_stage_de_2nd.classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd
{
    internal class Program 
    {

     




        static void Main(string[] args)
        {
           


            string nom;

            int PV = 0;
            int DAtt = 1;
            int att = 0;
            int lvl = 0;
            int dmg = 1;
            int ClArmure = 1;
            int MP = 1;

            Console.WriteLine("Bonjourd veuillez saisir votre nom");
            nom = Console.ReadLine();

            Map carte = new Map();
            carte.map();

            string choixClasse;
            Console.WriteLine(" \n\n Quel classe voulez vous choisir ?  \n[1] pour Guerrier   [2]pour Roublard [3]pour Mage [4] pour Prêtre \n (Pour votre première partie le Guerrier est conseiller)");
            choixClasse = Console.ReadLine();

            while (choixClasse != null)
            {
                if (choixClasse == "1" || choixClasse == "&")
                {
                    Guerrier joueur = new Guerrier(nom, 1, dmg, lvl, DAtt, PV, ClArmure);
                    Hero joueur2 = new Hero(nom, att, dmg, lvl, DAtt, PV, ClArmure);
                    Console.WriteLine("vous avez Choisie un Guerrier");
                    Monstre goule = new Monstre("goule", att, lvl, PV, dmg);
                    Combat combat = new Combat(goule, joueur);

                    combat.lancerCombat();


                }
                else if (choixClasse == "2" || choixClasse == "é")
                {
                    Roublard joueur = new Roublard(nom, att, dmg, lvl, DAtt, PV, ClArmure);
                    Console.WriteLine("vous avez Choisie un Roublard");
                }
                else if (choixClasse == "3" || choixClasse == "\"")
                {
                    Mage joueur = new Mage(nom, att, dmg, lvl, DAtt, PV, MP, ClArmure);
                    Console.WriteLine("vous avez Choisie un Mage");
                }
                else if (choixClasse == "4" || choixClasse == "'")
                {
                    Prêtre joueur = new Prêtre(nom, att, dmg, lvl, DAtt, PV, ClArmure);
                    Console.WriteLine("vous avez Choisie un Prêtre");
                }
                else
                {
                    Console.WriteLine("Vous avez appyer sur la mauvaise touche est vous avez contrarier le jeux ):<( ");
                }
            }

                Console.ReadLine();

        }

            
    
    }

}
    

