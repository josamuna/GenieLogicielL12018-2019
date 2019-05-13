using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonneLib
{
    public abstract class Arme
    {
        void test1()
        {
            int a = 4 + 5;
            Console.WriteLine(string.Format("La valeur de a est : '{0}'"
                ,a));
        }

        public abstract int test2();
    }
}
