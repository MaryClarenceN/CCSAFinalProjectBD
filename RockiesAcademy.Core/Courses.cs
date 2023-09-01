using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockiesAcademy.Core
{
    public class Courses 
    {
        public virtual string Name { get; set; }

        public List<Student> students { get; set; } = new List<Student>();
        public List<Trainer> trainer { get; set; } = new List<Trainer>();
        
    }
}


