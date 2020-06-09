using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorarioMaker.Classes
{
    class Sessao
    {        
        public string Inicio { get;  set; }
        public string Intervalo { get;  set; }
        public string Fim { get;  set; }
     
        public Sessao(string inicio, string intervalo, string fim)
        {
            Inicio = inicio;
            Intervalo = intervalo;
            Fim = fim;
        }
    }
}
