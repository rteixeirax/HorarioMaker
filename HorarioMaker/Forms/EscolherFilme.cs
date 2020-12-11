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
    public partial class EscolherFilme : Form
    {
        string ID_Sala = ""; // Para saber para qual sala esta a ser feita a selecao do filme.

        public EscolherFilme()
        {
            InitializeComponent();
        }
        
        public void ApresentarEscolherFilme(string Id_Sala)
        {
            if(Program.m_modelo.ListaDeFilmes.Count != 0)
            {
                ID_Sala = Id_Sala;
                this.Text = "Adicionar filme à " + Id_Sala;

                comboBox_filme.Items.Clear();

                foreach (Filme filme in Program.m_modelo.ListaDeFilmes)
                {
                    comboBox_filme.Items.Add(filme.Titulo);
                }

                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lista de Filmes vazia.","Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                
        }

        private void button_inserir_Click(object sender, EventArgs e)
        {
            if(comboBox_filme.SelectedItem != null)
            {
                Program.v_criarHorario.InserirFilmeNaListTextBox(ID_Sala, comboBox_filme.SelectedIndex);
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um filme.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
