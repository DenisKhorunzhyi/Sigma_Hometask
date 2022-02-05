using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Dogs:IAnimals
    {
        
        public string Name { get; set; }
        public string Age { get; set; }

        public static implicit operator Dogs(Cats v)
        {
            throw new NotImplementedException();
        }
    }
}
