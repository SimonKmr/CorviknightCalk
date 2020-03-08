using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorviknightCalk.PokemonEntity
{
    public class SaveE
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int AbilityID { get; set; }
        public int[] MoveIDs { get; set; }
        public ESaveStats[] Stats { get; set; }
    }
    public class ESaveStats
    {
        public int DeterminantValue { get; set; }
        public int EffortValues { get; set; }
    }
}
