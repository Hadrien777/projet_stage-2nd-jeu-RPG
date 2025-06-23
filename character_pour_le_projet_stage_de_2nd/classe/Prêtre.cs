using System;
using System.Collections.Generic;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal class Prêtre : Hero
    {
        public ClasseHero classePerso = ClasseHero.MAGE;

        #region Propriete
        public int dmg { get; set; }
        public int PV { get; set; }
        public int att { get; set; }

        public int Fval { get; set; }
        public int Dval { get; set; }
        public int Conval { get; set; }
        public int Ival { get; set; }
        public int Sval { get; set; }
        public int Chval { get; set; }






        // GenererCarc
        public void GenererCarac(string nomCarac, int val)
        {
            Fval = 4 + lvl;
            Dval = 10 + lvl;
            Conval = 4 + lvl;
            Ival = 10 + lvl/2;
            Sval = 16 + lvl;
            Chval = bonusCaracteristiques["CONSTITUTION"] + lvl + 10;

            caracteristiques = new Dictionary<string, int>();
            caracteristiques["FORCE"] = Fval;
            caracteristiques["DEXTERITE"] = Dval;
            caracteristiques["CONSTITUTION"] = Conval;
            caracteristiques["INTELIGENCE"] = Ival;
            caracteristiques["SAGESSE"] = Sval;
            caracteristiques["CHARISME"] = Chval;
            foreach (var caracteristique in caracteristiques)
            {
                GenrCarac(caracteristique.Key, caracteristique.Value);
            }
        }

        //constructeur
        public Prêtre(string nom, int att, int lvl, int DAtt, int PV, int dmg) : base(nom, att, lvl, DAtt, PV,  dmg)
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
            GenrCarac("CHARISME", Chval);


            DefPropriete(att, PV, dmg);

            Console.WriteLine(att);
            Console.WriteLine("Prêtre et j'ai " + caracteristiques["FORCE"] + " en Force ):  mais j'ai  " + caracteristiques["INTELIGENCE"] + " en Inteligence !!! ET j'ai " + PV + " EN PV");
        }
        // Définir les propriété
        public void DefPropriete(int att, int pv, int dmg)
        {
            this.att = 1;
            PV = 6 + bonusCaracteristiques["CONSTITUTION"] + lvl;
            this.dmg = this.att * bonusCaracteristiques["FORCE"];
        }
    }
}
#endregion