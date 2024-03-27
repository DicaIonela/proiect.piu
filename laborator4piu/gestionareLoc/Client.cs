using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionareLoc
{
    public class Client
    {
        public string Nume { get; set; }
        public int Varsta { get; set; }
        public bool EsteInLocatie { get; set; }

        public Client(string nume, int varsta)
        {
            Nume = nume;
            Varsta = varsta;
            EsteInLocatie = false;
        }
    }
}