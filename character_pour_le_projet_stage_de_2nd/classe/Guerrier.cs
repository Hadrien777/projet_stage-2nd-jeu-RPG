using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace character_pour_le_projet_stage_de_2nd.classe
{
    internal class Guerrier : Hero, IHero , ICharacter
    {
        public ClasseHero classePerso = ClasseHero.GUERRIER;

        #region Propriete
        new public int dmg { get; set; }
        new public int PV { get; set; }
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
             Fval = 14 + lvl;
             Dval = 7 + lvl;
             Conval = 16 + lvl;
             Ival = 4 + lvl / 2;
             Sval = 4 + lvl / 2;
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

        // Constructeur
        public Guerrier(string nom, int att, int lvl, int DAtt, int PV,int dmg,int ClArmure,int or) : base(nom, att, dmg,lvl, DAtt, PV, ClArmure,or)
        {
            GenererCarac("FORCE", Fval);
            GenererCarac("DEXTERITE", Dval);
            GenererCarac("CONSTITUTION", Conval);
            GenererCarac("INTELIGENCE", Ival);
            GenererCarac("SAGESSE", Sval);
            GenererCarac("CHARISME", Chval);

            foreach( var caracteristique in caracteristiques)
            {
                GenrCarac(caracteristique.Key, caracteristique.Value);
            }
            DefPropriete(att,PVMax, dmg);

            Console.WriteLine(att);
            Console.WriteLine("je m'appelle "+ nom +" et j'ai " +  caracteristiques["FORCE"] + " en Force !!!!  mais que  " + caracteristiques["DEXTERITE"] + " en dexteritées (-_-°) ET j'ai " + this.PV + " EN PV");
        }

        // Définir les propriété
        public void DefPropriete(int att,int PV, int dmg)
        {
            this.att = att;
            PVMax = 10 + bonusCaracteristiques["CONSTITUTION"] + lvl;
            this.PV = PVMax;
            this.dmg = this.att * bonusCaracteristiques["FORCE"] + 4;
        }
    }
}

#endregion