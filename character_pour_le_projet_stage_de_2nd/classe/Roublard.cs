using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal class Roublard : Hero
    {

        public ClasseHero classePerso = ClasseHero.GUERRIER;

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
            Fval = 12 + lvl;
            Dval = 16 + lvl;
            Conval = 9 + lvl;
            Ival = 10 + lvl / 2;
            Sval = 10 + lvl / 2;
            Chval = bonusCaracteristiques["CONSTITUTION"] + lvl + 10;

            caracteristiques = new Dictionary<string, int>();
            caracteristiques["FORCE"] = Fval;
            caracteristiques["DEXTERITE"] = Dval;
            caracteristiques["CONSTITUTION"] = Conval;
            caracteristiques["INTELIGENCE"] = Ival;
            caracteristiques["SAGESSE"] = Sval;
            caracteristiques["CHARISME"] = Chval;

            GenrCarac(nomCarac, val);

        }
        public Roublard (string nom, int att, int lvl, int DAtt,int pv, int dmg,int ClArmure) : base(nom, att, lvl, DAtt,pv,dmg,ClArmure)
        {


            GenererCarac("FORCE", Fval);
            GenererCarac("DEXTERITE", Dval);
            GenererCarac("CONSTITUTION", Conval);
            GenererCarac("INTELIGENCE", Ival);
            GenererCarac("SAGESSE", Sval);
            GenererCarac("CHARISME", Chval);

            foreach (var caracteristique in caracteristiques)
            {
                GenrCarac(caracteristique.Key, caracteristique.Value);
            }
            DefPropriete(att, PV, dmg);

            Console.WriteLine(att);
            Console.WriteLine("Guerrier et j'ai " + caracteristiques["FORCE"] + " en Force !!!!  mais que  " + caracteristiques["DEXTERITE"] + " en dexteritées (-_-°) ET j'ai " + PV + " EN PV");
        }
        // Définir les propriété
        public void DefPropriete(int att, int pv, int dmg)
        {
            this.att = att;
            PV = 10 + bonusCaracteristiques["CONSTITUTION"] + lvl;
            this.dmg = this.att * bonusCaracteristiques["FORCE"];

        }


    }
}
#endregion