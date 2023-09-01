using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockiesAcademy.Core
{
    public class Trainer 
    {
        public int TrainerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Shift> Shifts { get; set; }
    }


    public class Shift
    {
        public virtual List<Trainer> TrainerOnShift { get; set; }
    }
}
