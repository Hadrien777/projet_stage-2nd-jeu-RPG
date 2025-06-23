using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    public static class WorldEngine
    {
        public static Random rnd = new Random();
        public const int BASEXP = 300;
        public const double MULTEXPSUIVANT = 1.5;

        public static int GetRandomValue(int min, int max)
        {
            max += 1;
            return rnd.Next(min, max);
        }
        public static int GetExpSuivantParNiveau(int lvl)
        {
            int[] xpSuivant = new int[10];
            xpSuivant[0] = BASEXP;

            for (int i = 1; i < xpSuivant.Length; i++)
            {
                xpSuivant[i] = (int)Math.Floor(xpSuivant[i - 1] * MULTEXPSUIVANT);
            }

            return xpSuivant[lvl];
        }

       
    }
}
