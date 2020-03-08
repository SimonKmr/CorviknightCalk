using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PokeCalk.PokemonTypeTable
{
    class TypesT
    {
        public static int TypeCount { get; set; } = 18;

        readonly TypeBonusTable typeBonuses;
        public enum Type
        {
            NoTypeSelected, Normal, Fighting, Flying, 
            Poison, Ground, Rock, Bug, 
            Ghost, Steel, Fire, Water,
            Grass, Electric, Psychic, Ice, 
            Dragon, Dark, Fairy
        }

        public enum PassiveImmunities
        { LightningRod, MotorDrive, VoltAbsorb, FlashFire, WaterAbsorb, StormDrain, DrySkin, Levitate, SapSipper, NoPassiveImmunity}

        //Attacker Defender https://bulbapedia.bulbagarden.net/wiki/Type
        public TypesT()
        {
            //loads the typeTable
            string json = string.Empty;
            using (StreamReader sr = new StreamReader("PokemonTypeTable.json"))
            {
                string line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    json += line;
                }
            }
            typeBonuses = JsonConvert.DeserializeObject<TypeBonusTable>(json);
        }
        
        public double GetPokemonDmgMultiplire(int attack, int PokemonType, int[] abilities)
        {
            int indexAttacker = attack;
            int indexDefender = PokemonType;
            return typeBonuses.typeBonuses[indexAttacker, indexDefender]*CheckForPassiveImmunities(abilities,attack);
        }

        public double GetPokemonDmgMultiplire(int attack, int PokemonType, int PokemonType2, int[] ability)
        {
            int indexAttacker = attack;
            int indexDefender = PokemonType;
            int indexDefender2 = PokemonType2;
            return typeBonuses.typeBonuses[indexAttacker, indexDefender] * typeBonuses.typeBonuses[indexAttacker, indexDefender2] * CheckForPassiveImmunities(ability, attack);
        }

        private double CheckForPassiveImmunities(int[] ability, int attacker)
        {
            if (attacker == (int) Type.Electric && (ability.Contains<int>(31) || ability.Contains<int>(78) || ability.Contains<int>(10)))
                return 0;
            else if (attacker == (int) Type.Fire && ability.Contains<int>(18))
                return 0;
            else if (attacker == (int) Type.Water && (ability.Contains<int>(11) || ability.Contains<int>(114) || ability.Contains<int>(87)))
                return 0;
            else if (attacker == (int) Type.Ground && ability.Contains<int>(26))
                return 0;
            else if (attacker == (int) Type.Grass && ability.Contains<int>(157))
                return 0;
            return 1;
        }
    }

    class TypeBonusTable
    {
        public double[,] typeBonuses { get; set; } 
    }
}
