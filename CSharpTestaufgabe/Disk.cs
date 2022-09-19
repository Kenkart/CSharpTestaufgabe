using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTestaufgabe
{
    class Disk
    {
        public int size;

        public Disk(int size)
        {
            this.size = size;
        }

        public override string ToString()
        {
            return size.ToString();
        }
    }
}
