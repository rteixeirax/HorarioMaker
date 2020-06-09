using HorarioMaker.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;

namespace HorarioMaker
{
    class Model
    {
        string Filmes_saveFolderPath = @"ListaDefilmes.xml"; // Define o local onde ira ser gravado o ficheiro Xml com os filmes. Default = "Listadefilmes.xml".
        string Salas_saveFolderPath = @"ListaDeSalas.xml";  // Define o local onde ira ser gravado o ficheiro Xml com o horario. Default = "Horario.xml".
        string Excel_saveFolderPath = @"Horario.xlsx"; // Define o local onde grava o ficheira Excel com o horario. Default = "Horario.xlsx";
        int duracaoIntervalo = 7; // duração do intervalo da sessao é de 7 minutos.

        public List<Filme> ListaDeFilmes { get; private set; }
        public List<Sala> ListaDeSalas { get; private set; }      

        public Model()
        {
            ListaDeFilmes = new List<Filme>();
            ListaDeSalas = new List<Sala>();           
        }

        // ------------------------------------- Filmes -----------------------------------------------------

        //Método para adicionar filme à lista de filmes.
        public void AdicionarFilme(string nome, string pub, string intervalo, string creditos, string duracao)
        {
            ListaDeFilmes.Add(new Filme(nome, pub, intervalo, creditos, duracao));
            ListaDeFilmes = ListaDeFilmes.OrderBy(aux => aux.Titulo).ToList(); // Ordena por ordem alfabética
            Program.v_horarioMaker.ApresentarListaDeFilmes();
        }

        //Método para editar Filme.
        public void EditarFilme(int indice, string titulo, string publicidade, string intervalo, string creditos, string duracao)
        {
            //Caso o nome do filme tenha sido alterado, verifica se o mesmo esta na lista de horarios.
            //caso esteja, faz a alteração do nome na lista de horarios.
            //É necessário para quando for preciso carregar as sessoes para o horario, a operação seja feita corretamente.
            if (titulo != ListaDeFilmes[indice].Titulo) 
            {
                foreach (Sala sala in ListaDeSalas)
                {
                    for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                    {
                        if (sala.ListaNomeFilmes[i] == ListaDeFilmes[indice].Titulo)
                        {
                            sala.ListaNomeFilmes[i] = titulo;
                            
                        }
                    }
                }
            }

            ListaDeFilmes[indice].Titulo = titulo;
            ListaDeFilmes[indice].Publicidade = publicidade;
            ListaDeFilmes[indice].Intervalo = intervalo;
            ListaDeFilmes[indice].Creditos = creditos;
            ListaDeFilmes[indice].Duracao = duracao;
            
            if (ListaDeFilmes[indice].ListaDeSessoes.Count != 0) // Caso tenha sessoes, volta a calcular os tempos de intervalo e fim de filme.
            {
                List<string> listaSessoes = new List<string>();

                foreach (Sessao sessao in ListaDeFilmes[indice].ListaDeSessoes)
                {
                    listaSessoes.Add(sessao.Inicio);
                }

                AdicionarSessoes(indice, listaSessoes);
            }

            ListaDeFilmes = ListaDeFilmes.OrderBy(aux => aux.Titulo).ToList(); // Ordena por ordem alfabética

            Program.v_horarioMaker.ApresentarListaDeFilmes();
        }

        //Método para eliminar Filme da lista de Filmes.
        public void EliminarFilme(int indice)
        {
            if (MessageBox.Show("Eliminar '" + ListaDeFilmes[indice].Titulo + "' ?", "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Caso o filme tenha sido eliminado, verifica se o mesmo esta na lista de horarios.
                //caso esteja, remove o filme da lista de horarios.
                //É necessário para quando for preciso carregar as sessoes para o horario, a operação seja feita corretamente.
                int count = 0;
                bool flag = false;

                foreach(Sala sala in ListaDeSalas)
                {
                    for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                    {
                        if(sala.ListaNomeFilmes[i] == ListaDeFilmes[indice].Titulo)
                        {
                            ListaDeSalas.RemoveAt(count);
                            flag = true;
                            break;
                        }
                    }
                    if(flag == true)
                    {
                        break;
                    }
                    count++;
                }

                ListaDeFilmes.RemoveAt(indice);
                Program.v_horarioMaker.ApresentarListaDeFilmes();
            }
        }

        //Método para adicionar sessoes.
        public void AdicionarSessoes(int indice, List<string> listaSessoes)
        {
            ListaDeFilmes[indice].ListaDeSessoes.Clear();

            foreach (string sessao in listaSessoes)
            {
                ListaDeFilmes[indice].ListaDeSessoes.Add(CalcularTempos(indice, sessao));               
            }
        }

        //Método para calcular Duração do filme.
        public string CalcularDuracao(string pub, string creditos)
        {
            string[] aux = creditos.Split(':');

            // Conversão para segundos.
            int creditos_segundos = (((int.Parse(aux[0]) * 60) + duracaoIntervalo + (int.Parse(aux[1]))) * 60) + (int.Parse(aux[2]));
            int publicidade_segundos = (int.Parse(pub)) * 60;

            // Soma dos tempos.
            int tempoFilmeSegundos = publicidade_segundos + creditos_segundos;

            // Conversão para formato Hora : Minuto : Segundo
            TimeSpan tempo = TimeSpan.FromSeconds(tempoFilmeSegundos);

            string TempoFilme = tempo.Hours.ToString("00") + ":" + tempo.Minutes.ToString("00") + ":" + tempo.Seconds.ToString("00");

            return TempoFilme;
        }

        // ------------------------- Calcular Tempos ----------------------------------------------------------


        //Método para calcular os tempos de intervalo e final de cada sessao.
        public Sessao CalcularTempos(int indice, string inicioSessao)
        {            
            string[] aux;

            // Conversão dos tempos para segundos
            aux = inicioSessao.Split(':');
            int inicio_segundos = (((int.Parse(aux[0])) * 60) + (int.Parse(aux[1]))) * 60;

            int publicidade_segundos = (int.Parse(ListaDeFilmes[indice].Publicidade)) * 60;

            aux = ListaDeFilmes[indice].Intervalo.Split(':');
            int intervalo_segundos = ((((int.Parse(aux[0])) * 60) + (int.Parse(aux[1]))) * 60) + (int.Parse(aux[2]));

            aux = ListaDeFilmes[indice].Creditos.Split(':');
            int creditos_segundos = (((int.Parse(aux[0]) * 60) + duracaoIntervalo + (int.Parse(aux[1]))) * 60) + (int.Parse(aux[2]));

            // Calculo dos tempos em segundos
            int temp_intervalo = inicio_segundos + publicidade_segundos + intervalo_segundos;
            int temp_creditos = inicio_segundos + publicidade_segundos + creditos_segundos;

            // Conversão para formato Hora : Minuto : Segundo
            TimeSpan tempo = TimeSpan.FromSeconds(temp_intervalo);
            string intervalo = tempo.Hours.ToString("00") + ":" + tempo.Minutes.ToString("00") + ":" + tempo.Seconds.ToString("00");

            tempo = TimeSpan.FromSeconds(temp_creditos);
            string fim = tempo.Hours.ToString("00") + ":" + tempo.Minutes.ToString("00") + ":" + tempo.Seconds.ToString("00");

            // Preencho a sessao com os tempos e retorno a mesma para ser inserida na lista
            Sessao sessaoDefinida = new Sessao(inicioSessao, intervalo, fim);

            return sessaoDefinida;
        }


        // ------------------------------- Hórário Salas --------------------------------------------------------------------------


        //Método para retornar o indice do filme na lista de filmes.
        public int RetornarIndice(string nomefilme)
        {
            int indice = 0;

            foreach(Filme filme in ListaDeFilmes)
            {
                if(filme.Titulo == nomefilme)
                {
                    return indice;
                }

                indice ++;
            }
                       
            return -1; // Retorna -1 caso não encontre o filme.
        }

        //Método Para Verificar se há colisão entre sessoes
        public bool VerificarColisoesEntreSessoes(string filmeDaSala, int indiceDefilmeAdicionar)
        {
            for (int i = 0; i < ListaDeFilmes[indiceDefilmeAdicionar].ListaDeSessoes.Count; i++)
            {
                foreach (Sessao sessao in ListaDeFilmes[RetornarIndice(filmeDaSala)].ListaDeSessoes)
                {
                    if (sessao.Inicio == ListaDeFilmes[indiceDefilmeAdicionar].ListaDeSessoes[i].Inicio)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //Método para adicionar Sala à Lista de Horarios
        public void AdicionarSala(string ID_Sala, List<string> listaDePublicidade, List<string> listaDeDuracao, List<string> listaFilmesSala, List<Sessao> listaSessaoSala)
        {            
            ListaDeSalas.Add(new Sala(ID_Sala, listaDePublicidade, listaDeDuracao, listaFilmesSala, listaSessaoSala));
            ListaDeSalas = ListaDeSalas.OrderBy(aux => aux.NumeroSala).ToList(); // Ordena por ordem de sala
        }

        //Método para preencher a Sala com os dados de filme, numero sala e sessoes.
        public void PreencherDadosSessao(string ID_sala, List<string> NomeFilmes)
        {
            List<string> listaFilmesSala = new List<string>();
            List<Sessao> listaSessaoSala = new List<Sessao>();
            List<string> listaPublicidade = new List<string>();
            List<string> listaDuracao = new List<string>();

            for (int i = 0; i < NomeFilmes.Count; i++)
            {
                listaFilmesSala.Add(NomeFilmes[i]); // Carrega a lista com o Nome do filme.
                listaPublicidade.Add(ListaDeFilmes[RetornarIndice(NomeFilmes[i])].Publicidade); // Carrega a lista com a pub do filme.
                listaDuracao.Add(ListaDeFilmes[RetornarIndice(NomeFilmes[i])].Duracao); // Carrega a lista com a duração do filme.

                foreach (Sessao sessao in ListaDeFilmes[RetornarIndice(NomeFilmes[i])].ListaDeSessoes)
                {
                    listaSessaoSala.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim)); // Carrega a lista das Sessoes para a sala.
                }
            }

            listaSessaoSala = listaSessaoSala.OrderBy(aux => aux.Inicio).ToList(); // Ordena por ordem de inicio 
            AdicionarSala(ID_sala, listaPublicidade, listaDuracao, listaFilmesSala, listaSessaoSala);
        }

        //Método para atualizar os dados das Sessões. Caso os tempos do filme sejam alterados, com este método garante que os dados inseridos no horario estão sempre corretos.
        public void AtualizarDadosSessoes(string ID_Sala, List<string> listaDePublicidade, List<string> listaDeDuracao, List<string> listaFilmesSala, List<Sessao> listaSessaoSala)
        {
            List<Sessao> Nova_listaSessaoSala = new List<Sessao>();
            List<string> Nova_listaPublicidade = new List<string>();
            List<string> Nova_listaDuracao = new List<string>();

            foreach (Sala sala in ListaDeSalas) // Elimina a lista de sessoes para depois adicionar uma nova atualizada.
            {
                if (sala.NumeroSala == ID_Sala)
                {
                    sala.ListaSessoes.Clear();
                    sala.ListaDepublicidade.Clear();
                    sala.ListaDeDuracao.Clear();
                    break;
                }
            }

            for (int i = 0; i < listaFilmesSala.Count; i++)
            {
                Nova_listaPublicidade.Add(ListaDeFilmes[RetornarIndice(listaFilmesSala[i])].Publicidade); // Carrega a lista com a pub do filme.
                Nova_listaDuracao.Add(ListaDeFilmes[RetornarIndice(listaFilmesSala[i])].Duracao); // Carrega a lista com a duração do filme.

                foreach (Sessao sessao in ListaDeFilmes[RetornarIndice(listaFilmesSala[i])].ListaDeSessoes)
                {
                    Nova_listaSessaoSala.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim)); // Carrega a lista das Sessoes para a sala.
                }
            }

            Nova_listaSessaoSala = Nova_listaSessaoSala.OrderBy(aux => aux.Inicio).ToList(); // Ordena por ordem de inicio
            AdicionarSalaComTemposAtualizados(ID_Sala, Nova_listaPublicidade, Nova_listaDuracao, listaFilmesSala, Nova_listaSessaoSala);
        }

        //Método para Inserir Dados das sessoes atualizadas à lista de Horario.
        public void AdicionarSalaComTemposAtualizados(string ID_Sala, List<string> listaDePublicidade, List<string> listaDeDuracao, List<string> listaFilmesSala, List<Sessao> listaSessaoSala)
        {
            int indice = 0;

            foreach(Sala sala in ListaDeSalas)
            {
                if(sala.NumeroSala == ID_Sala)
                {
                    ListaDeSalas.RemoveAt(indice);
                    ListaDeSalas.Add(new Sala(ID_Sala, listaDePublicidade, listaDeDuracao, listaFilmesSala, listaSessaoSala));
                    ListaDeSalas = ListaDeSalas.OrderBy(aux => aux.NumeroSala).ToList(); // Ordena por ordem de sala
                    break;
                }

                indice++;
            }
        }

        //Método para adicionar '*'s aos dados dos filmes em salas que tenham mais que um filme. 
        public void PrepararParaEscreverExcel()
        {   
            foreach (Sala sala in ListaDeSalas)
            {
                for(int i=0; i < sala.ListaNomeFilmes.Count;i++)
                {
                    if(i !=0 )
                    {
                        int indice = RetornarIndice(sala.ListaNomeFilmes[i]);

                        string aux = new String('*', i); //Adiciona '*' ao nome caso tenha mais que um filme. multiplica o '*' pelo valor de i.
                        sala.ListaNomeFilmes[i] = sala.ListaNomeFilmes[i] + "" + aux + "";
                        sala.ListaDepublicidade[i] = sala.ListaDepublicidade[i] + "" + aux + "";
                        sala.ListaDeDuracao[i] = sala.ListaDeDuracao[i] + "" + aux + "";

                        //Vou percorrer as sessoes e adicionar os '*'s
                        foreach (Sessao sessao in ListaDeFilmes[indice].ListaDeSessoes)
                        {
                            for(int j=0; j < sala.ListaSessoes.Count; j++)
                            {                           
                                if (sessao.Inicio == sala.ListaSessoes[j].Inicio)
                                {
                                    sala.ListaSessoes[j].Inicio = sala.ListaSessoes[j].Inicio + "" + aux + "";
                                    break;
                                }
                            }
                        }                       
                    }
                }
            }
        }

        //Método para repor dados originais depois de criado o excel. Retira os '*'.
        public void ReporDadosPosExcel()
        {
            foreach (Sala salarepor in ListaDeSalas)
            {
                string[] aux;

                for (int i = 0; i < salarepor.ListaNomeFilmes.Count; i++)
                {
                    if(salarepor.ListaNomeFilmes.Count > 1)
                    {
                        if(i != 0)
                        {
                            aux = salarepor.ListaNomeFilmes[i].Split('*');
                            salarepor.ListaNomeFilmes[i] = aux[0];

                            aux = salarepor.ListaDepublicidade[i].Split('*');
                            salarepor.ListaDepublicidade[i] = aux[0];

                            aux = salarepor.ListaDeDuracao[i].Split('*');
                            salarepor.ListaDeDuracao[i] = aux[0];

                            for (int j = 0; j < salarepor.ListaSessoes.Count; j++)
                            {
                                aux = salarepor.ListaSessoes[j].Inicio.Split('*');
                                salarepor.ListaSessoes[j].Inicio = aux[0];
                            }
                        }                        
                    }                    
                }               
            }
        }

        //Método para Criar o Documento Excel.
        public void CriarExcel()
        {
            
            if (ListaDeSalas.Count != 0)
            {
                PrepararParaEscreverExcel();

                try
                {
                    SaveFileDialog file = new SaveFileDialog();
                    file.Filter = "Ficheiro(*.xlsx)|*.xlsx| All Files(*.*)| *.*";

                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        Excel_saveFolderPath = file.FileName;
                    }
                    else
                    {
                        return;
                    }

                    MessageBox.Show("O processo irá demorar uns segundos.\nPor favor aguarde.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    Excel.Range formatRange; // Para poder formatar o documento.

                    xlWorkBook = xlApp.Workbooks.Add();
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                    //Preencher as Cells do excel.      
                    xlWorkSheet.Cells[1, 2] = "SALA 1";
                    xlWorkSheet.Cells[1, 3] = "SALA 2";
                    xlWorkSheet.Cells[1, 4] = "SALA 3";
                    xlWorkSheet.Cells[1, 5] = "SALA 4";
                    xlWorkSheet.Cells[1, 6] = "SALA 5";
                    xlWorkSheet.Cells[1, 7] = "SALA 6";
                    xlWorkSheet.Cells[1, 8] = "SALA 7";

                    xlWorkSheet.Cells[2, 1] = "Título:";
                    xlWorkSheet.Cells[3, 1] = "Pub:";
                    xlWorkSheet.Cells[4, 1] = "Duração:";                  

                    int AL = 5; //coordenada da linha onde começa a escrever o texto "Inicio, intervalo, Fim"            
                    int alSessao = 5; // Coordenada da linha onde começa a escrever as sessoes;

                    foreach (Sala sala in ListaDeSalas)
                    {
                        switch (sala.NumeroSala)
                        {
                            case "1":
                                for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        xlWorkSheet.Cells[2, 2] = sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 2] = sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 2] = sala.ListaDeDuracao[i];
                                    }
                                    else
                                    {
                                        
                                        xlWorkSheet.Cells[2, 2] = xlWorkSheet.Cells[2, 2].Text + "\n" + sala.ListaNomeFilmes[i];                                     
                                        xlWorkSheet.Cells[3, 2] = xlWorkSheet.Cells[3, 2].Text + " | " + sala.ListaDepublicidade[i];                                    
                                        xlWorkSheet.Cells[4, 2] = xlWorkSheet.Cells[4, 2].Text + " | " + sala.ListaDeDuracao[i];
                                    }
                                }

                                int ALsessao = alSessao; // Coordenada onde começa a escrever as sessoes;
                                List<Sessao> listaTemp = new List<Sessao>(); //Lista temporaria para usar de maneira a que as sessoes da meia noite fiquem no fim do doc.
                                foreach (Sessao sessao in sala.ListaSessoes)
                                {
                                    if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                    {
                                        AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                    }

                                    string[] aux = (sessao.Inicio).Split(':');

                                    if(aux[0] == "00")
                                    {                                    
                                        listaTemp.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[ALsessao, 2] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 2] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 2] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }                                
                                }

                                if(listaTemp.Count !=0) // Se existir sessão da meia noite, escreve a sessão por último, caso contrario seria a primeira sessao. (00).
                                {
                                    foreach(Sessao sessao in listaTemp)
                                    {
                                        if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                        {
                                            AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                        }

                                        xlWorkSheet.Cells[ALsessao, 2] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 2] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 2] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }

                                    listaTemp.Clear();                               
                                }
                                break;

                            case "2":               
                                for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        xlWorkSheet.Cells[2, 3] = sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 3] = sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 3] = sala.ListaDeDuracao[i];
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[2, 3] = xlWorkSheet.Cells[2, 3].Text + "\n" + sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 3] = xlWorkSheet.Cells[3, 3].Text + " | " + sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 3] = xlWorkSheet.Cells[4, 3].Text + " | " + sala.ListaDeDuracao[i];
                                    }                                                   
                                }

                                ALsessao = alSessao; // Coordenada onde começa a escrever as sessoes;
                                listaTemp = new List<Sessao>(); //Lista temporaria para usar de maneira a que as sessoes da meia noite fiquem no fim do doc.
                                foreach (Sessao sessao in sala.ListaSessoes)
                                {
                                    if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                    {
                                        AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                    }

                                    string[] aux = (sessao.Inicio).Split(':');

                                    if (aux[0] == "00")
                                    {
                                        listaTemp.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[ALsessao, 3] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 3] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 3] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }
                                }

                                if (listaTemp.Count != 0) // Se existir sessão da meia noite, escreve a sessão por último, caso contrario seria a primeira sessao. (00).
                                {
                                    foreach (Sessao sessao in listaTemp)
                                    {
                                        if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                        {
                                            AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                        }

                                        xlWorkSheet.Cells[ALsessao, 3] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 3] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 3] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }

                                    listaTemp.Clear();
                                }
                                break;

                            case "3":
                                for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        xlWorkSheet.Cells[2, 4] = sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 4] = sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 4] = sala.ListaDeDuracao[i];
                                    }                        
                                    else
                                    {
                                        xlWorkSheet.Cells[2, 4] = xlWorkSheet.Cells[2, 4].Text + "\n" + sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 4] = xlWorkSheet.Cells[3, 4].Text + " | " + sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 4] = xlWorkSheet.Cells[4, 4].Text + " | " + sala.ListaDeDuracao[i];
                                    }
                                }

                                ALsessao = alSessao; // Coordenada onde começa a escrever as sessoes;
                                listaTemp = new List<Sessao>(); //Lista temporaria para usar de maneira a que as sessoes da meia noite fiquem no fim do doc.
                                foreach (Sessao sessao in sala.ListaSessoes)
                                {
                                    if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                    {
                                        AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                    }

                                    string[] aux = (sessao.Inicio).Split(':');

                                    if (aux[0] == "00")
                                    {
                                        listaTemp.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[ALsessao, 4] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 4] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 4] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }
                                }

                                if (listaTemp.Count != 0) // Se existir sessão da meia noite, escreve a sessão por último, caso contrario seria a primeira sessao. (00).
                                {
                                    foreach (Sessao sessao in listaTemp)
                                    {
                                        if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                        {
                                            AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                        }

                                        xlWorkSheet.Cells[ALsessao, 4] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 4] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 4] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }

                                    listaTemp.Clear();
                                }
                                break;

                            case "4":
                                for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                                {
                                    if (i == 0)
                                    {                        
                                        xlWorkSheet.Cells[2, 5] = sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 5] = sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 5] = sala.ListaDeDuracao[i];
                                    }
                                    else
                                    {                        
                                        xlWorkSheet.Cells[2, 5] = xlWorkSheet.Cells[2, 5].Text + "\n" + sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 5] = xlWorkSheet.Cells[3, 5].Text + " | " + sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 5] = xlWorkSheet.Cells[4, 5].Text + " | " + sala.ListaDeDuracao[i];
                                    }
                                }

                                ALsessao = alSessao; // Coordenada onde começa a escrever as sessoes;
                                listaTemp = new List<Sessao>(); //Lista temporaria para usar de maneira a que as sessoes da meia noite fiquem no fim do doc.
                                foreach (Sessao sessao in sala.ListaSessoes)
                                {
                                    if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                    {
                                        AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                    }

                                    string[] aux = (sessao.Inicio).Split(':');

                                    if (aux[0] == "00")
                                    {
                                        listaTemp.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[ALsessao, 5] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 5] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 5] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }
                                }

                                if (listaTemp.Count != 0) // Se existir sessão da meia noite, escreve a sessão por último, caso contrario seria a primeira sessao. (00).
                                {
                                    foreach (Sessao sessao in listaTemp)
                                    {
                                        if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                        {
                                            AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                        }

                                        xlWorkSheet.Cells[ALsessao, 5] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 5] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 5] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }

                                    listaTemp.Clear();
                                }
                                break;

                            case "5":
                                for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        xlWorkSheet.Cells[2, 6] = sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 6] = sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 6] = sala.ListaDeDuracao[i];
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[2, 6] = xlWorkSheet.Cells[2, 6].Text + "\n" + sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 6] = xlWorkSheet.Cells[3, 6].Text + " | " + sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 6] = xlWorkSheet.Cells[4, 6].Text + " | " + sala.ListaDeDuracao[i];
                                    }
                                }

                                ALsessao = alSessao; // Coordenada onde começa a escrever as sessoes;
                                listaTemp = new List<Sessao>(); //Lista temporaria para usar de maneira a que as sessoes da meia noite fiquem no fim do doc.
                                foreach (Sessao sessao in sala.ListaSessoes)
                                {
                                    if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                    {
                                        AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                    }

                                    string[] aux = (sessao.Inicio).Split(':');

                                    if (aux[0] == "00")
                                    {
                                        listaTemp.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[ALsessao, 6] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 6] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 6] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }
                                }

                                if (listaTemp.Count != 0) // Se existir sessão da meia noite, escreve a sessão por último, caso contrario seria a primeira sessao. (00).
                                {
                                    foreach (Sessao sessao in listaTemp)
                                    {
                                        if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                        {
                                            AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                        }

                                        xlWorkSheet.Cells[ALsessao, 6] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 6] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 6] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }

                                    listaTemp.Clear();
                                }
                                break;

                            case "6":
                                for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        xlWorkSheet.Cells[2, 7] = sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 7] = sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 7] = sala.ListaDeDuracao[i];
                                    }                        
                                    else
                                    {
                                        xlWorkSheet.Cells[2, 7] = xlWorkSheet.Cells[2, 7].Text + "\n" + sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 7] = xlWorkSheet.Cells[3, 7].Text + " | " + sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 7] = xlWorkSheet.Cells[4, 7].Text + " | " + sala.ListaDeDuracao[i];
                                    }                                                              
                                }

                                ALsessao = alSessao; // Coordenada onde começa a escrever as sessoes;
                                listaTemp = new List<Sessao>(); //Lista temporaria para usar de maneira a que as sessoes da meia noite fiquem no fim do doc.
                                foreach (Sessao sessao in sala.ListaSessoes)
                                {
                                    if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                    {
                                        AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                    }

                                    string[] aux = (sessao.Inicio).Split(':');

                                    if (aux[0] == "00")
                                    {
                                        listaTemp.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[ALsessao, 7] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 7] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 7] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }
                                }

                                if (listaTemp.Count != 0) // Se existir sessão da meia noite, escreve a sessão por último, caso contrario seria a primeira sessao. (00).
                                {
                                    foreach (Sessao sessao in listaTemp)
                                    {
                                        if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                        {
                                            AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                        }

                                        xlWorkSheet.Cells[ALsessao, 7] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 7] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 7] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }

                                    listaTemp.Clear();
                                }
                                break;

                            case "7":
                                for (int i = 0; i < sala.ListaNomeFilmes.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        xlWorkSheet.Cells[2, 8] = sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 8] = sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 8] = sala.ListaDeDuracao[i];
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[2, 8] = xlWorkSheet.Cells[2, 8].Text + "\n" + sala.ListaNomeFilmes[i];
                                        xlWorkSheet.Cells[3, 8] = xlWorkSheet.Cells[3, 8].Text + " | " + sala.ListaDepublicidade[i];
                                        xlWorkSheet.Cells[4, 8] = xlWorkSheet.Cells[4, 8].Text + " | " + sala.ListaDeDuracao[i];
                                    }                                                   
                                }

                                ALsessao = alSessao; // Coordenada onde começa a escrever as sessoes;
                                listaTemp = new List<Sessao>(); //Lista temporaria para usar de maneira a que as sessoes da meia noite fiquem no fim do doc.
                                foreach (Sessao sessao in sala.ListaSessoes)
                                {
                                    if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                    {
                                        AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                    }

                                    string[] aux = (sessao.Inicio).Split(':');

                                    if (aux[0] == "00")
                                    {
                                        listaTemp.Add(new Sessao(sessao.Inicio, sessao.Intervalo, sessao.Fim));
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[ALsessao, 8] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 8] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 8] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }
                                }

                                if (listaTemp.Count != 0) // Se existir sessão da meia noite, escreve a sessão por último, caso contrario seria a primeira sessao. (00).
                                {
                                    foreach (Sessao sessao in listaTemp)
                                    {
                                        if (ALsessao >= AL) // Para só escrever o texto uma vez.
                                        {
                                            AL = EscreverInicioIntervaloFim(AL, xlWorkBook, xlWorkSheet);
                                        }

                                        xlWorkSheet.Cells[ALsessao, 8] = sessao.Inicio;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 8] = sessao.Intervalo;
                                        ALsessao++;
                                        xlWorkSheet.Cells[ALsessao, 8] = sessao.Fim;
                                        ALsessao++;
                                        ALsessao++;
                                    }

                                    listaTemp.Clear();
                                }
                                break;

                            default:
                                break;
                        }                  
                    }


                    // --------------------------  Formatação do documento Excel -------------------------------------------------------------------------------------------------------------------


                    //Define o columnwith para 17
                    formatRange = xlWorkSheet.get_Range("B1", "H1");
                    formatRange.ColumnWidth = 17;
                    formatRange.WrapText = true;

                    //Alinha o texto de todas a celulas ao centro.
                    xlWorkSheet.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    xlWorkSheet.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                   
                    //Pinta as celulas com a cor lightgray.
                    formatRange = xlWorkSheet.get_Range("A1", "H1");
                    formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    formatRange = xlWorkSheet.get_Range("A2", "H4");
                    formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    formatRange = xlWorkSheet.get_Range("A3", "H4");
                    formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    formatRange = xlWorkSheet.get_Range("A4", "H4");
                    formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

                    //Contornos das linhas Horizontais
                    formatRange = xlWorkSheet.get_Range("A1", "H1");
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("A2", "H4");
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("A3", "H4");
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("A4", "H4");
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //Coloca as linhas com o texto a Bold.
                    formatRange = xlWorkSheet.get_Range("A1");
                    formatRange.EntireRow.Font.Bold = true;
                    formatRange = xlWorkSheet.get_Range("A2");
                    formatRange.EntireRow.Font.Bold = true;
                    formatRange = xlWorkSheet.get_Range("A3");
                    formatRange.EntireRow.Font.Bold = true;
                    formatRange = xlWorkSheet.get_Range("A4");
                    formatRange.EntireRow.Font.Bold = true;

                    //Contorno das linhas Verticais.
                    formatRange = xlWorkSheet.get_Range("A1", "A" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("B1", "B" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("C1", "C" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("D1", "D" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("D1", "D" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("E1", "E" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("F1", "F" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("G1", "G" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
                    formatRange = xlWorkSheet.get_Range("H1", "H" + (AL - 2));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //Preenche a coluna com a cor LightGray
                    formatRange = xlWorkSheet.get_Range("A1", "A" + (AL-1));
                    formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

                    //Coloca no fundo do horário uma "marca-de-agua".
                    xlWorkSheet.Cells[(AL - 1), 1] = "Horário gerado através do software Horário Maker v1.0"; //Escrever "marca-de-agua"
                    xlWorkSheet.get_Range("A" + (AL - 1), "H" + (AL - 1)).Merge(false); //Une as celeluas.
                    //Coloca em italico.
                    formatRange = xlWorkSheet.get_Range("A" + (AL - 1)); 
                    formatRange.EntireRow.Font.Italic = true;
                    //Coloca a fonte do texto a 9.
                    formatRange = xlWorkSheet.get_Range("A" + (AL - 1));
                    formatRange.Font.Size = 9;

                    //Coloca o limite em volta das celulas do horário.
                    formatRange = xlWorkSheet.get_Range("A1", "H"+(AL-1));
                    formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //------------------------------------------- Fim De Formatação --------------------------------------------------------------------------------------------------------------

                    xlApp.DisplayAlerts = false; //para não aparecer alertas do excel. Quando queria gravar por cima do mesmo doc, aparecia o showdialog que programei em cima e de seguida aparecia outro do excel.
                    xlWorkBook.SaveAs(Excel_saveFolderPath);                   
                    xlWorkBook.Close();
                    xlApp.Quit();

                    MessageBox.Show("Horário criado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReporDadosPosExcel();

                }
                catch(SystemException)
                {
                    MessageBox.Show("Erro ao criar Horário.\nTente Novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ReporDadosPosExcel();
                }           
            }
            else
            {
                MessageBox.Show("As Salas não têm filmes.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }       

        }

        //Método usado para escrever no folha do Excel. (Criei este método apenas para não estar sempre a repetir o código).
        public int EscreverInicioIntervaloFim(int AL, Excel.Workbook xlWorkBook, Excel.Worksheet xlWorkSheet)
        {
            Excel.Range formatRange;
            formatRange = xlWorkSheet.get_Range("A" + AL, "H" + AL);
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            xlWorkSheet.Cells[AL, 1] = "Inicio:";
            AL++;

            formatRange = xlWorkSheet.get_Range("A" + AL, "H" + AL);
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[AL, 1] = "Intervalo:";
            AL++;

            formatRange = xlWorkSheet.get_Range("A" + AL, "H" + AL);
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            xlWorkSheet.Cells[AL, 1] = "Fim:";
            AL++;
            formatRange = xlWorkSheet.get_Range("A" + AL, "H" + AL);
            formatRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

            formatRange = xlWorkSheet.get_Range("A" + AL, "H" + AL);
            formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            AL++;

            return AL;
        }
     

        //------------------------------------- Guardar Dados / Carregar Dados ----------------------------------------


        //Método para Guardar os dados em Xml.
        public void GuardarDadosFilmesXml(string opcao)
        {
            try
            {
                XDocument ficheiro = new XDocument(
                               new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                               new XComment("Lista de Filmes - " + DateTime.Now.ToString()),
                               new XElement("Filmes"));

                foreach (Filme filme in ListaDeFilmes)
                {
                    XElement Node = new XElement("Filme");
                    XElement Titulo = new XElement("Titulo", filme.Titulo);
                    XElement Publicidade = new XElement("Publicidade", filme.Publicidade);
                    XElement Intervalo = new XElement("Intervalo", filme.Intervalo);
                    XElement Creditos = new XElement("Creditos", filme.Creditos);
                    XElement Duracao = new XElement("Duracao", filme.Duracao);
                    XElement Sessoes = new XElement("Sessoes");

                    foreach (Sessao itemSessao in filme.ListaDeSessoes)
                    {
                        XElement sessao = new XElement("Sessao");
                        XElement inicio = new XElement("Inicio", itemSessao.Inicio);
                        XElement intervalo = new XElement("Intervalo", itemSessao.Intervalo);
                        XElement fim = new XElement("Fim", itemSessao.Fim);

                        sessao.Add(inicio);
                        sessao.Add(intervalo);
                        sessao.Add(fim);
                        Sessoes.Add(sessao);
                    }

                    Node.Add(Titulo);
                    Node.Add(Publicidade);
                    Node.Add(Intervalo);
                    Node.Add(Creditos);
                    Node.Add(Duracao);
                    Node.Add(Sessoes);

                    ficheiro.Element("Filmes").Add(Node);
                }

                ficheiro.Save(Filmes_saveFolderPath);

                if (opcao != "Sair" && ListaDeFilmes.Count != 0)
                {
                    // Quando o Método é chamada atraves método "GuardarDados" aparece a menssagem, 
                    // caso seja atraves do método "Sair" nao aparece a menssagem.

                    MessageBox.Show("Dados Guardados!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }   
            catch(SystemException)
            {
                MessageBox.Show("Erro ao guardar a lista de Filmes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                   
        }

        //Método para Carregar os dados do ficheiro Xml.
        public void CaregarDadosFilmesXml()
        {
            try
            {
                ListaDeFilmes.Clear();

                if (File.Exists(Filmes_saveFolderPath))
                {
                    XDocument ficheiro = XDocument.Load(Filmes_saveFolderPath);

                    var Filmes = from item in ficheiro.Element("Filmes").Descendants("Filme") select item;

                    foreach (var itemFilme in Filmes)
                    {
                        List<Sessao> listaSessoes = new List<Sessao>();

                        foreach (var sessao in itemFilme.Descendants("Sessoes").Descendants("Sessao"))
                        {
                            Sessao temp = new Sessao(sessao.Element("Inicio").Value, sessao.Element("Intervalo").Value,
                                                     sessao.Element("Fim").Value);

                            listaSessoes.Add(temp);
                        }

                        ListaDeFilmes.Add(new Filme(itemFilme.Element("Titulo").Value, itemFilme.Element("Publicidade").Value,
                                                    itemFilme.Element("Intervalo").Value, itemFilme.Element("Creditos").Value,
                                                    itemFilme.Element("Duracao").Value, listaSessoes));
                    }
                }
            }
            catch(SystemException)
            {
                MessageBox.Show("Erro ao carregar a lista de Filmes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        //Método para guardar as ListadeSalas em ficheiro Xml.
        public void GuardarSalasEmXml(string opcao)
        {
            try
            {
                XDocument ficheiro = new XDocument(
                               new XDeclaration("1.0", Encoding.UTF8.ToString(), "yes"),
                               new XComment("Lista de Salas - " + DateTime.Now.ToString()),
                               new XElement("Salas"));

                foreach (Sala itemSala in ListaDeSalas)
                {
                    XElement Node_Sala = new XElement("Sala");
                    XElement Filmes = new XElement("Filmes");

                    XElement ID = new XElement("ID", itemSala.NumeroSala);
                    Node_Sala.Add(ID);

                    for (int i = 0; i < itemSala.ListaNomeFilmes.Count; i++)
                    {
                        XElement nome = new XElement("Filme", itemSala.ListaNomeFilmes[i]);
                        Filmes.Add(nome);
                    }

                    Node_Sala.Add(Filmes);

                    ficheiro.Element("Salas").Add(Node_Sala);
                }

                ficheiro.Save(Salas_saveFolderPath);

                if (opcao != "Sair" && ListaDeSalas.Count != 0)
                {
                    // Quando o Método é chamada atraves método "GuardarDados" aparece a menssagem, 
                    // caso seja atraves do método "Sair" nao aparece a menssagem.

                    MessageBox.Show("Dados Guardados!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(SystemException)
            {
                MessageBox.Show("Erro ao guardar a lista de Salas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        //Método para carregar as Salas do ficheiro Xml.
        public void CarregarSalasEmXml()
        {
            try
            {
                ListaDeSalas.Clear();

                if (ListaDeFilmes.Count != 0)
                {
                    if (File.Exists(Salas_saveFolderPath))
                    {
                        XDocument ficheiro = XDocument.Load(Salas_saveFolderPath);

                        var Sala = from item in ficheiro.Element("Salas").Descendants("Sala") select item;

                        foreach (var itemSala in Sala)
                        {
                            List<string> lista = new List<string>();

                            foreach (var filme in itemSala.Element("Filmes").Descendants("Filme"))
                            {
                                lista.Add(filme.Value);
                            }

                            PreencherDadosSessao(itemSala.Element("ID").Value, lista);
                        }
                    }
                }
            }
            catch (SystemException)
            {
                MessageBox.Show("Erro ao carregar a lista de Salas.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

    }
}
