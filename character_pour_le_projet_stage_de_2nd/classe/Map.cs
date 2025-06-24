using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    public partial class Map : IMap
    {
        public Map()
        {

        }
        public void map()
        {
            Console.WriteLine("Vous êtes sur la carte");
            string endroit;

            Console.WriteLine("Dans quel endroit voulez vous allez ? \n [1] Magasin [2] Taverne [3] Eglise [4] GuilDesAventurier [5] Donjons ");
            endroit = Console.ReadLine();

            if (endroit == "1" || endroit == "&")
            {
                Magasin();
            }
            else if (endroit == "2" || endroit == "é")
            {
                Taverne();
            }
            else if (endroit == "3" || endroit == "\"")
            {
                Eglise();
            }
            else if (endroit == "4" || endroit == "'")
            {
                GuilDesAventurier();
            }
            else if (endroit == "5" || endroit == "(")
            {
                Donjons();
            }
            else
            {
                Console.WriteLine("... Vous vous paumer et rechercher le village Pendant des heures en vain");
            }

        }
        public void Magasin()
        {
            Console.WriteLine("Vous êtes dans le magasin");
        }
        public void Taverne()
        {
            Console.WriteLine("Vous êtes dans la Taverne ");
        }
        public void Eglise()
        {
            Console.WriteLine("Vous êtes dans l'Eglise");
        }
        public void GuilDesAventurier()
        {
            Console.WriteLine("Vous êtes dans la Guil des Aventurier");
        }
        public void Donjons()
        {
            Console.WriteLine("Vous entrer dans le Donjon");
        }

    }
}
