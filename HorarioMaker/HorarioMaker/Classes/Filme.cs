using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorarioMaker.Classes
{
    class Filme
    {
        public string Titulo { get;  set; }
        public string Publicidade { get;  set; }
        public string Intervalo { get;  set; }
        public string Creditos { get;  set; }
        public string Duracao { get; set; }
        public List<Sessao> ListaDeSessoes { get;  set; }


        // Construtor para adicionar Filme sem ter a lista de sessões definida.
        public Filme(string titulo, string pub, string intervalo, string creditos, string duracao)
        {
            ListaDeSessoes = new List<Sessao>();
            Titulo = titulo;
            Publicidade = pub;
            Intervalo = intervalo;
            Creditos = creditos;
            Duracao = duracao;
        }

        // Construtor para adiccionar Filme com lista de sessoes definida.
        public Filme(string titulo, string pub, string intervalo, string creditos, string duracao, List<Sessao> listaSessoes)
        {
            ListaDeSessoes = listaSessoes;
            Titulo = titulo;
            Publicidade = pub;
            Intervalo = intervalo;
            Creditos = creditos;
            Duracao = duracao;
        }
       
    }
}
