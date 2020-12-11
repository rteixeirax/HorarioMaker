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

namespace HorarioMaker
{
    public partial class HorarioMaker : Form
    {
        public HorarioMaker()
        {
            InitializeComponent();
        }

        // Quando se fecha a app através do botõa X do formulário.
        private void HorarioMaker_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.m_modelo.GuardarDadosFilmesXml("Sair");
            Program.m_modelo.GuardarSalasEmXml("Sair");
        }

        // Com este evento bloquea as colunas e nao deixa "alargar" as mesma.
        private void listView_filmes_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView_filmes.Columns[e.ColumnIndex].Width;
        }

        //Cada vez que é feito o load da form é executado o Método "ApresentarListaDeFilmes".
        private void HorarioMaker_Load(object sender, EventArgs e)
        {
            //TODO: Colocar data limite de uso. pesquisar como se faz.
            //DateTime TrialLimite = new DateTime(2015, 9, 11);
            //string  TimeToday = DateTime.Now.ToString();
         
            Program.m_modelo.CaregarDadosFilmesXml();
            Program.m_modelo.CarregarSalasEmXml();
            ApresentarListaDeFilmes();
        }

        // Apresenta na ListeView os Filmes que foram adicionados à lista de filmes.
        public void ApresentarListaDeFilmes()
        {
            listView_filmes.Items.Clear();

            if(Program.m_modelo.ListaDeFilmes.Count !=0)
            {
                foreach (Filme filme in Program.m_modelo.ListaDeFilmes)
                {
                    ListViewItem item = new ListViewItem(filme.Titulo);
                    item.SubItems.Add(filme.Publicidade.ToString());
                    item.SubItems.Add(filme.Intervalo.ToString());
                    item.SubItems.Add(filme.Creditos.ToString());
                    item.SubItems.Add(Program.m_modelo.CalcularDuracao(filme.Publicidade, filme.Creditos));

                    item.Font = new Font(listView_filmes.Font.ToString(), 10, FontStyle.Regular);

                    listView_filmes.Items.Add(item);
                }
            }
            else
            {
                this.Show();

                if(MessageBox.Show("Não existem filmes na lista de filmes. Deseja adicionar?", "Aviso",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Program.v_adicionarFilme.ShowDialog();
                }
            }
            
        }     

        // Apresenta a Form para Adicionar o Filme.
        private void button_adicionar_Click(object sender, EventArgs e)
        {
            Program.v_adicionarFilme.ShowDialog();
        }

        // Executa o Método para editar o filme selecionado.
        private void button_editar_Click(object sender, EventArgs e)
        {
            // Executa o Método para editar o filme selecionado.

            if(Program.m_modelo.ListaDeFilmes.Count != 0)
            {
                if (listView_filmes.SelectedItems.Count != 0)
                {
                    Program.v_editarFilme.ApresentarDadosParaEditar(listView_filmes.SelectedIndices[0]);
                    listView_filmes.Select(); //set the focus no item  que tinha selecionado antes de clicar no botao.
                }
                else
                {
                    MessageBox.Show("Selecione o filme que deseja editar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lista de Filmes vazia!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_defenirSessoes_Click(object sender, EventArgs e)
        {            
            Program.v_adicionarSessoes.ShowDialog();
        }

        // Método para ver as sessoes do filme selecionado.
        private void button_sessoes_Click(object sender, EventArgs e)
        {
            if(Program.m_modelo.ListaDeFilmes.Count != 0)
            {
                if (listView_filmes.SelectedItems.Count != 0)
                {
                    if (Program.m_modelo.ListaDeFilmes[listView_filmes.SelectedIndices[0]].ListaDeSessoes.Count != 0)
                    {
                        Program.v_verSessoes.ApresentarSessoes(listView_filmes.SelectedIndices[0]);
                        listView_filmes.Select(); //set the focus no item  que tinha selecionado antes de clicar no botao.
                    }
                    else
                    {
                        MessageBox.Show("Não existem sessões definidas para este filme.\nUtilize a opção 'Definir sessões' para adicionar sessões ao filme.",
                           "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o filme que deseja ver as sessões!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lista de Filmes vazia!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        // executa o Método para eliminar o filme.
        private void button_remover_Click(object sender, EventArgs e)
        {
            if(Program.m_modelo.ListaDeFilmes.Count != 0)
            {
                // executa o Método para eliminar o filme.
                if (listView_filmes.SelectedItems.Count != 0)
                {
                    Program.m_modelo.EliminarFilme(listView_filmes.SelectedIndices[0]);
                    listView_filmes.Select(); //set the focus no item  que tinha selecionado antes de clicar no botao.
                }
                else
                {
                    MessageBox.Show("Selecione o filme que deseja eliminar!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lista de Filmes vazia!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        // Executa o Método para guardar os dados.    
        private void button_guardar_Click(object sender, EventArgs e)
        {
            // Executa o Método para guardar os dados.
            Program.m_modelo.GuardarDadosFilmesXml("Guardar");
        }

        // Executa o Método para sair e guardar dados.    
        private void button_sair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Program.m_modelo.GuardarDadosFilmesXml("Sair");
                Program.m_modelo.GuardarSalasEmXml("Sair");
                Application.Exit();
            }
        }

        private void button_opcoes_Click(object sender, EventArgs e)
        {
            //TODO: Escrever codigo relativo ao botao "Opções".
            MessageBox.Show("Brevemente poderá definir a duração de intervalo (atcualmente definido para 7 minutos), poderá também definir a pasta onde gravar os dados.",
                "Oops.. Em desenvolvimento!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Apresenta a Form com o Horario
        private void button_horario_Click(object sender, EventArgs e)
        {
            Program.v_criarHorario.ShowDialog(); 
        }
    }
}
