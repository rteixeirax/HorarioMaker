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
    public partial class AdicionarSessoes : Form
    {       
        public AdicionarSessoes()
        {
            InitializeComponent();
        }

        private void AdicionarHorarios_Load(object sender, EventArgs e)
        {           
            if (Program.m_modelo.ListaDeFilmes.Count == 0)
            {
                MessageBox.Show("Lista de Flmes vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                maskedTextBox_sessao.Text = "00:00";
                comboBox_filmes.Items.Clear();
                listView_sessoes.Items.Clear();
                button_inserir.Enabled = false;
                maskedTextBox_sessao.Enabled = false;

                foreach (Filme filme in Program.m_modelo.ListaDeFilmes)
                {
                    comboBox_filmes.Items.Add(filme.Titulo);
                }            
            }           
        }

        private void comboBox_filmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedTextBox_sessao.Enabled = true;
            button_inserir.Enabled = true;      
            listView_sessoes.Items.Clear();

            foreach (Sessao sessao in Program.m_modelo.ListaDeFilmes[comboBox_filmes.SelectedIndex].ListaDeSessoes)
            {
                ListViewItem item = new ListViewItem(sessao.Inicio);
                listView_sessoes.Items.Add(item);
            }            
        }

        private void button_inserir_Click(object sender, EventArgs e)
        { 
            bool flag = false; // false -> nao existe, true -> existe.

            if(comboBox_filmes.SelectedItem != null)
            {
                string[] sessao = maskedTextBox_sessao.Text.Split(':');

                //try -> catch para alertar o utilizador que os valores inseridos estão incompletos, por exemplo [00:--:--].
                //Se os valores estiverem incompletos dá erro na conversão para inteiro. Com esta ciclo evitamos que o programa "crash".
                try
                {
                    //Limita a inserção dos valores dentro dos valores horários. [23:59]
                    if (int.Parse(sessao[0]) >= 0 && int.Parse(sessao[0]) <= 23
                        && int.Parse(sessao[1]) >= 0 && int.Parse(sessao[1]) <= 59)
                    {
                        if (listView_sessoes.Items.Count == 0)
                        {
                            ListViewItem item = new ListViewItem(maskedTextBox_sessao.Text);
                            listView_sessoes.Items.Add(item);
                            GuardarSessoes(comboBox_filmes.SelectedIndex);
                        }
                        else
                        {
                            for (int i = 0; i < listView_sessoes.Items.Count; i++)
                            {
                                if (listView_sessoes.Items[i].Text == maskedTextBox_sessao.Text)
                                {
                                    flag = true;
                                    break;
                                }
                            }

                            if (flag == false) // Sessao ainda nao definida.
                            {
                                ListViewItem item = new ListViewItem(maskedTextBox_sessao.Text);
                                listView_sessoes.Items.Add(item);
                                GuardarSessoes(comboBox_filmes.SelectedIndex);
                            }
                            else // Já existe Sessao definida.
                            {
                                MessageBox.Show("Sessão já definida.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tempos inseridos não se encontram dentro dos limites horários. [23:59]", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(FormatException)
                {
                    MessageBox.Show("Os valores inseridos estão incompletos.\nErro comum, deixar espaços vazios -> [ 00:--:-- ].", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }            
            }
            else
            {
                MessageBox.Show("É necessário selecionar o filme!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Este método guarda as sessoes presentes na "listview_sessoes" e adiciona as mesmas à lista de sessoes do respetivo filme. 
        private void GuardarSessoes(int indice)
        {
            int indiceFilme = indice;
            List<string> listaSessoes = new List<string>();

            for(int i=0; i < listView_sessoes.Items.Count; i++)
            {
                listaSessoes.Add(listView_sessoes.Items[i].Text);
            }

            Program.m_modelo.AdicionarSessoes(indiceFilme, listaSessoes);
            listaSessoes.Clear();
        }
  
        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView_sessoes.SelectedItems.Count != 0)
            {
                listView_sessoes.Items.RemoveAt(listView_sessoes.SelectedIndices[0]);
                GuardarSessoes(comboBox_filmes.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nenhuma sessão selecionada.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button_Limpar_Click(object sender, EventArgs e)
        {
            if(listView_sessoes.Items.Count != 0)
            {
                if (MessageBox.Show("Tem a certeza?", "Limpar Lista de Sessões", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listView_sessoes.Items.Clear();
                    GuardarSessoes(comboBox_filmes.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Lista Vazia.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button_sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
