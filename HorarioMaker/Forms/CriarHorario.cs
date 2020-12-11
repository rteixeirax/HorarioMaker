using HorarioMaker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorarioMaker.Forms
{
    public partial class CriarHorario : Form
    {
        public CriarHorario()
        {
            InitializeComponent();
        }

        private void SelecionarFilme_Load(object sender, EventArgs e)
        {
            listBox_sala1.Items.Clear();
            listBox_sala2.Items.Clear();
            listBox_sala3.Items.Clear();
            listBox_sala4.Items.Clear();
            listBox_sala5.Items.Clear();
            listBox_sala6.Items.Clear();
            listBox_sala7.Items.Clear();

            if (Program.m_modelo.ListaDeSalas.Count != 0)
            {               
                foreach(Sala sala in Program.m_modelo.ListaDeSalas)
                {
                    for(int i=0; i< sala.ListaNomeFilmes.Count;i++)
                    {
                        switch (sala.NumeroSala)
                        {
                            case "1":
                                listBox_sala1.Items.Add(sala.ListaNomeFilmes[i]);
                                break;
                            case "2":
                                listBox_sala2.Items.Add(sala.ListaNomeFilmes[i]);
                                break;
                            case "3":
                                listBox_sala3.Items.Add(sala.ListaNomeFilmes[i]);
                                break;
                            case "4":
                                listBox_sala4.Items.Add(sala.ListaNomeFilmes[i]);
                                break;
                            case "5":
                                listBox_sala5.Items.Add(sala.ListaNomeFilmes[i]);
                                break;
                            case "6":
                                listBox_sala6.Items.Add(sala.ListaNomeFilmes[i]);
                                break;
                            case "7":
                                listBox_sala7.Items.Add(sala.ListaNomeFilmes[i]);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void InserirFilmeNaListTextBox(string Id_sala, int indice)
        {
            string aux = "";
            bool flag = false; // false -> nao existe, true -> existe.

            // No caso de o filme selecionado nao tiver sessões definidas nao permite adiciona-lo à sala.
            if(Program.m_modelo.ListaDeFilmes[indice].ListaDeSessoes.Count == 0)
            {
                MessageBox.Show("Não existem Sessões definidas para este filme.\nÉ necessário ter sessões definidas para ser adicionado à sala.", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            switch (Id_sala)
            {
                case "Sala 1":
                    if(listBox_sala1.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox_sala1.Items.Count; i++)
                        {
                            aux = listBox_sala1.Items[i].ToString();
                            if (Program.m_modelo.VerificarColisoesEntreSessoes(aux, indice) != false)
                            {
                                flag = true; //Retorna false não existir colisão.
                                break;
                            }
                        }

                        if (flag == false)
                        {
                            listBox_sala1.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel adicionar o filme pretendido, existem sessões que colidem com as sessões do filme já existente na sala.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    else
                    {
                        listBox_sala1.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                        break;
                    }
                   
                   
                case "Sala 2":
                    if (listBox_sala2.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox_sala2.Items.Count; i++)
                        {
                            aux = listBox_sala2.Items[i].ToString();
                            if (Program.m_modelo.VerificarColisoesEntreSessoes(aux, indice) != false)
                            {
                                flag = true; //Retorna false não existir colisão.
                                break;
                            }
                        }

                        if (flag == false)
                        {
                            listBox_sala2.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel adicionar o filme pretendido, existem sessões que colidem com as já existentes na sala.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    else
                    {
                        listBox_sala2.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                        break;
                    }
                case "Sala 3":
                    if (listBox_sala3.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox_sala3.Items.Count; i++)
                        {
                            aux = listBox_sala3.Items[i].ToString();
                            if (Program.m_modelo.VerificarColisoesEntreSessoes(aux, indice) != false)
                            {
                                flag = true; //Retorna false não existir colisão.
                                break;
                            }
                        }

                        if (flag == false)
                        {
                            listBox_sala3.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel adicionar o filme pretendido, existem sessões que colidem com as já existentes na sala.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    else
                    {
                        listBox_sala3.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                        break;
                    }
                case "Sala 4":
                    if (listBox_sala4.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox_sala4.Items.Count; i++)
                        {
                            aux = listBox_sala4.Items[i].ToString();
                            if (Program.m_modelo.VerificarColisoesEntreSessoes(aux, indice) != false)
                            {
                                flag = true; //Retorna false não existir colisão.
                                break;
                            }
                        }

                        if (flag == false)
                        {
                            listBox_sala4.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel adicionar o filme pretendido, existem sessões que colidem com as já existentes na sala.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    else
                    {
                        listBox_sala4.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                        break;
                    }
                case "Sala 5":
                    if (listBox_sala5.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox_sala5.Items.Count; i++)
                        {
                            aux = listBox_sala5.Items[i].ToString();
                            if (Program.m_modelo.VerificarColisoesEntreSessoes(aux, indice) != false)
                            {
                                flag = true; //Retorna false não existir colisão.
                                break;
                            }
                        }

                        if (flag == false)
                        {
                            listBox_sala5.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel adicionar o filme pretendido, existem sessões que colidem com as já existentes na sala.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    else
                    {
                        listBox_sala5.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                        break;
                    }
                case "Sala 6":
                    if (listBox_sala6.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox_sala6.Items.Count; i++)
                        {
                            aux = listBox_sala6.Items[i].ToString();
                            if (Program.m_modelo.VerificarColisoesEntreSessoes(aux, indice) != false)
                            {
                                flag = true; //Retorna false não existir colisão.
                                break;
                            }
                        }

                        if (flag == false)
                        {
                            listBox_sala6.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel adicionar o filme pretendido, existem sessões que colidem com as já existentes na sala.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    else
                    {
                        listBox_sala6.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                        break;
                    }
                case "Sala 7":
                    if (listBox_sala7.Items.Count != 0)
                    {
                        for (int i = 0; i < listBox_sala7.Items.Count; i++)
                        {
                            aux = listBox_sala7.Items[i].ToString();
                            if (Program.m_modelo.VerificarColisoesEntreSessoes(aux, indice) != false)
                            {
                                flag = true; //Retorna false não existir colisão.
                                break;
                            }
                        }

                        if (flag == false)
                        {
                            listBox_sala7.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Não é possivel adicionar o filme pretendido, existem sessões que colidem com as já existentes na sala.",
                                "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                    else
                    {
                        listBox_sala7.Items.Add(Program.m_modelo.ListaDeFilmes[indice].Titulo);
                        break;
                    }
                default:
                    break;
            }
        }

        //--------------------- Chamada da Form para selecionar o filme ------------------------------
        private void button_add_sala1_Click(object sender, EventArgs e)
        {
            Program.v_escolherFilme.ApresentarEscolherFilme("Sala 1");
        }

        private void button_add_sala2_Click(object sender, EventArgs e)
        {
            Program.v_escolherFilme.ApresentarEscolherFilme("Sala 2");
        }

        private void button_add_sala3_Click(object sender, EventArgs e)
        {
            Program.v_escolherFilme.ApresentarEscolherFilme("Sala 3");
        }

        private void button_add_sala4_Click(object sender, EventArgs e)
        {
            Program.v_escolherFilme.ApresentarEscolherFilme("Sala 4");
        }

        private void button_add_sala5_Click(object sender, EventArgs e)
        {
            Program.v_escolherFilme.ApresentarEscolherFilme("Sala 5");
        }

        private void button_add_sala6_Click(object sender, EventArgs e)
        {
            Program.v_escolherFilme.ApresentarEscolherFilme("Sala 6");
        }

        private void button_add_sala7_Click(object sender, EventArgs e)
        {
            Program.v_escolherFilme.ApresentarEscolherFilme("Sala 7");
        }

        //--------------------- Remover o filme da listbox ---------------------------------
        private void buttonbutton_remove_sala1_Click(object sender, EventArgs e)
        {
            if(listBox_sala1.SelectedItem != null)
            {
                listBox_sala1.Items.RemoveAt(listBox_sala1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_remove_sala2_Click(object sender, EventArgs e)
        {
            if (listBox_sala2.SelectedItem != null)
            {
                listBox_sala2.Items.RemoveAt(listBox_sala2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_remove_sala3_Click(object sender, EventArgs e)
        {
            if (listBox_sala3.SelectedItem != null)
            {
                listBox_sala3.Items.RemoveAt(listBox_sala3.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_remove_sala4_Click(object sender, EventArgs e)
        {
            if (listBox_sala4.SelectedItem != null)
            {
                listBox_sala4.Items.RemoveAt(listBox_sala4.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_remove_sala5_Click(object sender, EventArgs e)
        {
            if (listBox_sala5.SelectedItem != null)
            {
                listBox_sala5.Items.RemoveAt(listBox_sala5.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_remove_sala6_Click(object sender, EventArgs e)
        {
            if (listBox_sala6.SelectedItem != null)
            {
                listBox_sala6.Items.RemoveAt(listBox_sala6.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_remove_sala7_Click(object sender, EventArgs e)
        {
            if (listBox_sala7.SelectedItem != null)
            {
                listBox_sala7.Items.RemoveAt(listBox_sala7.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //----------------------------- Limpar os filmes da listbox ------------------------------------------------------

        private void button_LimparSala1_Click(object sender, EventArgs e)
        {
            if(listBox_sala1.Items.Count != 0)
            {
                if (MessageBox.Show("Limpar Filmes da Sala 1?", "Limpar Sala",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala1.Items.Clear();

                    for (int i = 0; i < Program.m_modelo.ListaDeSalas.Count; i++)
                    {
                        if (Program.m_modelo.ListaDeSalas[i].NumeroSala == "1")
                        {
                            Program.m_modelo.ListaDeSalas.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sala Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
        }

        private void button_LimparSala2_Click(object sender, EventArgs e)
        {
            if (listBox_sala2.Items.Count != 0)
            {
                if (MessageBox.Show("Limpar Filmes da Sala 2?", "Limpar Sala",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala2.Items.Clear();

                    for (int i = 0; i < Program.m_modelo.ListaDeSalas.Count; i++)
                    {
                        if (Program.m_modelo.ListaDeSalas[i].NumeroSala == "2")
                        {
                            Program.m_modelo.ListaDeSalas.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sala Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button_LimparSala3_Click(object sender, EventArgs e)
        {
            if (listBox_sala3.Items.Count != 0)
            {
                if (MessageBox.Show("Limpar Filmes da Sala 3?", "Limpar Sala",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala3.Items.Clear();

                    for (int i = 0; i < Program.m_modelo.ListaDeSalas.Count; i++)
                    {
                        if (Program.m_modelo.ListaDeSalas[i].NumeroSala == "3")
                        {
                            Program.m_modelo.ListaDeSalas.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sala Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button_LimparSala4_Click(object sender, EventArgs e)
        {
            if (listBox_sala4.Items.Count != 0)
            {
                if (MessageBox.Show("Limpar Filmes da Sala 4?", "Limpar Sala",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala4.Items.Clear();

                    for (int i = 0; i < Program.m_modelo.ListaDeSalas.Count; i++)
                    {
                        if (Program.m_modelo.ListaDeSalas[i].NumeroSala == "4")
                        {
                            Program.m_modelo.ListaDeSalas.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sala Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button_LimparSala5_Click(object sender, EventArgs e)
        {
            if (listBox_sala5.Items.Count != 0)
            {
                if (MessageBox.Show("Limpar Filmes da Sala 5?", "Limpar Sala",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala5.Items.Clear();

                    for (int i = 0; i < Program.m_modelo.ListaDeSalas.Count; i++)
                    {
                        if (Program.m_modelo.ListaDeSalas[i].NumeroSala == "5")
                        {
                            Program.m_modelo.ListaDeSalas.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sala Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button_LimparSala6_Click(object sender, EventArgs e)
        {
            if (listBox_sala6.Items.Count != 0)
            {
                if (MessageBox.Show("Limpar Filmes da Sala 6?", "Limpar Sala",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala6.Items.Clear();

                    for (int i = 0; i < Program.m_modelo.ListaDeSalas.Count; i++)
                    {
                        if (Program.m_modelo.ListaDeSalas[i].NumeroSala == "6")
                        {
                            Program.m_modelo.ListaDeSalas.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sala Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button_LimparSala7_Click(object sender, EventArgs e)
        {
            if (listBox_sala7.Items.Count != 0)
            {
                if (MessageBox.Show("Limpar Filmes da Sala 7?", "Limpar Sala",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala7.Items.Clear();

                    for (int i = 0; i < Program.m_modelo.ListaDeSalas.Count; i++)
                    {
                        if (Program.m_modelo.ListaDeSalas[i].NumeroSala == "7")
                        {
                            Program.m_modelo.ListaDeSalas.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sala Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        // -------------------------------------------------------------------------------------------------------------------------


        private void button_limpar_Click(object sender, EventArgs e)
        { 
            if (Program.m_modelo.ListaDeSalas.Count != 0 || listBox_sala1.Items.Count !=0 || listBox_sala2.Items.Count != 0
                || listBox_sala3.Items.Count != 0 || listBox_sala4.Items.Count != 0 || listBox_sala5.Items.Count != 0
                || listBox_sala6.Items.Count != 0 || listBox_sala7.Items.Count != 0)
            {
                if (MessageBox.Show("Tem a certeza?", "Limpar Salas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox_sala1.Items.Clear();
                    listBox_sala2.Items.Clear();
                    listBox_sala3.Items.Clear();
                    listBox_sala4.Items.Clear();
                    listBox_sala5.Items.Clear();
                    listBox_sala6.Items.Clear();
                    listBox_sala7.Items.Clear();

                    Program.m_modelo.ListaDeSalas.Clear();                    
                }
            }
            else
            {
                MessageBox.Show("Salas Vazias.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_fechar_Click(object sender, EventArgs e)
        {
            GravarFilmesNaListaDeSalas("Sair");
            this.Close();        
        }

        //Método para Copiar os filmes que estão listados nas listbox para a lista de salas.
        public void GravarFilmesNaListaDeSalas(string opcao)
        {
            Program.m_modelo.ListaDeSalas.Clear(); //Elimina a lista exixtente para adicionar os novos filmes que estão listados nas salas.
            string aux = "";
            List<string> nomes = new List<string>();

            if (listBox_sala1.Items.Count == 0 && listBox_sala2.Items.Count == 0
                && listBox_sala3.Items.Count == 0 && listBox_sala4.Items.Count == 0
                && listBox_sala5.Items.Count == 0 && listBox_sala6.Items.Count == 0 && listBox_sala7.Items.Count == 0)
            {
                if(opcao == "Guardar") //Para decidir se aparece mensagem ou não. Depende de quem chama o método.
                {
                    MessageBox.Show("Salas vazias.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }         
            }
            else
            {
                // Adicionar filmes da Sala 1
                if (listBox_sala1.Items.Count != 0)
                {
                    for (int i = 0; i < listBox_sala1.Items.Count; i++)
                    {
                        aux = listBox_sala1.Items[i].ToString();
                        nomes.Add(aux);
                    }
                    Program.m_modelo.PreencherDadosSessao("1", nomes);
                    nomes.Clear();
                }


                // Adicionar filmes da Sala 2
                if (listBox_sala2.Items.Count != 0)
                {
                    for (int i = 0; i < listBox_sala2.Items.Count; i++)
                    {
                        aux = listBox_sala2.Items[i].ToString();
                        nomes.Add(aux);
                    }
                    Program.m_modelo.PreencherDadosSessao("2", nomes);
                    nomes.Clear();
                }

                // Adicionar filmes da Sala 3
                if (listBox_sala3.Items.Count != 0)
                {
                    for (int i = 0; i < listBox_sala3.Items.Count; i++)
                    {
                        aux = listBox_sala3.Items[i].ToString();
                        nomes.Add(aux);
                    }
                    Program.m_modelo.PreencherDadosSessao("3", nomes);
                    nomes.Clear();
                }

                // Adicionar filmes da Sala 4
                if (listBox_sala4.Items.Count != 0)
                {
                    for (int i = 0; i < listBox_sala4.Items.Count; i++)
                    {
                        aux = listBox_sala4.Items[i].ToString();
                        nomes.Add(aux);
                    }
                    Program.m_modelo.PreencherDadosSessao("4", nomes);
                    nomes.Clear();
                }

                // Adicionar filmes da Sala 5
                if (listBox_sala5.Items.Count != 0)
                {
                    for (int i = 0; i < listBox_sala5.Items.Count; i++)
                    {
                        aux = listBox_sala5.Items[i].ToString();
                        nomes.Add(aux);
                    }
                    Program.m_modelo.PreencherDadosSessao("5", nomes);
                    nomes.Clear();
                }

                // Adicionar filmes da Sala 6
                if (listBox_sala6.Items.Count != 0)
                {
                    for (int i = 0; i < listBox_sala6.Items.Count; i++)
                    {
                        aux = listBox_sala6.Items[i].ToString();
                        nomes.Add(aux);
                    }
                    Program.m_modelo.PreencherDadosSessao("6", nomes);
                    nomes.Clear();
                }

                // Adicionar filmes da Sala 7
                if (listBox_sala7.Items.Count != 0)
                {
                    for (int i = 0; i < listBox_sala7.Items.Count; i++)
                    {
                        aux = listBox_sala7.Items[i].ToString();
                        nomes.Add(aux);
                    }
                    Program.m_modelo.PreencherDadosSessao("7", nomes);
                    nomes.Clear();
                }
            }
        }    

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            GravarFilmesNaListaDeSalas("Guardar");
            Program.m_modelo.GuardarSalasEmXml("Guardar");
        }

        private void button_Excel_Click(object sender, EventArgs e)
        {
            GravarFilmesNaListaDeSalas("Guardar");

            if(Program.m_modelo.ListaDeSalas.Count != 0)
            {
                if (MessageBox.Show("Tenha em atenção de que necessita ter instalado o Excel no seu Computador.\n\nCriar Horário?", "Criar Horário",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                                       
                    Program.m_modelo.CriarExcel();                    
                }
                else
                {
                    return;
                }
            }       
        }
    }
}
