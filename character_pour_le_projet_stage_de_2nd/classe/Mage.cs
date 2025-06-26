using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal class Mage : Hero,IHero
    {
            public ClasseHero classePerso = ClasseHero.MAGE;

        #region Propriete
        new public int dmg { get; set; }
        new public int PV { get; set; }
        public int att { get; set; }
        public int Fval { get; set; }
        public int MP { get; set; } 

        public int Dval { get; set; }
        public int Conval { get; set; }
        public int Ival { get; set; }
        public int Sval { get; set; }
        public int Chval { get; set; }
        // GenererCarc
        public void GenererCarac(string nomCarac, int val)
        {
             Fval = 3 + lvl;
             Dval = 9 + lvl;
             Conval = 6 + lvl;
             Ival = 16 + lvl;
             Sval = 10 + lvl / 2;
             Chval = bonusCaracteristiques["CONSTITUTION"] + lvl + 10;

            caracteristiques = new Dictionary<string, int>();
            caracteristiques["FORCE"] = Fval;
            caracteristiques["DEXTERITE"] = Dval;
            caracteristiques["CONSTITUTION"] = Conval;
            caracteristiques["INTELIGENCE"] = Ival;
            caracteristiques["SAGESSE"] = Sval;
            caracteristiques["CHARISME"] = Chval;
            foreach(var caracteristique in caracteristiques)
            {
                GenrCarac(caracteristique.Key, caracteristique.Value);
            }
        }


        // Constructeur
        public Mage(string nom, int att, int lvl, int DAtt, int PV, int dmg,int MP,int ClArmure,int or) : base(nom, att, lvl, DAtt, PV,dmg, ClArmure,or)
        {

            GenererCarac("FORCE", Fval);
            GenererCarac("DEXTERITE", Dval);
            GenererCarac("CONSTITUTION", Conval);
            GenererCarac("INTELIGENCE", Ival);
            GenererCarac("SAGESSE", Sval);
            GenererCarac("CHARISME", Chval);
            
            GenrCarac("FORCE", Fval);
            GenrCarac("DEXTERITE", Dval);
            GenrCarac("CONSTITUTION", Conval);
            GenrCarac("INTELIGENCE", Ival);
            GenrCarac("SAGESSE", Sval);
            GenrCarac("CHARISME",Chval);

            DefPropriete(att, PVMax, dmg,MP);

            Console.WriteLine(att);
            Console.WriteLine("Je m'appelle" + nom + " et j'ai " + caracteristiques["FORCE"] + " en Force ):  mais j'ai  " + caracteristiques["INTELIGENCE"] + " en Inteligence !!! ET j'ai " + this.PV + " EN PV");
        }

        // Définir les propriété
        public void DefPropriete(int att, int PV, int dmg,int MP)
        {
            this.att = att;
            PVMax = 6 + bonusCaracteristiques["CONSTITUTION"] + lvl;
            this.PV = PVMax;
            this.dmg = this.att * bonusCaracteristiques["FORCE"];
            this.MP = caracteristiques["INTELIGENCE"] + bonusCaracteristiques["SAGESSE"];
        }

    }

}
#endregion