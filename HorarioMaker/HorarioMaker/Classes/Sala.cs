using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorarioMaker.Classes
{
    class Sala
    {
        public string NumeroSala { get; set; }
        public List<string> ListaDepublicidade { get; set; }
        public List<string> ListaDeDuracao { get; set; }     
        public List<string> ListaNomeFilmes { get; set; }   
        public List<Sessao> ListaSessoes { get; set; }

        public Sala (string numeroSala,List<string>listaDePublicidade, List<string> listaDeDuracao, List<string> nomeFilmes, List<Sessao> listaSessoes)
        {
            ListaDepublicidade = new List<string>();
            ListaDeDuracao = new List<string>();
            ListaNomeFilmes = new List<string>();
            ListaSessoes = new List<Sessao>();

            NumeroSala = numeroSala; 
            ListaDepublicidade = listaDePublicidade;
            ListaDeDuracao = listaDeDuracao;
            ListaNomeFilmes = nomeFilmes;
            ListaSessoes = listaSessoes;
        }
    }
}
